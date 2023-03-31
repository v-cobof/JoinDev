namespace JoinDev.Infra.CrossCutting.Security.Encryption
{
    public interface IEncryptionService
    {
        string Encrypt(string clearText);

        string Decrypt(string cipherText);

        bool IsEqual(string cipherText, string regularText);
    }
}
