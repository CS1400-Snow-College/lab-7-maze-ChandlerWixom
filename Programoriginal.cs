// Chandler Wixom, 3/18/2025, Lab 7 Maze
// I realize now as I finish this that I probably should have seperated reading the keys and moving but whatever
Console.Clear();
Console.WriteLine("This is a maze game\nUse (up, down, left, right) or (w, a, s, d) to move\nTry to reach the *\nWhat level would you like to play?\n1, 2 or test");


string level = Console.ReadLine();



string[] mapRows = File.ReadAllLines($"..\\..\\..\\map{level}.txt");

Console.Clear();

foreach (var line in mapRows)
{
    Console.WriteLine(line);
}
Console.SetCursorPosition(0,0);



do
{
    WaitKey();
    if (WaitKey() == 1)
    {
    Console.Clear();
    Console.WriteLine("You did it, you beat the maze!!!");
    Console.ReadKey(true);
    
    
    }
    if (WaitKey()==2)
    {
        Console.Clear();
        Console.WriteLine("You have quit");
        Console.ReadKey(true);
        break;
        
    }
}
while(WaitKey() == 0);












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


// checks if the next move would put you into a wall and returns false if it would
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
  
    if (WinCheck())
    {
        return 1;
    }
   var key = Console.ReadKey(true).Key;

   if (key == ConsoleKey.Escape) // quit
   {
     return 2;
   }
   else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) // up
    {
        if ( Bounds(mapRows, "up") && walls(mapRows, "up") )
        Console.CursorTop--;
        return 0;
    }
    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) // down
    {
        if (  Bounds(mapRows, "down") && walls(mapRows, "down"))
        Console.CursorTop++;
        return 0;
    }
    else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D) // left 
    {
        if (  Bounds(mapRows, "right") && walls(mapRows, "right"))
        Console.CursorLeft++;
        return 0;
    }
    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A) // right
    {
        if ( Bounds(mapRows, "left") && walls(mapRows, "left") )
        Console.CursorLeft--;
        return 0;
    }
    else 
    {
        return 0;
    }
    
    
    
}

bool WinCheck()
{
    if (mapRows[Console.CursorTop][Console.CursorLeft] == '*')
    {
        
        return true;
    }
    else 
    {
        return false;
    }
}