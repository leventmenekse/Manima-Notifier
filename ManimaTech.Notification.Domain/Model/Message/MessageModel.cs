using ManimaTech.Notification.Domain.Model.Base;

namespace ManimaTech.Notification.Domain.Model.Message
{
    public class MessageModel : BaseModel
    {
        public string MessageType { get; set; }
        public string Router { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public ReceiverModel Receiver { get; set; }
        public SenderModel Sender { get; set; }
        public string Subject { get; set; }
        public string Result { get; set; }
    }

    public class ReceiverModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class SenderModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
