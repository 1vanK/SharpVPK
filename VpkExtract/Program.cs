// Command line VPK extractor

using System;
using System.IO;
using SharpVPK;


namespace VpkExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: VpkExtract <vpk_file> <output_dir> <version>");
                return;
            }

            Directory.CreateDirectory(args[1]);

            var archive = new VpkArchive();
            archive.Load(args[0], args[2] == "1" ? VpkVersions.Versions.V1 : VpkVersions.Versions.V2);

            foreach (var directory in archive.Directories)
            {
                foreach (var entry in directory.Entries)
                {
                    string dirPath = Path.Combine(args[1], entry.Path);
                    Directory.CreateDirectory(dirPath);

                    string path = entry.Path + "/" + entry.Filename + "." + entry.Extension;
                    Console.WriteLine(path);
                    path = Path.Combine(args[1], path);

                    File.WriteAllBytes(path, entry.Data);
                }
            }

            Console.WriteLine("Done");
        }
    }
}
