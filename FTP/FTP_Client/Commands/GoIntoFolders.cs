using FTP_Client.CommandCreators;
using System;

namespace FTP_Client.Commands 
{
    /// <summary>
    /// Execute Go into folder commsnd and contains resiver of this command
    /// </summary>
    class GoIntoFolders : Command
    {
        private string folder;
        public GoIntoFolders( string folder)
        {
            CommandInStringFormat = Resources.GoIntoFolder;
            this.folder = folder;
        }
        public override void Execute()
        {
          FtpClient.Client.GoIntoFolders(folder);
        }
    }
}
