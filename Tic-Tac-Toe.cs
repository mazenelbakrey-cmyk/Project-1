static void DrawBoard(string[,] board)
{
    Console.WriteLine(" ------------------- ");
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            Console.Write($" | {board[i, j]} ");
        }
        Console.WriteLine("|");
        Console.WriteLine(" ------------------- ");
    }
}

static string GetValidInput(string[,] board)
{
    while (true)
    {
        Console.Write("Choose position (1-9): ");
        string input = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == input)
                {
                    found = true;
                    break;
                }
            }

            if (found)
                break;
        }

        if (found)
        {
            return input;
        }
        else
        {
            Console.WriteLine("Invalid position or position already taken!");
        }
    }
}

static void Edit(ref string[,] board, string ch, string num)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[i, j] == num)
            {
                board[i, j] = ch;
                return;
            }
        }
    }
}

static bool CheckWinner(string[,] board)
{
    for (int i = 0; i < 3; i++)
    {
        if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
        {  return true; }
    }

    for (int i = 0; i < 3; i++)
    {
        if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
        { return true; }
    }

    if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        { return true; }

    if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
    { return true; }

    else
    {
        return false;
    }
}

static bool IsDraw(string[,] board)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[i, j] != "X" && board[i, j] != "O")
                return false;
        }
    }
    return true;
}

string[,] board =
{
    { "1", "2", "3" },
    { "4", "5", "6" },
    { "7", "8", "9" }
};

while (true)
{
    DrawBoard(board);

    Console.WriteLine("Player 1 Turn (X)");
    string p1 = GetValidInput(board);

    Edit(ref board, "X", p1);

    if (CheckWinner(board))
    {
        DrawBoard(board);
        Console.WriteLine(" Player 1 Wins!");
        break;
    }

    if (IsDraw(board))
    {
        DrawBoard(board);
        Console.WriteLine(" Draw!");
        break;
    }

    DrawBoard(board);

    Console.WriteLine("Player 2 Turn (O)");
    string p2 = GetValidInput(board);

    Edit(ref board, "O", p2);

    if (CheckWinner(board))
    {
        DrawBoard(board);
        Console.WriteLine(" Player 2 Wins!");
        break;
    }

    if (IsDraw(board))
    {
        DrawBoard(board);
        Console.WriteLine(" Draw!");
        break;
    }
}

Console.WriteLine("Game Over!");