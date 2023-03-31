namespace JoinDev.Infra.CrossCutting.Security.Token
{
    public interface ITokenService
    {
        string GenerateJwt(string email);
    }
}
