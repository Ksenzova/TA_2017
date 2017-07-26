using FTP_Client.CommandCreators;

namespace FTP_Client.Commands
{
    /// <summary>
    /// Contains reseiver of command connect to ftp server and execute this command
    /// </summary>
    public class ConnectToFTPServer : Command
    {
        private string uri;
        private string userName;
        private string password;
        public ConnectToFTPServer(string uri, string userName, string password)
        {
            CommandInStringFormat = Resources.Connect;
            this.uri = uri;
            this.userName = userName;
            this.password = password;
        }

        public override void Execute()
        {
           FtpClient.Client.Connect(uri, userName, password);
        }
    }
}
