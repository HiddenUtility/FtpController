using System;

namespace FtpController.test
{
    public class TestDirMaker
    {
        private const int WidthNumber = 3;

        static public void Test(ConnectingInformation info)
        {

            DirectoryMaker maker = new DirectoryMaker(info);

            for (int i = 0; i < 5; i++){
                maker.MakeDirectory($"test{i.ToString("D"+ WidthNumber)}");

            }

            Console.WriteLine("DirectoryMaker OK");



        }
    }
}
