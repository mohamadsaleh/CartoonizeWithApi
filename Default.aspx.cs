using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //using (var client = new HttpClient())
        //using (var formData = new MultipartFormDataContent())
        //{
        //    string sPathSource = System.Web.Hosting.HostingEnvironment.MapPath("~/1.jpg");
        //    string sPathResult = System.Web.Hosting.HostingEnvironment.MapPath("~/2.jpg");
        //    var inFileStream = new FileStream(sPathSource, FileMode.Open);
        //    StreamContent imageContent = new StreamContent(inFileStream);
        //    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    formData.Headers.Add("X-Api-Key", "T775CGF-VW1MVKT-NQDY23S-XRP5YNR");
        //    formData.Add(imageContent, "image", "1.jpg");
        //    formData.Add(new StringContent("image"), "mode");
        //    formData.Add(new StringContent("jpg"), "format");
        //    formData.Add(new StringContent("#FFFFFF"), "backround_color");
        //    var response = client.PostAsync("https://api.photoscissors.com/v1/change-background", formData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        FileStream fileStream = new FileStream(sPathResult, FileMode.Create, FileAccess.Write, FileShare.None);
        //        response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => { fileStream.Close(); });
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error: " + response.Content.ReadAsStringAsync().Result);
        //    }
        //}





        //using (var client = new HttpClient())
        //using (var formData = new MultipartFormDataContent())
        //{
        //    string sPathSource = System.Web.Hosting.HostingEnvironment.MapPath("~/2.jpg");
        //    string sPathResult = System.Web.Hosting.HostingEnvironment.MapPath("~/3.jpg");
        //    var inFileStream = new FileStream(sPathSource, FileMode.Open);
        //    StreamContent imageContent = new StreamContent(inFileStream);
        //    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    formData.Add(imageContent, "source", "source");
        //    formData.Add(new StringContent("image"), "file_type");
        //    var response = client.PostAsync("https://master-white-box-cartoonization-psi1104.endpoint.ainize.ai/predict", formData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        FileStream fileStream = new FileStream(sPathResult, FileMode.Create, FileAccess.Write, FileShare.None);
        //        response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => { fileStream.Close(); });
        //    }
        //    else
        //    {
        //        Label1.Text = "Error: " + response.Content.ReadAsStringAsync().Result;
        //        //Console.WriteLine("Error: " + response.Content.ReadAsStringAsync().Result);
        //    }
        //}



    }

    protected void ButtonUploadImage_Click(object sender, EventArgs e)
    {
        LabelResult.Text = "";
        string relativeSourcePath = "";
        string absoluteSourcePath = "";
        if(FileUpload1.HasFile)
        {
            relativeSourcePath = "pic/" + Session.SessionID + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.'));
            absoluteSourcePath = Server.MapPath(relativeSourcePath);
            FileUpload1.SaveAs(absoluteSourcePath);
        }


        ImageSource.ImageUrl = relativeSourcePath;
        string relativeBackRemoved = "pic/" + Session.SessionID + "_backRemoved" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.'));
        string absoluteBackRemovedPath = Server.MapPath(relativeBackRemoved);
        string relativeCartoonizedPath = "pic/" + Session.SessionID + "_cartoonized" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.'));
        string absoluteCartoonizedPath = Server.MapPath(relativeCartoonizedPath);


        LabelResult.Text += Cartoonizer.Cartoonize(absoluteSourcePath, absoluteCartoonizedPath) + " -- ";
        ImageResultCartoon.ImageUrl = relativeCartoonizedPath;

        System.Threading.Thread.Sleep(10000);

        LabelResult.Text += Cartoonizer.RemoveBackground(absoluteCartoonizedPath, absoluteBackRemovedPath);
        ImageResultBackRemoved.ImageUrl = relativeBackRemoved;
        

        ImageOnCover1.ImageUrl = relativeBackRemoved;


        //using (var client = new HttpClient())
        //using (var formData = new MultipartFormDataContent())
        //{
        //    //string sPathSource = Server.MapPath("pic/" + Session.SessionID + "1" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    string sPathSource = xFilePath;
        //    //string sPathResult = Server.MapPath("pic/" + Session.SessionID + "2" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    string sPathResult = Server.MapPath("pic/" + Session.SessionID + "1" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    var inFileStream = new FileStream(sPathSource, FileMode.Open);
        //    StreamContent imageContent = new StreamContent(inFileStream);
        //    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    formData.Add(imageContent, "source", "source");
        //    formData.Add(new StringContent("image"), "file_type");
        //    var response = client.PostAsync("https://master-white-box-cartoonization-psi1104.endpoint.ainize.ai/predict", formData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        FileStream fileStream = new FileStream(sPathResult, FileMode.Create, FileAccess.Write, FileShare.None);
        //        response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => { fileStream.Close(); });
        //        fileStream.Close();
        //        //ImageResultCartoon.ImageUrl = "pic/" + Session.SessionID + "2" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.'));
        //    }
        //    else
        //    {
        //        LabelResult.Text = "Error: " + response.Content.ReadAsStringAsync().Result;
        //        //Console.WriteLine("Error: " + response.Content.ReadAsStringAsync().Result);
        //    }
        //}




        //using (var client = new HttpClient())
        //using (var formData = new MultipartFormDataContent())
        //{
        //    //string sPathSource = xFilePath;
        //    string sPathSource = Server.MapPath("pic/" + Session.SessionID + "1" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    string sPathResult = Server.MapPath("pic/" + Session.SessionID + "2" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    //string sPathResult = Server.MapPath("pic/" + Session.SessionID + "1" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    var inFileStream = new FileStream(sPathSource, FileMode.Open);
        //    StreamContent imageContent = new StreamContent(inFileStream);
        //    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    formData.Headers.Add("X-Api-Key", "T775CGF-VW1MVKT-NQDY23S-XRP5YNR");
        //    //formData.Add(imageContent, "image", "pic/" + Session.SessionID + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    formData.Add(imageContent, "image", "pic/" + Session.SessionID + "1" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.')));
        //    formData.Add(new StringContent("image"), "mode");
        //    formData.Add(new StringContent("jpg"), "format");
        //    formData.Add(new StringContent("#FFFFFF"), "backround_color");
        //    var response = client.PostAsync("https://api.photoscissors.com/v1/change-background", formData).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        FileStream fileStream = new FileStream(sPathResult, FileMode.Create, FileAccess.Write, FileShare.None);
        //        response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => { fileStream.Close(); });
        //        //ImageResultCut.ImageUrl = "pic/" + Session.SessionID + "1" + FileUpload1.FileName.Remove(0, FileUpload1.FileName.LastIndexOf('.'));
        //        fileStream.Close();
        //    }
        //    else
        //    {
        //       LabelResult.Text = "Error: " + response.Content.ReadAsStringAsync().Result;
        //        //Console.WriteLine("Error: " + response.Content.ReadAsStringAsync().Result);
        //    }
        //}






        //System.Threading.Thread.Sleep(5000);
        //LabelResult.Text = "Done";
    }


    protected void ButtonClear_Click(object sender, EventArgs e)
    {
        string[] files = Directory.GetFiles(Server.MapPath("pic"));
        for (int i = 0; i < files.Length; i++)
        {
            File.Delete(files[i]);
        }
    }
}