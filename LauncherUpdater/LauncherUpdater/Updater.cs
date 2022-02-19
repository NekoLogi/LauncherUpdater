using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace LauncherUpdater
{
    internal class Updater
    {
        public static string? VERSION_CLIENT { get; set; }
        public static string NO_VERSION = "No Version";

        private string VERSION_FILE = "Launcher/Launcher_Version.txt";


        public bool Start()
        {
            Init();

            if (!IsCurrentVersion())
            return false;

            StartLauncher();
            return true;
        }

        private void Init()
        {
            Task task1 = Task.Run(()
                => VERSION_CLIENT = GetClientVersion());

            Server server = new Server();
            Task task2 = Task.Run(()
                => server.Start(Server.Status.Version));

            task1.Wait();
            task2.Wait();
        }

        // Get Client (VERSION_FILE) for current version.
        private string GetClientVersion()
        {           
            if (!File.Exists(VERSION_FILE))
                return NO_VERSION;

            return File.ReadAllText(VERSION_FILE);
        }

        // Compare current client and server version.
        private bool IsCurrentVersion()
        {
            if (VERSION_CLIENT == Server.VERSION_SERVER)
                return true;
            return false;
        }

        // Update client launcher.
        public void UpdateClient()
        {
            Server server = new Server();

            Task downloader = Task.Run(()
                => server.Start(Server.Status.Update));

            downloader.Wait();

            InstallClient();
            SetVersion();
            StartLauncher();
        }

        // Install the downloaded client launcher.
        private void InstallClient()
        {
            if (File.Exists("Cache/launcher.zip"))
            {
                string zipPath = "Cache/launcher.zip";
                string extractpath = "Launcher";
                string cache = "Cache/Launcher";

                ZipFile.ExtractToDirectory(zipPath, cache);
                foreach (var cacheFile in Directory.GetFiles(cache))
                {
                    var cacheString = cacheFile.Split('\\');
                    foreach (var updateFile in Directory.GetFiles(extractpath))
                    {
                        var updateString = updateFile.Split('\\');
                        if (cacheString[cacheString.Length - 1] == updateString[updateString.Length - 1])
                        {
                            File.Delete($"{extractpath}/{cacheString[cacheString.Length - 1]}");
                        }
                    }
                }
                foreach (var cacheDir in Directory.GetDirectories(cache))
                {
                    var cacheGetDir = cacheDir.Split('\\');
                    foreach (var updateDir in Directory.GetDirectories(extractpath))
                    {
                        var updateGetDir = updateDir.Split('\\');
                        if (cacheGetDir[cacheGetDir.Length - 1] == updateGetDir[updateGetDir.Length - 1])
                        {
                            Directory.Delete($"{extractpath}/{cacheGetDir[cacheGetDir.Length - 1]}", true);
                        }
                    }
                }
                Directory.Delete(cache, true);
                ZipFile.ExtractToDirectory(zipPath, extractpath);

                File.Delete(zipPath);
            }
        }

        // Start launcher and close updater.
        private void StartLauncher()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(Directory.GetCurrentDirectory() + "\\Launcher\\ModLauncher.exe") { CreateNoWindow = true });
            Environment.Exit(0);
        }

        // Set new launcher version.
        private void SetVersion()
        {
            File.WriteAllText(VERSION_FILE, Server.VERSION_SERVER!);
        }
    }
}
