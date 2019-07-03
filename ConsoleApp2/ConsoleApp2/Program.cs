using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using Microsoft.Win32;
using System.Net.Http;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting POST");
            var tt = new Ticket();

            tt.PostTicket().Wait();

            tt.PostTheTicket();

            Console.WriteLine("Ending POST");
        }
    }

    class Ticket
    {
        public Task PostTheTicket()
        {
            return Task.Run(async () =>
            {
                await PostTicket();
            });
        }

        public async Task PostTicket()
        {
            string data = "testing the client";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(data);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://test.colpipe.com/T4TestWebApi/");
            var content = new ByteArrayContent(bytes);
            var t = await client.PostAsync("/api/Tickets", content);

            var tt = t.RequestMessage.Content.ToString();
        }
    }

    //public class AcceptCertPolicy : ICertificatePolicy
    //{
    //    // Default policy for certificate validation.
    //    public static bool DefaultValidate = false;

    //    public bool CheckValidationResult(ServicePoint sp, X509Certificate cert,
    //       WebRequest request, int problem)
    //    {
    //        return true;
    //    }

    //}

    /*
//            client.




            System.Console.WriteLine("Starting post...");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Set Policy To Accept SSL Certs
            ServicePointManager.CertificatePolicy = new AcceptCertPolicy();

            Uri uri = new Uri("http://test.colpipe.com/T4TestWebApi/api/tickets");

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }

            System.Console.WriteLine("Getting response post...");

            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();

                System.Console.WriteLine("HTTP POST " + httpResponse.StatusCode + " - " + httpResponse.StatusDescription);

                Stream respStream = httpResponse.GetResponseStream();
                TextReader reader = new StreamReader(respStream, System.Text.UTF8Encoding.UTF8, true, 4096);
                string respData = reader.ReadToEnd();
                reader.Close();
                httpResponse.Close();
                System.Console.WriteLine("Response Data: " + respData);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex.Message);
            }


            System.Console.Read();

     */
}
