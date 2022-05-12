public class SudokuSolver
{
    int[,] startBoard;
    int[,] currentBoard;
    public SudokuSolver()
    {
        startBoard = LoadSudoku();

        currentBoard = startBoard;
    }
    public void PrintBoard()
    {
        for (int y = 0; y < currentBoard.GetLength(1); y++)
        {
            for (int x = 0; x < currentBoard.GetLength(0); x++)
            {
                if (currentBoard[x, y] <= 9)
                    Console.Write(currentBoard[x, y]);
                else if (currentBoard[x, y] == 15)
                    Console.Write(" ");

                // Create horizontal lines to divide
                if ((x + 1) % 3 == 0)
                {
                    Console.Write("|");
                }
            }
            Console.Write("\n");

            // Create vertical lines to divide
            if ((y + 1) % 3 == 0)
            {
                for (int i = 0; i < 12; i++)
                    if ((i + 1) % 4 != 0) Console.Write("-");
                    else Console.Write("+");
                Console.Write("\n");
            }
        }
    }
    private int[,] LoadSudoku()
    {
        string[] lines = System.IO.File.ReadAllLines(@"SudokuUnsolved.txt");
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