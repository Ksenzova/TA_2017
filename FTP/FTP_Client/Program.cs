using FTPClient.CommandCreators;
using System;

/// <summary>
/// Provide simple command with ftp server
/// </summary>
namespace FTP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print List of available commands
            foreach (var Command in CommandManager.GetListOfAvailableCommands())
            {
                Console.WriteLine("usage command '" + Command + "'");
            }

            try
            {
                // path to read commands
                string path = "log.txt";

                ComandCreator creator = new ConnectToFTPServerCreator(
                                   new DowlandFileCreator(
                                   new GoIntoFolderCreator(
                                   new GoToParentDirCreator(
                                   new PrintDirContentCreator(null)))));

                FtpClient client = FtpClient.GetFtpClient(creator);
                client.Execute(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

