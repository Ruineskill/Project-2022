namespace RestAPI.Interfaces
{
    public interface ITokenValidationService
    {
        bool Validate(string token);
    }
}
