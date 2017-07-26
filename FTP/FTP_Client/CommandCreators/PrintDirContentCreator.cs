using FTP_Client.CommandCreators;
using FTP_Client.Commands;

namespace FTPClient.CommandCreators
{
    /// <summary>
    /// Create print dir content command its strCommand contains appropriate string  
    /// </summary>
    class PrintDirContentCreator : ComandCreator
    {
        Command command;
        public PrintDirContentCreator(ComandCreator creator) : base()
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
            if (strCommmand.Contains(PrintDirContent.CommandInStringFormat))
            {
                command = new PrintDirContent();
            }
            else if (Successor != null)
            {
                command = Successor.GetCommand(strCommmand);
            }
            return command;
        }
    }
}
