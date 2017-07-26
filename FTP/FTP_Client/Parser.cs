namespace FTP_Client.CommandCreators
{
    /// <summary>
    /// Parse parametrs from one line
    /// </summary>
    internal class Parser
    {
        public static string GetParametres(string inputCommand, string strCommand)
        {
            inputCommand = inputCommand.Trim(' ');
            inputCommand = inputCommand.Replace(strCommand, " ");
            return inputCommand.Substring(inputCommand.IndexOf(" "));           
        }
    }
}