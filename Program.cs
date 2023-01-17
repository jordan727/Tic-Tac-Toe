// Tic Tac Toe | Jordan A
#nullable disable

Console.Clear();
var game = new Board();
while (game.main == true)
{
    game.Initialize();
    game.Prompt();
    
    while (game.complete == false)
    {
        game.Render();
        game.HandleInput();
        game.Update();
    }
} 
string among = "abc:def:asd";


public class Board
{
    public Tile[,] canvas;
    public bool complete;
    public bool main = true;
    public int markX;
    public int markY;
    public int player;

    
    // Creates the game board
    public void Initialize()
    {
        this.player = 1;
        this.canvas = new Tile[3, 3];
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                this.canvas[x, y] = new Tile(0, "-");
            }
        };
        markX = 1;
        markY = 1;
        this.canvas[markX, markY].Activate();
    }

    // Display prompt to begin or exit game
    public void Prompt()
    {
        Console.WriteLine("TIC-TAC-TOE");
        Console.WriteLine();
        Console.WriteLine("Press [Enter] to Begin");
        Console.WriteLine("Press [Esc] to Exit");
        EnterToStart();
    }
    // Display the game board in the console
    public void Render()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();
        Console.Write($"      |     |     ");
        Console.WriteLine();
        UpdateColor(0, 2);
        Console.Write($"   {this.canvas[0, 2].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("|");
        UpdateColor(1, 2);
        Console.Write($"  {this.canvas[1, 2].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("|");
        UpdateColor(2, 2);
        Console.Write($"  {this.canvas[2, 2].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
        Console.Write($" _____|_____|_____");
        Console.WriteLine();
        Console.Write($"      |     |     ");
        Console.WriteLine();
        UpdateColor(0, 1);
        Console.Write($"   {this.canvas[0, 1].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("|");
        UpdateColor(1, 1);
        Console.Write($"  {this.canvas[1, 1].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("|");
        UpdateColor(2, 1);
        Console.Write($"  {this.canvas[2, 1].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
        Console.Write($" _____|_____|_____");
        Console.WriteLine();
        Console.Write($"      |     |     ");
        Console.WriteLine();
        UpdateColor(0, 0);
        Console.Write($"   {this.canvas[0, 0].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("|");
        UpdateColor(1, 0);
        Console.Write($"  {this.canvas[1, 0].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("|");
        UpdateColor(2, 0);
        Console.Write($"  {this.canvas[2, 0].symbol}  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
        Console.Write($"      |     |     ");
        Console.WriteLine();
    }

    public void SwapTurns()
    {
        if (this.player == 1)
        {
            this.player = 2;
        }
        else
        {
            this.player = 1;
        }
    }
    public void UpdateColor(int x, int y)
    {
        if (this.canvas[x, y].active)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public void EnterToStart()
    {
        GetInput:
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    this.complete = false;
                    break;
                case ConsoleKey.Escape:
                    this.main = false;
                    this.complete = true;
                    break;
                default: goto GetInput;
            }
    }
    
    public void HandleInput()
    {
    GetInput:
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                    if (markX > 0)
                    {
                        this.canvas[markX, markY].Deactivate();
                        markX--;
                        this.canvas[markX, markY].Activate();
                        this.canvas[markX, markY].active = true;
                    }
                    break;
            case ConsoleKey.RightArrow:
                    if (markX < 2)
                    {
                        this.canvas[markX, markY].Deactivate();
                        markX++;
                        this.canvas[markX, markY].Activate();
                    }
                    break;
            case ConsoleKey.UpArrow:
                    if(markY < 2)
                    {
                        this.canvas[markX, markY].Deactivate();
                        markY++;
                        this.canvas[markX, markY].Activate();
                    }
                    break;
            case ConsoleKey.DownArrow:
                    if(markY > 0)
                    {
                        this.canvas[markX, markY].Deactivate();
                        markY--;
                        this.canvas[markX, markY].Activate();
                    }
                    break;
            case ConsoleKey.Enter:
                    if (this.canvas[markX, markY].value == 0)
                    {
                        SwapTurns();
                        this.canvas[markX, markY].updateTile(player);
                    }
                    break;
            case ConsoleKey.Escape:
                    this.complete = true;
                    break;
            default: goto GetInput;       
        }
    }
    // Updates the game board according to the inputs from HandleInput()
    public void Update()
    {
        for (int n = 0; n <= 2; n++)
        {
            if (this.canvas[0,n].symbol == this.canvas[1,n].symbol && this.canvas[2,n].symbol == this.canvas[0,n].symbol)
            {
                GameEndScreen(this.canvas[0,n], this.canvas[1,n], this.canvas[2,n]);
            }
            else if (this.canvas[n,0].symbol == this.canvas[n,1].symbol && this.canvas[n,2].symbol == this.canvas[n,0].symbol)
            {
                GameEndScreen(this.canvas[n,0], this.canvas[n,1], this.canvas[n,2]);
            }
        }

        if (this.canvas[0,0].symbol == this.canvas[1,1].symbol && this.canvas[2,2].symbol == this.canvas[0,0].symbol)
        {
            GameEndScreen(this.canvas[0,0], this.canvas[1,1], this.canvas[2,2]);
        }
        else if (this.canvas[2,0].symbol == this.canvas[1,1].symbol && this.canvas[0,2].symbol == this.canvas[2,0].symbol)
        {
            GameEndScreen(this.canvas[2,0], this.canvas[1,1], this.canvas[0,2]);
        }

        int fullCount = 0;
        for (int x = 0; x<=2; x++)
        {
            for (int y = 0; y<=2; y++)
            {
                if (this.canvas[x,y].symbol != "-")
                {
                    fullCount++;
                }
            }
        }
        if (fullCount == 9)
        {
            this.Render();
            Console.WriteLine("DRAW");
            this.complete = true;
        }
    }

    public void GameEndScreen(Tile tile1, Tile tile2, Tile tile3)
    {
        if (tile1.symbol != "-")
        {
            tile1.Activate();
            tile2.Activate();
            tile3.Activate();
            if (tile1.symbol == "X")
            {
                this.Render();
                Console.WriteLine();
                Console.WriteLine("X WINS");
                this.complete = true;
            }
            else if (tile1.symbol == "O")
            {
                this.Render();
                Console.WriteLine();
                Console.WriteLine("O WINS");
                this.complete = true;
                return;
            }
        }
    }
}

public class Tile
{
    public int value;
    public string symbol;
    public bool active;

    public Tile(int value, string symbol)
    {
        this.value = value;
        this.symbol = symbol;
    }
    
    public void updateTile(int value)
    {
        if (value == 1)
        {
            this.symbol = "O";
        }
        else if (value == 2)
        {
            this.symbol = "X";
        }
        this.value = value;
    }

    public void Activate()
    {
        this.active = true;
    }

    public void Deactivate()
    {
        this.active = false;
    }
}