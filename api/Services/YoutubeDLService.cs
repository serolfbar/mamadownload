using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;
using System.IO;
using api.Interfaces;

namespace api.Services
{
    public class YoutubeDLService : IDownloadService 
    {
        public void Download(string youtubeUrl) 
        {
            try 
            {
                var outputDirectoryPath = "/home/alexander/Downloads/MamaDownloads/";
                if(Directory.Exists(outputDirectoryPath)) 
                {
                    Directory.CreateDirectory(outputDirectoryPath);
                }

                var arguments = $"--rm-cache-dir -o {outputDirectoryPath}%(title)s.%(ext)s --audio-format mp3 -x { youtubeUrl }";
                ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "youtube-dl", Arguments = arguments, };
                Process process = new Process() { StartInfo = startInfo };
                process.Start();
                process.WaitForExit();
            }
            catch(Exception exception) 
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

