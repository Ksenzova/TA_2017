using FTP_Client.CommandCreators;
using FTPClient.CommandCreators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FTP_Client
{
    /// <summary>
    /// Provide simple operations with ftp client
    /// </summary>
    public class FtpClient
    {
        public static FtpClient Client;

        private const string CannotGoToParrentDir = "You are in a root directory";
        private const string FolderIsntExist = "There is no such folder";
        private const string ResponseStatus = "Response status: {0} - {1}";
        private string host;
        private string user;
        private string password;

        // size of buffer to write donload file
        private const  int  BufferSize = 1024;
        public Command command;
        public ComandCreator commandCreator;

        private FtpClient(ComandCreator creator)
        {
            commandCreator = creator;
        }

        public static FtpClient GetFtpClient(ComandCreator creator)
        {
            if (Client==null)
            {
                Client = new FtpClient(creator);
            }
            return Client;
        }

        /// <summary>
        /// Read command from file
        /// </summary>
        /// <param name="path">file with commands</param>
        public void Execute(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string notParsedCommand = reader.ReadLine();
                while (notParsedCommand != null)
                {
                    command = commandCreator.GetCommand(notParsedCommand);
                    if (command != null)
                    {
                        command.Execute();
                    }
                    notParsedCommand = reader.ReadLine();
                }
            }
        }


        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="serverUri">uri to cinnect</param>
        public void Connect(string serverUri, string user, string password)
        {
            this.host = serverUri;
            this.user = user;
            this.password = password;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.EnableSsl = true;
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;
            request.Credentials = new NetworkCredential(user, password);
            Console.WriteLine("Connect to " + serverUri);
        }
        

        /// <summary>
        /// Dowland file
        /// </summary>
        /// <param name="filename">file to dowland</param>
        /// <param name="desPath"> destination path to dowland to</param>
        public void Dowland(string filename, string desPath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Concat(host, "/", filename));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream fileStream = new FileStream(desPath, FileMode.OpenOrCreate, FileAccess.Write);
            byte[] buffer = new byte[BufferSize];
            int bytesRead = responseStream.Read(buffer, 0, BufferSize);
            while (bytesRead > 0)
            {
                fileStream.Write(buffer, 0, bytesRead);
                bytesRead = responseStream.Read(buffer, 0, BufferSize);
            }

            fileStream.Close();
            Console.WriteLine(ResponseStatus, response.StatusCode, response.StatusDescription);
            response.Close();
        }

        /// <summary>
        /// Print files in current directory
        /// </summary>
        public void PrintDirContent()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> directories = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }
            foreach (var elem in directories)
            {
                Console.WriteLine(elem);
            }
            streamReader.Close();
        }


        /// <summary>
        /// Go to parent directory if it is possible
        /// </summary>
        public void GoToParentDir()
        {
            host = host.Trim('/');
            host = host.Remove(host.LastIndexOf("/"));
            try
            {
                Connect(host,user,password);               
            }
            catch
            {
                throw new Exception(CannotGoToParrentDir);
            }
        }


        /// <summary>
        /// Go to folder
        /// </summary>
        /// <param name="folder">name of folder to go to </param>
        /// <returns>current host</returns>
        public string  GoIntoFolders(string folder)
        {
            host = string.Concat(host, '/', folder,"/");
            try
            {
                Connect(host,user,password);
                return host;
            }
            catch
            {
                throw new Exception(FolderIsntExist);
            }
        }
    }
}


