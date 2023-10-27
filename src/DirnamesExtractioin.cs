using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FtpController
{
    public class DirnamesExtractioin : Ftp
    {
        private readonly ConnectingInformation Info;
        public DirnamesExtractioin(ConnectingInformation ConnectingInformation): base(ConnectingInformation)
        {
            this.Info = ConnectingInformation;
        }

        public string[] GetDirnames(string TargetDirname)
        {
            


            Uri newUri = new Uri(Info.RootUri, TargetDirname);
            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(newUri);
            ftpWebRequest.Credentials = new NetworkCredential(Info.Username, Info.Password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.UsePassive = true;
            ftpWebRequest.Proxy = null;

            List<string> dirnames = new List<string>();

            try
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                using(StreamReader streamReader = new StreamReader(ftpWebResponse.GetResponseStream()))
                {
                    string line;
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();
                        if(Path.HasExtension(line)){continue;} //TODO IsDirectoryに変えたほうがいい。
                        dirnames.Add(line);
                    }
                    Console.WriteLine("{0}:{1}", ftpWebResponse.StatusCode, ftpWebResponse.StatusDescription);
                }
            }catch (WebException ex)
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ex.Response)
                {
                    Console.WriteLine($"{ftpWebResponse.StatusCode}:{ftpWebResponse.StatusDescription}");
                }
            }


            return dirnames.ToArray();
        }
    }

    
}
