namespace PostMarkInbound.Migrations
{
    using PostmarkDotNet.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PostMarkInbound.Models.PostmarkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PostMarkInbound.Models.PostmarkContext context)
        {

            var initmessage = new PostMarkInbound.Models.PMInboundMessage
            {
                StrippedTextReply = "",
                Tag = "",
                HtmlBody = "<p>Welcome</p>",
                TextBody = "Welcome",
                MailboxHash = string.Empty,
                Date = DateTime.Now.ToString(),
                OriginalRecipient = string.Empty,
                MessageID = string.Empty,
                Subject = "Welcome Message",
                ReplyTo = string.Empty,
                Bcc = string.Empty,
                Cc = string.Empty,
                To = string.Empty,
                FromName = string.Empty,
                From = string.Empty,
                receivedAt = DateTime.Now
            };

            context.Messages.AddOrUpdate(initmessage);
        }
    }
}
