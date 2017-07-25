using System;
using FTP_Client.CommandCreators;

namespace FTP_Client.Commands
{
    /// <summary>
    /// Execute Print directiry content and its resiver
    /// </summary>
    class PrintDirContent : Command
    {
        public PrintDirContent()
        {
            CommandInStringFormat = Resources.PrintDirContent;
        }
        public override void Execute()
        {
            FtpClient.Client.PrintDirContent();
        }
    }
}
