using PostmarkDotNet;
using PostMarkInbound.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostMarkInbound.Controllers
{
    public class InboundController : ApiController
    {
        //private string attachmentSaveFolder = @"c:\temp\";

        [HttpPost]
        public HttpResponseMessage Receive(PostmarkInboundMessage message)
        {
            if (message != null)
            {
                /*To access message data
                var headers = message.Headers;

                // To access Attachments
                var attachments = message.Attachments;
                foreach (var attachment in attachments)
                {
                    // Access normal members, etc
                    var attachmentName = attachment.Name;

                    // To access file data and save to c:\temp\
                    if (Convert.ToInt32(attachment.ContentLength) > 0)
                    {
                        byte[] filebytes = Convert.FromBase64String(attachment.Content);
                        FileStream fs = new FileStream(attachmentSaveFolder + attachment.Name,
                                                       FileMode.CreateNew,
                                                       FileAccess.Write,
                                                       FileShare.None);
                        fs.Write(filebytes, 0, filebytes.Length);
                        fs.Close();
                    }
                }
                */

                using (var dbCtxt = new PostmarkContext())
                {
                    PMInboundMessage pm = new PMInboundMessage(message);
                    dbCtxt.Messages.Add(pm);
                    dbCtxt.SaveChanges();
                }
                // If we succesfully received a hook, let the call know
                return new HttpResponseMessage(HttpStatusCode.Created);    // 201 Created
            }
            else
            {
                // If our message was null, we throw an exception
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent("Error parsing Inbound Message.") });
            }
        }

        [HttpGet]
        public HttpResponseMessage ReceiveTest()
        {

                using (var dbCtxt = new PostmarkContext())
                {
                    PMInboundMessage pm = new PostMarkInbound.Models.PMInboundMessage
                    {
                        StrippedTextReply = "",
                        Tag = "",
                        HtmlBody = "<p>TestMessage</p>",
                        TextBody = "Test Message",
                        MailboxHash = string.Empty,
                        Date = DateTime.Now.ToString(),
                        OriginalRecipient = string.Empty,
                        MessageID = string.Empty,
                        Subject = "Test Message",
                        ReplyTo = string.Empty,
                        Bcc = string.Empty,
                        Cc = string.Empty,
                        To = string.Empty,
                        FromName = string.Empty,
                        From = string.Empty,
                        receivedAt = DateTime.Now
                    }; ;
                    dbCtxt.Messages.Add(pm);
                    dbCtxt.SaveChanges();
                }
                // If we succesfully received a hook, let the call know
                return new HttpResponseMessage(HttpStatusCode.Created);    // 201 Created

        }
    }
}