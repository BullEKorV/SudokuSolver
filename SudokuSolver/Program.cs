Console.WriteLine("Write path to sudoku you want to solve");

string pathName = Console.ReadLine();

while (!File.Exists(pathName + ".txt"))
{
    Console.WriteLine("Write path to sudoku you want to solve");

    pathName = Console.ReadLine();

}

SudokuSolver sudokuSolver = new SudokuSolver($@"{pathName}.txt");

Console.ReadLine();