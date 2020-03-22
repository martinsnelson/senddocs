using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace SendDocs
{
    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly UTF8Encoding _utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        static void Main(string[] args)
        {


            //static async Task CreateConsentAsync(Uri uri, ConsentHeaders cconsentHeaders, ConsentBody cconsent )
            //{
            // using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri))
            // {
            //     req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            //     req.Headers.Add("Cache-Control", "no-cache");
            //     // req.Headers.Add("otherHeader", myValue);
            //     //etc. more headers added, as needed...

            //     String jsonObject = JsonConvert.SerializeObject(cconsent, Formatting.Indented);
            //     request.Content = new StringContent(jsonObject, _utf8, "application/json");

            //     using (HttpResponseMessage response = await _httpClient.SendAsync(request).ConfigureAwait(false))
            //     {
            //         Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            //         Console.WriteLine("Got response: HTTP status: {0} ({1})", response.StatusCode, responseHttpStatusCode);
            //     }
            // }
            //}

            //  Restsharp
            // var client = new RestClient("http://sandbox.clicksign.com/api/v1/documents?access_token=1cdb03b5-8eac-492c-bdaf-756b8cfd29f7");
            // var request = new RestRequest(Method.POST);
            // request.AddHeader("postman-token", "766c8465-a232-a58d-382b-38eebaa813d3");
            // request.AddHeader("cache-control", "no-cache");
            // request.AddHeader("content-type", "application/json");
            // request.AddHeader("accept", "application/json");
            // request.AddParameter("application/json", "{\r\n  \"document\": {\r\n    \"path\": \"/1234567891011121314151620.pdf\",\r\n    \"content_base64\": \"data:application/pdf;base64,,TmVsc29u\",\r\n    \"deadline_at\": \"2020-03-22T14:30:59-03:00\",\r\n    \"auto_close\": true,\r\n    \"locale\": \"pt-BR\",\r\n    \"sequence_enabled\": false\r\n  }\r\n}", ParameterType.RequestBody);
            // IRestResponse response = client.Execute(request);

            // HTTPCLIENTE
            var url = "http://sandbox.clicksign.com/api/v1/documents?";

            var _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();


            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url + "access_token=1cdb03b5-8eac-492c-bdaf-756b8cfd29f7");
            // { Version = HttpVersion.Version11 };

            var request = new
            {
                document = new
                {
                    path = "/12345678910111213141516.pdf",
                    content_base64 = "data:application/pdf;base64,,TmVsc29u",
                    deadline_at = "2020-03-22T14:30:59-03:00",
                    auto_close = true,
                    locale = "pt-BR",
                    sequence_enabled = false
                },
            };

            var requestBody = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            // _client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            requestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            // var response = _client.SendAsync(requestMessage);
            var response = _client.SendAsync(requestMessage).ConfigureAwait(false);

            // if (response.IsCompleted)
            //     Console.WriteLine("ok1");

            // if (response.IsCompletedSuccessfully)
            //     Console.WriteLine("ok2");

            // if (response.Result.IsSuccessStatusCode)
            //     Console.WriteLine("ok3");

            // var responseContent = response.Result.Content.ReadAsStringAsync().Result;

            // if (response.Result.IsSuccessStatusCode)
            // {
            //     var documentoResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
            //     // Console.WriteLine(documentoResponse);
            // }
        }
    }
}
