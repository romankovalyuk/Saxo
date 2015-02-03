using System;
using System.Net;
using Saxo.Helpers;

namespace Saxo.Flow
{
    public class SaxoService : IDataService
    {
        protected string Isbn { get; private set; }

        public string Query { get; private set; }
        public dynamic QueryResult { get; private set; }
        public object RawData { get; private set; }
        public Exception ServiceException { get; private set; }

        protected virtual string ApiUrl
        {
            get { return "http://api.saxo.com/v1/products/products.json?key="; }
        }

        protected virtual string ApiKey
        {
            get { return "08964e27966e4ca99eb0029ac4c4c217"; }
        }

        public SaxoService(RequestInfo requestInfo)
        {
            Isbn = requestInfo.Isbn;
        }

        protected virtual void BuildQuery()
        {
            Query = string.Format("{0}{1}&isbn={2}",ApiUrl, ApiKey, Isbn);
        } 

        public void Search()
        {
            try
            {
                Clear();
                BuildQuery();
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "text/html; charset=utf-8");
                    RawData = webClient.DownloadString(Query);
                }
                QueryResult = JsonHelper.ConvertJsonStringToExpando((string)RawData);
            }
            catch (WebException webException)
            {
                ServiceException = webException;
            }
            catch (Exception exception)
            {
                ServiceException = exception;
            }
        }

        private void Clear()
        {
            ServiceException = null;
            RawData = null;
            QueryResult = null;
        }

        public bool IsQuerySuccessfull()
        {
            return ServiceException == null;
        }
    }
}