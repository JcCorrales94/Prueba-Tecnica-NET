namespace BackendApp_Domain.Interfaces.Service
{
    public interface IEncryptionService
    {
        string EncryptString(string text);
        string DecryptString(string cipherText);
    }
}
