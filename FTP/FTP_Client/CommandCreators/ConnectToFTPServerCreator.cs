using FTP_Client.CommandCreators;
using FTP_Client.Commands;

namespace FTPClient.CommandCreators
{
    /// <summary>
    /// Create connect to ftp server command its strCommand contains appropriate string  
    /// </summary>
    public class ConnectToFTPServerCreator : ComandCreator
    {
        string[] parametrs;
        string uri;
        string user;
        string password;
        Command command;

        public ConnectToFTPServerCreator(ComandCreator creator) : base()
        {
            Successor = creator;
        }

        /// <summary>
        /// If it is possible crete command else give strCommand to other creator
        /// </summary>
        /// <param name="strCommand">string containing command with parameters</param>
        /// <returns>command</returns>
        public override Command GetCommand(string strCommand)
        {
            if (strCommand.Contains(ConnectToFTPServer.CommandInStringFormat))
            {
                parametrs = Parser.GetParametres(strCommand,ConnectToFTPServer.CommandInStringFormat).Split(' ');
                uri = parametrs[0];
                user = parametrs[1];
                password = parametrs[2];
                command = new ConnectToFTPServer(uri,user,password);
            }
            else if (Successor != null)
            {
                command = Successor.GetCommand(strCommand);
            }
            return command;
        }
    }
}
