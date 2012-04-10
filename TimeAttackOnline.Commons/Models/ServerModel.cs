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
        HttpWebRequest request;

        public ServerModel()
        {
        }

        private IAsyncResult BeginGetServerResponse(AsyncCallback callback)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("http://tao-prgrssv.herokuapp.com/");
            this.request = request;
            request.Method = "get";
            return request.BeginGetResponse(callback, null);
        }

        private string EndGetServerResponse(IAsyncResult asyncResult)
        {
            HttpWebRequest request = this.request;
            Debug.Assert(request != null);
            WebResponse response = request.EndGetResponse(asyncResult);
            using (var s = response.GetResponseStream())
            using (var sr = new StreamReader(s))
            {
                return sr.ReadLine();
            }
        }
    }
}
