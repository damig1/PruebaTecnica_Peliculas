using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Peliculas
{
    public class MessageDisplay
    {
        public static void SetMessage(string message, Exception ex, Models.MessageDisplay.eMessageType type, string key = "")
        {
            SetMessage(new Models.MessageDisplay(message, ex, type, key));
        }

        public static void SetMessage(Models.MessageDisplay MessageDisplay)
        {
            HttpContext.Current.Session["MessageDisplay"] = MessageDisplay;
        }

        public static string ShowMessage(string key = "")
        {
            if (HttpContext.Current.Session["MessageDisplay"] != null)
            {
                Models.MessageDisplay messageDisplay = (Models.MessageDisplay)HttpContext.Current.Session["MessageDisplay"];
                if (!string.IsNullOrEmpty(key))
                {
                    if (!messageDisplay.Key.Equals(key))
                    {
                        return "";
                    }
                }
                HttpContext.Current.Session["MessageDisplay"] = null;

                return messageDisplay.ShowMessage();
            }
            else
            {
                return "";
            }
        }

    }
}