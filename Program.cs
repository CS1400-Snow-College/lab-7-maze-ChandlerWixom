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



bool CanMove(string[] mazRows, string move)
{
    if (Console.CursorTop <= 0 && move == "up")
    {
        return false;
    }
    else if (Console.CursorLeft <= 0 && move == "left")
    {
        return false;
    }
    else if (mazRows.Length <= Console.CursorTop +1 && move == "down")
    {
        return false;
    }
    else if (mazRows[0].Length <= Console.CursorLeft + 1 && move == "right")
    {
        return false;
    }
    else
    {
        return true;
    }
    

}








int WaitKey()
{
   var key = Console.ReadKey(true).Key;
   if (key == ConsoleKey.Escape)
   {
     return 1;
   }
   else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
    {
        if (CanMove(mapRows, "up"))
        Console.CursorTop--;
        return 0;
    }
    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
    {
        if (CanMove(mapRows, "down"))
        Console.CursorTop++;
        return 0;
    }
    else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
    {
        if (CanMove(mapRows, "right"))
        Console.CursorLeft++;
        return 0;
    }
    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
    {
        if (CanMove(mapRows, "left"))
        Console.CursorLeft--;
        return 0;
    }
    else 
    {
        return 0;
    }
}

