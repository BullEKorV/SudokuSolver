public class SudokuSolver
{

    public SudokuSolver()
    {

    }
    public int[,] LoadSudoku()
    {
        string[] lines = System.IO.File.ReadAllLines(@"SudokuSolver/SudokuUnsolved.txt");
        int[,] game = new int[12, 12];

        for (var y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                // game[y, x] = lines[y][x];
                Console.WriteLine(lines[y][x]);
            }
        }
        return game;
    }
}