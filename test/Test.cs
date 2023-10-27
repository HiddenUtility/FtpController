using System;
using System.Data;

namespace FtpController.test
{

    class Program
    {
        static void Main(string[] args)
        {
            // コマンドライン引数を処理する
            foreach (string arg in args)
            {
                Console.WriteLine("引数: " + arg);
            }

            ConnectingInformation info = new ConnectingInformation("localhost", "21", "ftp", "Ftp00!");
            info.ConfirmInfomation();

            try{
                // Ftp 
                TestFtp.Test(info);
                // DirectoryMaker
                TestDirMaker.Test(info);
                // DirnameList
                TestDirnameList.Test(info);


            }catch(Exception ex){
                Console.WriteLine("エラーが発生しました:");
                Console.WriteLine("メッセージ: " + ex.Message);
                Console.WriteLine("例外の型: " + ex.GetType().FullName);
                Console.WriteLine("スタックトレース:\n" + ex.StackTrace);
            }


        Console.WriteLine("何か入力してEnterを押してください:");
        string userInput = Console.ReadLine();

        }
    }
}
