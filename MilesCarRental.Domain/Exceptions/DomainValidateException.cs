using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Exceptions
{
    public class DomainValidateException : Exception
    {
        public string Message { get; }
        public DomainValidateException(string message) : base("")
        {
            Message = message;
        }
    }
}
