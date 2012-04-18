using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Progressive.TimeAttackOnline.Models
{
    public class ServerModel
    {
        private HttpWebRequest request;

        public ServerModel()
        {
        }

        public IAsyncResult BeginGetEvent(AsyncCallback callback, object state, string passPhrase)
        {
            return BeginGetServerResponse(callback, state, "get", "get", "pass-phrase", passPhrase);
        }

        public bool? EndGetEvent(IAsyncResult asyncResult, out string json)
        {
            if (!EndGetServerResponse(asyncResult, out json))
            {
                return null;
            }
            if (string.IsNullOrEmpty(json))
            {
                json = "";
                return false;
            }
            return true;
        }

        public IAsyncResult BeginAddEvent(
            AsyncCallback callback, object state, string passPhrase, string title, DateTime startTime)
        {
            return BeginGetServerResponse(
                callback, state, "get", "add",
                "pass-phrase", passPhrase, "title", title, "start-date", startTime.ToUniversalTime().ToString("yyyy/MM/dd hh:mm:ss"));
        }

        public bool? EndAddEvent(IAsyncResult asyncResult)
        {
            string result;
            if (!EndGetServerResponse(asyncResult, out result))
            {
                return null;
            }
            return result == "success";
        }

        private string GetUrl(string command, params string[] parameters)
        {
            Debug.Assert(parameters.Length % 2 == 0);

            var sb = new StringBuilder("http://tao-prgrssv.herokuapp.com/");
            sb.Append(command).Append('?');
            for (int i = 0; i < parameters.Length; i += 2)
            {
                sb.Append(parameters[i]).Append('=');
                sb.Append(parameters[i + 1]);
                sb.Append('&');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        private IAsyncResult BeginGetServerResponse(
            AsyncCallback callback, object state, string method, string command, params string[] parameters)
        {
            Debug.Assert("get".Equals(method, StringComparison.OrdinalIgnoreCase)
                || "set".Equals(method, StringComparison.OrdinalIgnoreCase));

            HttpWebRequest request = HttpWebRequest.CreateHttp(GetUrl(command, parameters));
            this.request = request;
            request.Method = method;
            return request.BeginGetResponse(callback, state);
        }

        private bool EndGetServerResponse(IAsyncResult asyncResult, out string result)
        {
            HttpWebRequest request = this.request;
            Debug.Assert(request != null);
            WebResponse response;
            try
            {
                response = request.EndGetResponse(asyncResult);
            }
            catch (WebException)
            {
                result = "";
                return false;
            }
            using (var s = response.GetResponseStream())
            using (var sr = new StreamReader(s))
            {
                result = sr.ReadLine();
            }
            return true;
        }
    }
}
