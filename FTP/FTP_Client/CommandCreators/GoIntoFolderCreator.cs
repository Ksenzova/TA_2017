using FTP_Client.CommandCreators;
using FTP_Client.Commands;

namespace FTPClient.CommandCreators
{
    /// <summary>
    /// Create go into folder command its strCommand contains appropriate string  
    /// </summary>
    class GoIntoFolderCreator : ComandCreator
    {
        string folder;
        Command command;
        public GoIntoFolderCreator(ComandCreator creator) : base()
        {
            Successor = creator;
        }

        /// <summary>
        /// If it is possible crete command else give strCommand to other creator
        /// </summary>
        /// <param name="strCommmand">string containing command with parameters</param>
        /// <returns>command</returns>
        public override Command GetCommand(string strCommmand)
        {
            if (strCommmand.Contains(GoIntoFolders.CommandInStringFormat))
            {
                folder = Parser.GetParametres(strCommmand,GoIntoFolders.CommandInStringFormat);
                command = new GoIntoFolders(folder);
            }
            else if (Successor != null)
            {
                command = Successor.GetCommand(strCommmand);
            }
            return command;
        }
    }
}
