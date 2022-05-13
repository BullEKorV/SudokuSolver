public class SudokuSolver
{
    int[,] startBoard;
    int[,] currentBoard;
    public SudokuSolver(string path)
    {
        startBoard = LoadSudoku(path);

        currentBoard = new int[startBoard.GetLength(0), startBoard.GetLength(1)];
        Array.Copy(startBoard, currentBoard, startBoard.Length);

        SolveBoard();
    }
    private void SolveBoard()
    {
        // Do the solving
        for (int c = 0; c < currentBoard.Length; c++)
        {
            int value = FindPossibleValues(NumToXY(c));

            if (CanChange(NumToXY(c)))
            {
                if (value == 15)
                {
                    currentBoard[NumToXY(c).x, NumToXY(c).y] = 15;
                    c--;
                    while (!CanChange(NumToXY(c)))
                    {
                        c--;
                    }
                    c--;
                }
                else if (value <= 9)
                {
                    currentBoard[NumToXY(c).x, NumToXY(c).y] = value;
                }
            }
            PrintBoard();
            Thread.Sleep(10);
        }
    }
    private int FindPossibleValues(Pos pos)
    {
        int originalValue = currentBoard[pos.x, pos.y];

        for (int value = originalValue <= 9 ? originalValue + 1 : 1; value <= 9; value++)
        {
            if (IsValid(value, pos))
            {
                return value;
            }
        }
        // Return a cell
        return 15;
    }
    private bool IsValid(int value, Pos pos)
    {
        // Check if valid on horizontal
        for (int x = 0; x < currentBoard.GetLength(0); x++)
        {
            if (currentBoard[x, pos.y] == value && pos.x != x) return false;
        }
        // Check if valid on vertical
        for (int y = 0; y < currentBoard.GetLength(0); y++)
        {
            if (currentBoard[pos.x, y] == value && pos.y != y) return false;
        }

        // Check if valid in box
        int blockY = pos.y / 3;
        int blockX = pos.x / 3;
        for (int y = 0 + blockY * 3; y < blockY * 3 + 3; y++)
        {
            for (int x = 0 + blockX * 3; x < blockX * 3 + 3; x++)
            {
                if (currentBoard[x, y] == value && pos.x != x && pos.y != y) return false;
            }
        }

        return true;
    }
    private bool CanChange(Pos pos)
    {
        if (startBoard[pos.x, pos.y] == 15) return true;
        return false;
    }
    private Pos NumToXY(int i)
    {
        int y = i / currentBoard.GetLength(0);
        int x = i - y * currentBoard.GetLength(0);

        return new Pos(x, y);
    }
    private void PrintBoard()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        for (int y = 0; y < currentBoard.GetLength(1); y++)
        {
            for (int x = 0; x < currentBoard.GetLength(0); x++)
            {
                if (currentBoard[x, y] <= 9)
                    Console.Write(currentBoard[x, y]);
                else if (currentBoard[x, y] == 15)
                    Console.Write(" ");

                // Create vertical lines to divide
                if ((x + 1) % 3 == 0)
                {
                    Console.Write("|");
                }
            }
            Console.Write("\n");

            // Create horizontal lines to divide
            if ((y + 1) % 3 == 0)
            {
                for (int i = 0; i < 12; i++)
                    if ((i + 1) % 4 != 0) Console.Write("-");
                    else Console.Write("+");
                Console.Write("\n");
            }
        }
    }
    private int[,] LoadSudoku(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);
        int[,] game = new int[9, 9];

        for (var y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                game[x, y] = lines[y][x] - '0';
            }
        }
        return game;
    }
}

struct Pos
{
    public int x;
    public int y;
    public Pos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}