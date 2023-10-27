using System;
using System.Net;

namespace FtpController
{

    public class Ftp
    {
        readonly ConnectingInformation Info;
        bool Connecting;
        public Ftp(ConnectingInformation info)
        {
            this.Info = info;
            this.Connecting = false;
        }

        public void Connect()
        {

            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(Info.RootUri);
            ftpWebRequest.Credentials = new NetworkCredential(Info.Username, Info.Password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.UsePassive = true;
            ftpWebRequest.Proxy = null;

            try
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    Console.WriteLine("接続に成功しました。");
                    this.Connecting = true;
                }
            }
            catch
            {
                Console.WriteLine("接続できませんでした。");

            }
        }
        public void Disconnect()
        {

            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(Info.RootUri);
            ftpWebRequest.Credentials = new NetworkCredential(Info.Username, Info.Password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.KeepAlive = false;


            try
            {
                using(FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    Console.WriteLine("接続を解除しました。");
                    this.Connecting = false;
                }
            }
            catch
            {
                

            }
        }

        public bool IsConnecting()
        {
            return Connecting;
        }


    }


}
