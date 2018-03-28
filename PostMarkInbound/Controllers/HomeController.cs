using PostMarkInbound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostMarkInbound.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<PMInboundMessage> messages = null;

            using (PostmarkContext ctxt = new PostmarkContext())
            {
                messages = ctxt.Messages.OrderByDescending(o => o.receivedAt).ToList();
            }
            return View(messages);
        }
    }
}