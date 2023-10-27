using System;

namespace FtpController.test
{
    public class TestFtp
    {

        static public void Test(ConnectingInformation info)
        {

            Ftp ftp = new Ftp(info);
            ftp.Connect();
            ftp.Disconnect();

        }
        
    }
}
