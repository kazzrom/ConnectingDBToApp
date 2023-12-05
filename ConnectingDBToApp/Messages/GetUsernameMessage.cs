using CommunityToolkit.Mvvm.Messaging.Messages;


namespace ConnectingDBToApp.Messages
{
    public class GetUsernameMessage : ValueChangedMessage<string>
    {
        public GetUsernameMessage(string value) : base(value)
        {
        }
    }
}
