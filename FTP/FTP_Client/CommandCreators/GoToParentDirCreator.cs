using FTP_Client.CommandCreators;
using FTP_Client.Commands;

namespace FTPClient.CommandCreators
{
    /// <summary>
    /// Create go to parent dir command its strCommand contains appropriate string  
    /// </summary>
    class GoToParentDirCreator : ComandCreator
    {
        Command command;
        public GoToParentDirCreator(ComandCreator creator) : base()
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
            if (strCommmand.Contains(GoToParentDir.CommandInStringFormat))
            {
                command = new GoToParentDir();
            }
            else if (Successor != null)
            {
                command = Successor.GetCommand(strCommmand);
            }
            return command;
        }
    }
}
