using ConnectingDBToApp.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;


namespace ConnectingDBToApp.Messages
{
    public class GetTestResultMessage : ValueChangedMessage<TestResult>
    {
        public GetTestResultMessage(TestResult value) : base(value)
        {
        }
    }
}
