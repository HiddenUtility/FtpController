using System;
using System.Net;

namespace FtpController
{
    public class DirectoryMaker : Ftp
    {
        ConnectingInformation Info;
        public DirectoryMaker(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }

        public void MakeDirectory(string Dirname)
        {
            Uri newUri = new Uri(Info.RootUri, Dirname);
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(newUri);
            ftpWebRequest.Credentials = new NetworkCredential(Info.Username, Info.Password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.UsePassive = true;
            ftpWebRequest.Proxy = null;

            try
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    Console.WriteLine("{0}:{1}", ftpWebResponse.StatusCode, ftpWebResponse.StatusDescription);
                }
            }catch (WebException ex)
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ex.Response)
                {
                    Console.WriteLine($"{ftpWebResponse.StatusCode}:{ftpWebResponse.StatusDescription}");
                }
            }
        }
    }
}
