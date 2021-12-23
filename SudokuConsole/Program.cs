var row = new bool[9,9];
var col = new bool[9,9];
var cell = new bool[3,3,9];

void SolveSudoku(ref char[,] board)
{
    for (var i = 0; i < 9; i++)
    {
        for (var j = 0; j < 9; j++)
        {
            if (board[i, j] == '.') continue;
            var t = board[i, j] - '1';
            row[i, t] = col[j, t] = cell[i / 3, j / 3, t] = true;
        }
    }
    Dfs(board, 0, 0);
}

bool Dfs(char[,] board, int x, int y)
{
    while (true)
    {
        if (y == 9)
        {
            x += 1;
            y = 0;
            continue;
        }

        if (x == 9) return true;
        if (board[x, y] != '.')
        {
            y += 1;
            continue;
        }

        for (var i = 0; i < 9; i++)
        {
            if (row[x, i] || col[y, i] || cell[x / 3, y / 3, i]) continue;
            board[x, y] = (char)(i + '1');
            row[x, i] = col[y, i] = cell[x / 3, y / 3, i] = true;
            if (Dfs(board, x, y + 1)) break;
            board[x, y] = '.';
            row[x, i] = col[y, i] = cell[x / 3, y / 3, i] = false;
        }

        return board[x, y] != '.';
    }
}

var board = new [,]
{
    { '.', '.', '.', '.', '.', '7', '.', '.', '1' },
    { '.', '.', '6', '.', '.', '3', '.', '.', '.' },
    { '.', '9', '.', '6', '1', '.', '.', '2', '.' },
    { '.', '.', '.', '.', '.', '6', '.', '.', '.' },
    { '.', '.', '9', '4', '8', '.', '.', '.', '3' },
    { '.', '2', '.', '.', '.', '.', '5', '.', '.' },
    { '.', '.', '4', '1', '9', '.', '.', '.', '8' },
    { '.', '.', '.', '.', '7', '.', '.', '.', '.' },
    { '8', '.', '.', '.', '.', '.', '.', '3', '.' }
};

SolveSudoku(ref board);
var i = 1;
foreach (var cols in board)
{
    Console.Write(cols);
    if (i % 9 == 0)
        Console.WriteLine();
    i++;
}
