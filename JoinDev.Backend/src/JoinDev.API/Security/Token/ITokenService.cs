namespace JoinDev.API.Security.Token
{
    public interface ITokenService
    {
        string GenerateJwt(string email);
    }
}
