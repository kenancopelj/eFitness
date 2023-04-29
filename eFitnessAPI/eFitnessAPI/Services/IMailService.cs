namespace eFitnessAPI.Services
{
    public interface IMailService
    {
        public bool Posalji(string to, string message, string subject);
    }
}
