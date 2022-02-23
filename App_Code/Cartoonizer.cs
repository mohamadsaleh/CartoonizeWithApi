using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

/// <summary>
/// Summary description for Cartoonizer
/// </summary>
public class Cartoonizer
{
    public static string RemoveBackground(string sourcePath, string destinationPath)
    {
        string toReturn = "";
        using (var client = new HttpClient())
        using (var formData = new MultipartFormDataContent())
        {
            string sPathSource = sourcePath;
            string sPathResult = destinationPath;
            var inFileStream = new FileStream(sPathSource, FileMode.Open);
            StreamContent imageContent = new StreamContent(inFileStream);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            formData.Headers.Add("X-Api-Key", "T775CGF-VW1MVKT-NQDY23S-XRP5YNR");
            formData.Add(imageContent, "image", sourcePath);
            formData.Add(new StringContent("image"), "mode");
            formData.Add(new StringContent("jpg"), "format");
            formData.Add(new StringContent("#FFFFFF"), "backround_color");
            var response = client.PostAsync("https://api.photoscissors.com/v1/change-background", formData).Result;

            if (response.IsSuccessStatusCode)
            {
                FileStream fileStream = new FileStream(sPathResult, FileMode.Create, FileAccess.Write, FileShare.None);
                response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => { fileStream.Close(); });                
                //fileStream.Close();
                toReturn = "Background Removal is Done";
            }
            else
            {
                toReturn = "Error: " + response.Content.ReadAsStringAsync().Result;
            }
            return toReturn;
        }
    }


    public static string Cartoonize(string sourcePath, string destinationPath)
    {
        string toReturn = "";

        using (var client = new HttpClient())
        using (var formData = new MultipartFormDataContent())
        {            
            string sPathSource = sourcePath;
            string sPathResult = destinationPath;
            var inFileStream = new FileStream(sPathSource, FileMode.Open);
            StreamContent imageContent = new StreamContent(inFileStream);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            formData.Add(imageContent, "source", "source");
            formData.Add(new StringContent("image"), "file_type");
            var response = client.PostAsync("https://master-white-box-cartoonization-psi1104.endpoint.ainize.ai/predict", formData).Result;

            if (response.IsSuccessStatusCode)
            {
                FileStream fileStream = new FileStream(sPathResult, FileMode.Create, FileAccess.Write, FileShare.None);
                response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => { fileStream.Close(); });
                //fileStream.Close();                
                toReturn = "Catroonizing is Done";
            }
            else
            {
                toReturn = "Error: " + response.Content.ReadAsStringAsync().Result;
            }
        }

        return toReturn;
    }


}
