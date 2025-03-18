// Chandler Wixom, 3/18/2025, Lab 7 Maze

Console.WriteLine("This is a maze game\nUse (up, down, left, right) or (w, a, s, d) to move");

string[] mapRows = File.ReadAllLines("..\\..\\..\\map.txt");

Console.ReadKey(true);

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
while(WaitKey() != 1);



// checks if you are hitting the bounds of the maze
// checks if you are at the top or left of the console 
// checks if you are at the bottom or right of the maze array
bool Bounds(string[] mazRows, string move)
{
    if ( move == "up" &&Console.CursorTop <= 0 )
    {
        return false;
    }
    else if ( move == "left" && Console.CursorLeft <= 0)
    {
        return false;
    }
    else if (move == "down" && mazRows.Length <= Console.CursorTop +1)
    {
        return false;
    }
    else if ( move == "right" && mazRows[0].Length <= Console.CursorLeft + 1)
    {
        return false;
    }
    else
    {
        return true;
    }
    

}

bool walls(string[] walls, string move)
{
    int left = Console.CursorLeft;
    int down = Console.CursorTop;
    if (move == "up" && mapRows[down - 1][left] == '#')
    {
        return false;
    }
    else if (move == "down" && mapRows[down +1][left] == '#')
    {
        return false;
    }
    else if (move == "left" && mapRows[down][left -1] == '#')
    {
        return false;
    }
    else if (move == "right" && mapRows[down][left+ 1] == '#')
    {
        return false;
    }
    else 
    {
        return true;
    }
}




// waits for an imput then checks it to see if its escape if it isnt and it is a movement key it sees if the move is allowed then moves if it is 
int WaitKey()
{
   var key = Console.ReadKey(true).Key;

   if (key == ConsoleKey.Escape) // quit
   {
     return 1;
   }
   else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) // up
    {
        if (walls(mapRows, "up") && Bounds(mapRows, "up"))
        Console.CursorTop--;
        return 0;
    }
    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) // down
    {
        if (walls(mapRows, "down") && Bounds(mapRows, "down"))
        Console.CursorTop++;
        return 0;
    }
    else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D) // left 
    {
        if (walls(mapRows, "right") && Bounds(mapRows, "right"))
        Console.CursorLeft++;
        return 0;
    }
    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A) // right
    {
        if (walls(mapRows, "left") && Bounds(mapRows, "left"))
        Console.CursorLeft--;
        return 0;
    }
    else 
    {
        return 0;
    }
}

