using FTP_Client.CommandCreators;

namespace FTPClient.CommandCreators
{
    /// <summary>
    /// Base class for commandcreators
    /// </summary>
    public abstract class ComandCreator
    {
        public ComandCreator Successor { get; set; }
        public abstract Command GetCommand(string strCommand);
    }
}
