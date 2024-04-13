using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.ModelBinding;
using System.Collections;

namespace Peliculas.Common
{
    public class Common
    {
        public static void ShowSuccessMessage(string SuccessMessage)
        {
            MessageDisplay.SetMessage(SuccessMessage, new Exception(), Models.MessageDisplay.eMessageType.Success);
        }

        public static void ShowErrorMessage(string ErrorMessage)
        {
            MessageDisplay.SetMessage(ErrorMessage, new Exception(), Models.MessageDisplay.eMessageType.Error);
        }

        public static void LogAndShowError(Exception ex, string ErrorMessage)
        {
            LogAndShowErrorAndRedir(ex, ErrorMessage, null);
        }

        public static void LogAndShowErrorAndRedir(Exception ex, string ErrorMessage, string redirURL)
        {
            if (ex is Business.BusinessException)
            {
                MessageDisplay.SetMessage(ex.Message, null, Models.MessageDisplay.eMessageType.Error);
            }
            else
            {
                MessageDisplay.SetMessage("Error " + ErrorMessage, ex, Models.MessageDisplay.eMessageType.Error);
            }
            if (!string.IsNullOrEmpty(redirURL))
            {
                HttpContext.Current.Response.Redirect(redirURL, false);
            }
        }

        private static Hashtable hstFilters
        {
            get
            {
                if (HttpContext.Current.Session["SessionFilters"] == null)
                {
                    HttpContext.Current.Session["SessionFilters"] = new Hashtable();
                }
                return (Hashtable)HttpContext.Current.Session["SessionFilters"];
            }
            set
            {
                HttpContext.Current.Session["SessionFilters"] = value;
            }
        }

        public static bool LoadFilter<T>(ref T model) where T : class
        {
            string sURL = HttpContext.Current.Request.Url.LocalPath.ToLower();
            return LoadFilter(ref model, sURL);
        }

        public static bool LoadFilter<T>(ref T model, string sURL) where T : class
        {
            if (hstFilters.Contains(sURL))
            {
                model = (T)hstFilters[sURL];
                return true;
            }
            return false;
        }

        public static void SaveFilter<T>(T model) where T : class
        {
            string sURL = HttpContext.Current.Request.Url.LocalPath.ToLower();
            SaveFilter(model, sURL);
        }

        public static void SaveFilter<T>(T model, string sURL) where T : class
        {
            if (hstFilters.Contains(sURL))
            {
                hstFilters.Remove(sURL);
            }
            hstFilters.Add(sURL, model);
        }
    }
}