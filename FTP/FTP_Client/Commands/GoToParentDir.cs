using System;
using FTP_Client.CommandCreators;

namespace FTP_Client.Commands
{
    /// <summary>
    /// Execute Go to parent directory command and contains its resiver
    /// </summary>
    class GoToParentDir : Command
    {
        public GoToParentDir()
        {
            CommandInStringFormat = Resources.GoToParentDir;
        }
        public override void Execute()
        {
           FtpClient.Client.GoToparentDir();
        }
    }
}
