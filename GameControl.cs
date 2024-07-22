using Snake.Enums;

namespace Snake;

public class GameControl
{
    public Direction direction { get; private set; }
    public bool closeRequested { get; private set; }

    public GameControl()
    {
        direction = Direction.Up; // Assuming a default direction
        closeRequested = false;
    }

    public void GetDirection()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow: direction = Direction.Up; break;
            case ConsoleKey.DownArrow: direction = Direction.Down; break;
            case ConsoleKey.LeftArrow: direction = Direction.Left; break;
            case ConsoleKey.RightArrow: direction = Direction.Right; break;
            case ConsoleKey.Escape: closeRequested = true; break;
        }
    }
    public void PositionFood(Tile[,] map, int width, int height)
    {
	    List<(int X, int Y)> possibleCoordinates = new();
	    for (int i = 0; i < width; i++)
	    {
	    	for (int j = 0; j < height; j++)
	    	{
	    		if (map[i, j] is Tile.Open)
	    		{
	    			possibleCoordinates.Add((i, j));
	    		}
	    	}
	    }
	    int index = Random.Shared.Next(possibleCoordinates.Count);
	    (int X, int Y) = possibleCoordinates[index];
	    map[X, Y] = Tile.Food;
	    Console.SetCursorPosition(X, Y);
	    Console.Write('+');
    }


}