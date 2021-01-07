using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace GoldPriceAPI.FixerCurrAPI
{
    [ApiController]
    public class FixerCurrencyController: ControllerBase
    {

        public static Response CallApi(string url, string method, string param)
        {
            url = string.Format("{0}{1}", url, method);

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = param.Length;

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(param);
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.ASCII);
            string jsonData = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Response>(jsonData);
        }

    }

    public class RequestParam
    {
        public string AccessKey { get; set; }
        public string FromSymbol { get; set; }  
        public string ToSymbol { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateVal { get; set; }
    }
    public class Response
    {
            public bool success { get; set; }
            public string remarks { get; set; }
            public QueryData query { get; set; }
            public InfoData info { get;set; }
            public DateTime date { get; set; }
            public Decimal result { get; set; }
    }
    public class QueryData
    {
        public string From { get; set; }
        public string To { get; set; }
        public Decimal Amount { get; set; }
    }
    public class InfoData
    {
        public DateTime TimeStamp { get; set; }
        public Decimal Rate { get; set; }
    }
}