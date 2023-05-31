namespace Application.Bl.Contracts
{
    public interface IEmailValidator
    {
        bool IsValid(string email);
    }
}