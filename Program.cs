// Chandler Wixom, 3/18/2025, Lab 7 Maze

Console.WriteLine("This is a maze game\nUse (up, down, left, right) or (w, a, s, d) to move");

string[] mapRows = File.ReadAllLines("..\\..\\..\\map.txt");

Console.Clear();

foreach (var line in mapRows)
{
    Console.WriteLine(line);
}

