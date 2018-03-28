using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PostMarkInbound.Models
{
    public class PMInboundMessage
    {
        [Key]
        public int InboundMessageId { get; set; }
        public string StrippedTextReply { get; set; }
        public string Tag { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
        public string MailboxHash { get; set; }
        public string Date { get; set; }
        public string OriginalRecipient { get; set; }
        public string MessageID { get; set; }
        public string Subject { get; set; }
        public string ReplyTo { get; set; }
        public string Bcc { get; set; }
        public string Cc { get; set; }
        public string To { get; set; }
        public string FromName { get; set; }
        public string From { get; set; }
        public DateTime receivedAt { get; set; }

        public PMInboundMessage()
        { }

        public PMInboundMessage(PostmarkInboundMessage message)
        {
            StrippedTextReply = message.StrippedTextReply;
            Tag = message.Tag;
            HtmlBody = message.HtmlBody;
            TextBody = message.TextBody;
            MailboxHash = message.MailboxHash;
            Date = message.Date;
            OriginalRecipient = message.OriginalRecipient;
            MessageID = message.MessageID;
            Subject = message.Subject;
            ReplyTo = message.ReplyTo;
            Bcc = message.Bcc;
            Cc = message.Cc;
            To = message.To;
            FromName = message.FromName;
            From = message.From;
            receivedAt = DateTime.Now;
        }
    }
}