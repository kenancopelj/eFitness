namespace eFitnessAPI.Services
{
    public interface ISMSService
    {
        public bool SendMessage(string to, string message);
    }
}
