public class Board {
    /// <summary>
    /// Dimension 0: Columns; 
    /// Dimension 1: Rows;
    /// </summary>
    public TileData[,] Grid { get; private set; }

    public Board(int columns, int rows) {
        TileData[,] grid = new TileData[columns, rows];
        for (int i = 0; i < GameManager.Instance.Rows; i++) {
            for (int j = 0; j < GameManager.Instance.Columns; j++) {
                grid[i, j] = new TileData(GameManager.Instance.Columns * i + j + 1);
            }
        }

        Grid = grid;
    }

    public Board(TileData[,] grid) {
        Grid = grid;
    }

    public TileData[] GetRow(int rowNumber) {
        int gridWidth = Grid.GetLength(1);
        TileData[] row = new TileData[gridWidth];

        for (int i = 0; i < gridWidth; i++) {
            row[i] = Grid[rowNumber, i];
        }

        return row;
    }

    public TileData[] GetColumn(int columnNumber) {
        int gridHeight = Grid.GetLength(0);
        TileData[] column = new TileData[gridHeight];

        for (int i = 0; i < gridHeight; i++) {
            column[i] = Grid[i, columnNumber];
        }

        return column;
    }
}
