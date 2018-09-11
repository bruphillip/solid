using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaSolid
{
    public interface IEmailSender
    {
        void Send(string email, string subject, string body);
    }
}
