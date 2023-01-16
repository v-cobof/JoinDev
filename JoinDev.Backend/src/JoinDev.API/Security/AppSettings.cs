namespace JoinDev.API.Security
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiresInHours { get; set; }
        public string Issuer { get; set; }
        public string ValidOn { get; set; }
    }
}
