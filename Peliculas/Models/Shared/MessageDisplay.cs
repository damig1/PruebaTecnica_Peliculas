using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Peliculas.Models
{
    public class MessageDisplay
    {
        public enum eMessageType
        {
            Success,
            Warning,
            Error,
            CustomInvoiceSuccess
        }

        public string Message { get; set; }

        public Exception Ex { get; set; }

        public eMessageType MessageType { get; set; }

        public string Key { get; set; } = "";

        public MessageDisplay() { }

        public MessageDisplay(string message, Exception ex, eMessageType messageType, string key = "")
        {
            this.Message = message;
            this.Ex = ex;
            this.MessageType = messageType;
            this.Key = key;
        }

        public string ShowMessage()
        {
            if (string.IsNullOrEmpty(this.Message))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            string headerDiv;
            if (this.MessageType != eMessageType.CustomInvoiceSuccess)
            {
                headerDiv = "<div id=\"alert-message\" role=\"alert\" class=\"alert alert-{0} alert-dismissible in growl\" style=\"z-index:999\" >";
            }
            else
            {
                headerDiv = "<div id=\"alert-message\" role=\"alert\" class=\"alert alert-{0} alert-dismissible in growl-invoice\" style=\"z-index:999\" >";
            }
            switch (this.MessageType)
            {
                case eMessageType.Error:
                    headerDiv = String.Format(headerDiv, "danger");
                    break;
                case eMessageType.Success:
                    headerDiv = String.Format(headerDiv, "success");
                    break;
                case eMessageType.Warning:
                    headerDiv = String.Format(headerDiv, "warning");
                    break;
                case eMessageType.CustomInvoiceSuccess:
                    headerDiv = String.Format(headerDiv, "success");
                    break;
            }

            sb.Append(headerDiv);
            sb.Append("<button aria-label=\"Close\" data-dismiss=\"alert\" class=\"close\" type=\"button\"><span aria-hidden=\"true\">×</span></button>");
            sb.Append("<p>" + this.Message + "</p>");
            sb.Append("</div>");
            if (this.Ex != null)
            {
                sb.Append("<!-- " + this.Ex.Message);
                if (this.Ex.InnerException != null)
                {
                    sb.Append("<br>Inner exception: " + this.Ex.InnerException.Message);
                }

                if (!string.IsNullOrEmpty(this.Ex.StackTrace))
                {
                    sb.Append("<br>Stack trace: " + this.Ex.StackTrace);
                }
                sb.Append("-->");
            }
            return sb.ToString();
        }
    }
}