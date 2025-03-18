// Chandler Wixom, 3/18/2025, Lab 7 Maze

Console.WriteLine("This is a maze game\nUse (up, down, left, right) or (w, a, s, d) to move");

string[] mapRows = File.ReadAllLines("..\\..\\..\\map.txt");

Console.Clear();

foreach (var line in mapRows)
{
    Console.WriteLine(line);
}


Console.SetCursorPosition(0,0);

do
{
    WaitKey();
}
while(WaitKey() != 6);






int WaitKey()
{
   var key = Console.ReadKey(true).Key;
   if (key == ConsoleKey.Escape)
   {
     return 6;
   }
   else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
    {
        Console.CursorTop--;
        return 1;
    }
    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
    {
        Console.CursorTop++;
        return 2;
    }
    else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
    {
        Console.CursorLeft++;
        return 3;
    }
    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
    {
        Console.CursorLeft--;
        return 4;
    }
    else 
    {
        return 5;
    }
}

