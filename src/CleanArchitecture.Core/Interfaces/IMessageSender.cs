using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMessageSender
    {
        void SendNotificationEmail(string toAddress, string messageBody);
        
    }
}
