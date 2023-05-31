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
    public static class GroupManagementExtensions
    {
        public static WebApplication RegisterGroupManagementEndpoints(this WebApplication app)
        {
            app.MapPost("/GroupManagement", async (
                [FromServices] ILogger logger,
                [FromServices] IGroupRepository groupRepository,
                [FromBody] Group group) =>
            {
                logger.Debug($"Add group..");

                if (string.IsNullOrEmpty(group.Name))
                {
                    logger.Error($"Wrong group name '{group.Name}'.");

                    return Results.BadRequest();
                }

                var addedGroup = await groupRepository.AddGroup(group);

                logger.Debug($"Group added successfully (id = {group.Id}).");

                return Results.Ok(addedGroup);
            });

            app.MapDelete("/GroupManagement/{groupId}", async (
                [FromServices] MyBl myBl,
                [FromRoute] Guid groupId) =>
            {
                await myBl.DeleteGroup(groupId);

                return Results.Ok();
            });

            return app;
        }
    }
}
