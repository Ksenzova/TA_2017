namespace FTP_Client.CommandCreators
{
    /// <summary>
    /// Base class for all commands
    /// </summary>
    abstract public class Command
    {
        public static string CommandInStringFormat { get; set; }
        public FtpClient Client;
        public abstract void Execute();
    }

}