using Vonage;
using Vonage.Request;

namespace eFitnessAPI.Services
{
    public class SMSService : ISMSService
    {
        public bool SendMessage(string to, string message)
        {
            var apiKey = "ddf751df";
            var secretKey = "7XrZpYkBX0C8gmPv";
            var credentials = Credentials.FromApiKeyAndSecret(apiKey, secretKey);

            var VonageClient = new VonageClient(credentials);
            var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = to,
                From = "eFitness",
                Text = message
            });

            return true;
        }
    }
}
