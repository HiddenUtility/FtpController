using System;


namespace FtpController
{
    public class ConnectingInformation
    {
        private readonly string ip;
        private readonly string port;
        private readonly string userName;
        private readonly string password;
        private readonly Uri rootUri;

        public ConnectingInformation(string ip, string port,string userName, string password)
        {
            this.ip = ip;
            this.port = port;
            this.userName = userName;
            this.password = password;
            this.rootUri = new Uri(string.Format("ftp://{0}:{1}/", ip, port));
        }

        public void ConfirmInfomation()
        {
            Console.WriteLine($"ip = {ip}\nport = {port}\nusername = {userName}\npassword = {password}");
        }

        public string Ip
        {
            get{return this.ip;}
        }
        public string Port
        {
            get{return this.port;}
        }


        public string Username
        {
            get{return this.userName;}
        }

        public string Password
        {
            get{return this.password;}
        }

        public Uri RootUri
        {
            get{return this.rootUri;}
        }

    }
}
