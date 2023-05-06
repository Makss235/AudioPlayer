TagLib.File tagFile = TagLib.File.Create("D:\\Projects\\VS_CSharp\\AudioPlayer\\Tests\\ConsoleTest\\bin\\Debug\\net6.0\\Don't Cry Tonight.mp3");
string artist = tagFile.Tag.FirstAlbumArtist;
string album = tagFile.Tag.Album;
string title = tagFile.Properties.Duration.ToString("mm\\:ss");
Console.WriteLine(title);
Console.WriteLine(album);
Console.WriteLine(artist);
