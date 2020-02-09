SharpVPK:
========

A memory-friendly and fast parser for Valve's VPK files created in C#
========

Outputting the name of all entries to console:

```cs
var archive = new VpkArchive();
archive.Load(@"vpk_file_path.vpk");

foreach(var directory in archive.Directories)
	foreach (var entry in directory.Entries)
		Console.WriteLine(entry.ToString());

Console.WriteLine("Done");
Console.ReadLine();
```

which will return something similar to

![Image of Yaktocat](http://puu.sh/dQswx/af4843c5c7.png)

Writing all files to a directory:

```cs
var archive = new VpkArchive();
archive.Load(@"vpk_file_path.vpk");

foreach(var directory in archive.Directories)
	foreach (var entry in directory.Entries)
		File.WriteAllBytes(@"C:\Output\" + entry.Filename + "." + entry.Extension,
			entry.Data);

Console.WriteLine("Done");
Console.ReadLine();
```

# Command line extractor

```
rmdir /s /q %~dp0Unpacked
VpkExtract.exe "c:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2\hl2_textures_dir.vpk" "%~dp0Unpacked" 2
```
