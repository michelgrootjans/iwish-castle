/*
 * Created by: 
 * Created: zondag 12 augustus 2007
 */

using Castle.Components.Common.EmailSender;
using Castle.MonoRail.Framework;

namespace iWish.Castle.MonoRail.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    public class TestController : BaseController
    {
        public void Index()
        {
        }

        [Rescue("problemsendingemail")]
        public void SendSimple(string to, string subject)
        {
            PropertyBag["to"] = to;
            PropertyBag["subject"] = subject;

            RenderEmailAndSend("simple");

            RenderView("EmailSent");
        }

        [Rescue("problemsendingemail")]
        public void SendHtml(string to, string subject)
        {
            Message message = RenderMailMessage("htmlemail");

            message.From = "you@yourserver.com";
            message.To = to;
            message.Subject = subject;

            DeliverEmail(message);

            PropertyBag["to"] = to;
            PropertyBag["subject"] = subject;

            RenderView("EmailSent");
        }
    }
}