using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace Vs.Support.Commons
{
    class API
    {
        public static DataTable getDataAPI(string path)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string response = client.DownloadString(path);

                DataTable dt = new DataTable();
                dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.DeserializeObject(response).ToString());

                return dt;
            }
            catch
            {
                return null;
            }
        }
        public static object postWebApi(object data, Uri webApiUrl)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            // Set the header so it knows we are sending JSON
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            // Serialise the data we are sending in to JSON
            string serialisedData = JsonConvert.SerializeObject(data);

            // Make the request
            string response = client.UploadString(webApiUrl, serialisedData);

            // Deserialise the response into a GUID
            return JsonConvert.DeserializeObject(response);
        }
    }
}
