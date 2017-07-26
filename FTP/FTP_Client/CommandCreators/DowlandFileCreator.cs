using FTP_Client.CommandCreators;
using FTP_Client.Commands;

namespace FTPClient.CommandCreators
{
    /// <summary>
    /// Create dowland command its strCommand contains appropriate string  
    /// </summary>
    public class DowlandFileCreator : ComandCreator
    {
        string[] parametrs;
        string source;
        string destination;
        Command command;
        public DowlandFileCreator(ComandCreator creator) : base()
        {
            Successor = creator;
        }

        /// <summary>
        /// If it is possible crete command else give strCommand to other creator
        /// </summary>
        /// <param name="strCommmand">string containing command with parameters</param>
        /// <returns>command</returns>
        public override Command GetCommand(string strCommand)
        {
            if (strCommand.Contains(Download.CommandInStringFormat))
            {
                parametrs = Parser.GetParametres(strCommand, Download.CommandInStringFormat).Split(' ');
                source = parametrs[0];
                destination = parametrs[1];
                command = new Download(source, destination);
            }
            else if (Successor != null)
            {
                command = Successor.GetCommand(strCommand);
            }
            return command;
        }
    }

}
