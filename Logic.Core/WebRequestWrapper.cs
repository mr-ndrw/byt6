using System;
using System.Net;
using System.Security.Policy;

namespace Logic.Core
{
    public class WebRequestWrapper : IWebRequestWrapper
    {
        private HttpWebRequest _request;

        public WebRequestWrapper(string url)
        {
            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Proxy = null;
        }

        public DateTime LastModified
        {
            get
            {
                var response = (HttpWebResponse)_request.GetResponse();
                return response.LastModified;
            }
        }
    }
}
