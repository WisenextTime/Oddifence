using System;
using OddifenceCore.IO.File;
using OddifenceCore.IO.World;

var text = TextFileIO.ReadFromFile(@"d:\map.json");
var map = MapIO.LoadMap(text);
Console.WriteLine(MapIO.SaveMap(map));