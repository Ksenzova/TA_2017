using System;
using FTP_Client.CommandCreators;

namespace FTP_Client.Commands
{
    /// <summary>
    /// Contains dowland command and its resiver
    /// </summary>
    class Download : Command
    {
        private string source;
        private string destination;
        public Download(string source,string  destination)
        {
            CommandInStringFormat = Resources.Downdoad;
            this.source = source;
            this.destination = destination;
        }
        public override void Execute()
        {
          FtpClient.Client.Dowland(source, destination);
        }
    }
}
