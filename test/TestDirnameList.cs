using System;
using System.Net;

namespace FtpController.test
{
    public class TestDirnameList
    {
        static public void Test(ConnectingInformation info)
        {
            DirnamesExtractioin dirnamesExtractioin = new DirnamesExtractioin(info);

            string[] dirnames = dirnamesExtractioin.GetDirnames("");
            foreach (string dirname in dirnames)
            {
                Console.WriteLine(dirname);
            }

            Console.WriteLine("DirnamesExtractioin OK");





        }
    }
}
