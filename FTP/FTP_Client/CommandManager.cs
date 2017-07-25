using FTP_Client.Commands;
using System.Collections.Generic;

namespace FTP_Client
{
    /// <summary>
    /// Get set of all available commands
    /// </summary>
    class CommandManager
    {
        public static HashSet<string> GetListOfAvailableCommands()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add(ConnectToFTPServer.CommandInStringFormat);
            set.Add(Download.CommandInStringFormat);
            set.Add(GoIntoFolders.CommandInStringFormat);
            set.Add(GoToParentDir.CommandInStringFormat);
            set.Add(PrintDirContent.CommandInStringFormat);
            return set;
        } 
    }
}
