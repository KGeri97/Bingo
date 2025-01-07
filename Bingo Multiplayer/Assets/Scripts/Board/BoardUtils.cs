using System.Collections.Generic;
using UnityEngine;
public static class BoardUtils
{
    public static Board GenerateBoard(int width, int height, int maxNumber) {
        if (maxNumber < width * height) {
            Debug.LogWarning("There is not enough numbers to fill up the board");
            return null;
        }

        System.Random randomNumberGenerator = new();

        int[,] numberGrid = new int[height, width];
        List<int> numbers = new();

        for (int i = 1; i <= maxNumber; i++) {
            numbers.Add(i);
        }

        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {

                int randomIndex = randomNumberGenerator.Next(0, numbers.Count);

                numberGrid[i, j] = numbers[randomIndex];
                numbers.RemoveAt(randomIndex);

                //Debug.Log(numberGrid[i,j]);
            }
            //Debug.Log("New Row");
        }

        Board board = new Board(numberGrid);

        return board;
    }

    public static void DrawBoard(Board board, GameObject tilePrefab, GameObject rowPrefab, Transform parent) {
        //Destroy any already existing child before we draw a new board
        if (parent.childCount > 0) {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in parent) {
                children.Add(child);
            }

            foreach (Transform child in children) {
                Object.Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < board.Grid.GetLength(0); i++) {
            Transform rowTransform = Object.Instantiate(rowPrefab, parent).transform;

            for (int j = 0; j < board.Grid.GetLength(1); j++) {
                Tile tile = Object.Instantiate(tilePrefab, rowTransform).GetComponent<Tile>();
                tile.Initialize(j, i, board.Grid[i,j]);
            }
        }
    }
}
