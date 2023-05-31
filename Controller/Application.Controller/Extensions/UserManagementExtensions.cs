using Application.Bl.Contracts;
using Application.Repository.Contracts;
using Application.Repository.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace Application.Controller.Extensions
{
    public static class UserManagementExtensions
    {
        public static WebApplication RegisterUserManagementEndpoints(this WebApplication app)
        {
            app.MapGet("/UserManagement/users", async (
                [FromServices] ILogger logger,
                [FromServices] IUserRepository userRepository) =>
            {
                logger.Debug($"Get users");

                var users = await userRepository.GetUsers();

                logger.Debug($"Get users successfully.");

                return Results.Ok(users);
            });

            app.MapGet("/UserManagement/{userId}", async (
                [FromServices] ILogger logger,
                [FromServices] IUserRepository userRepository,
                [FromRoute] Guid userId) =>
            {
                logger.Debug($"Get user {userId}");

                var user = await userRepository.GetUser(userId);

                if (user == null)
                {
                    logger.Debug($"User with id = '{userId}' not found.");

                    return Results.NotFound();
                }

                logger.Debug($"Get user {userId} successfully.");

                return Results.Ok(user);
            })
                .WithOpenApi()
                .WithName("Ha-ha-ha");

            app.MapPost("/UserManagement", async (
                [FromServices] ILogger logger,
                [FromServices] IUserRepository userRepository,
                [FromServices] IEmailValidator emailValidator,
                [FromBody] User user) =>
            {
                logger.Debug($"Add user..");

                if (user.Email == null || !emailValidator.IsValid(user.Email))
                {
                    logger.Error($"Wrong e-mail '{user.Email}'.");

                    return Results.BadRequest();
                }

                if (string.IsNullOrEmpty(user.Name))
                {
                    logger.Error($"Wrong user name '{user.Name}'.");

                    return Results.BadRequest();
                }

                var addedUser = await userRepository.AddUser(user);

                logger.Debug($"User added successfully (id = {user.Id}).");

                return Results.Ok(addedUser);
            });

            app.MapPut("/UserManagement", async (
                [FromServices] ILogger logger,
                [FromServices] IUserRepository userRepository,
                [FromServices] IEmailValidator emailValidator,
                [FromBody] User user) =>
            {
                logger.Debug($"Update user..");

                if (user.Email == null || !emailValidator.IsValid(user.Email))
                {
                    logger.Error($"Wrong e-mail '{user.Email}'.");

                    return Results.BadRequest();
                }

                if (string.IsNullOrEmpty(user.Name))
                {
                    logger.Error($"Wrong user name '{user.Name}'.");

                    return Results.BadRequest();
                }

                await userRepository.UpdateUser(user);

                logger.Debug($"User updated successfully (id = {user.Id}).");

                return Results.Ok();
            });

            app.MapDelete("/UserManagement/{userId}", async (
                [FromServices] ILogger logger,
                [FromServices] IUserRepository userRepository,
                [FromRoute] Guid userId) =>
            {
                logger.Debug($"Delete user..");

                if (!await userRepository.UserExists(userId))
                {
                    logger.Debug($"User with id = '{userId}' not found.");

                    return Results.NotFound();
                }

                await userRepository.DeleteUser(userId);

                logger.Debug($"User deleted successfully.");

                return Results.Ok();
            });

            return app;
        }
    }
}
