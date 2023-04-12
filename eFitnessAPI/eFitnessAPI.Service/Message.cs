using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Service
{
    public class Message
    {
        public string? Info { get; set; }
        public object? Data { get; set; }
        public bool? Valid { get; set; }
    }
}
