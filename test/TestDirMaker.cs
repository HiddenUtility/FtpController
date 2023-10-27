using System;

namespace FtpController.test
{
    public class TestDirMaker
    {
        static public void Test(ConnectingInformation info)
        {

            DirectoryMaker maker = new DirectoryMaker(info);


            maker.MakeDirectory("test");


        }
    }
}
