using CommunityToolkit.Mvvm.Messaging.Messages;
using ConnectingDBToApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingDBToApp.Messages
{
    public class GetTestResultMessage : ValueChangedMessage<TestResult>
    {
        public GetTestResultMessage(TestResult value) : base(value)
        {
        }
    }
}
