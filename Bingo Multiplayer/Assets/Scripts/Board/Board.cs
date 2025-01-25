public class Board {
    /// <summary>
    /// Dimension 0: Rows; 
    /// Dimension 1: Columns;
    /// </summary>
    public int[,] Grid { get; private set; }

    public Board(int[,] grid) {
        Grid = grid;
    }

    public int[] GetRow(int rowNumber) {
        int gridWidth = Grid.GetLength(1);
        int[] row = new int[gridWidth];

        for (int i = 0; i < gridWidth; i++) {
            row[i] = Grid[rowNumber, i];
        }

        return row;
    }

    public int[] GetColumn(int columnNumber) {
        int gridHeight = Grid.GetLength(0);
        int[] column = new int[gridHeight];

        for (int i = 0; i < gridHeight; i++) {
            column[i] = Grid[i, columnNumber];
        }

        return column;
    }
}
