using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eFitnessAPI.Helper
{
    public class Message
    {
        public virtual string Info { get; set; }
        public virtual object Data { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual PagedResult PagedResult { get; set; }

        public Message()
        {
        }

        public Message(bool isValid, string info, object data = null)
        {
            IsValid = isValid;
            Info = info;
            Data = data;
        }
    }
}
