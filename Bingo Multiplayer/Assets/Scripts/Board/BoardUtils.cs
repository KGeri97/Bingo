using System.Collections.Generic;
using UnityEngine;
public static class BoardUtils
{
    private static GameObject _tilePrefab;
    private static GameObject _rowPrefab;

    public static void InitializePrefabs(GameObject tilePrefabReference, GameObject rowPrefabReference) {
        _tilePrefab = tilePrefabReference;
        _rowPrefab = rowPrefabReference;
    }

    public static Board GenerateBoard(int columns, int rows, int maxNumber) {
        if (maxNumber < columns * rows) {
            Debug.LogError("There is not enough numbers to fill up the board");
            return null;
        }

        TileData[,] numberGrid = new TileData[rows, columns];
        List<int> numbers = new();

        for (int i = 1; i <= maxNumber; i++) {
            numbers.Add(i);
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {

                int randomIndex = RNG.Next(0, numbers.Count);

                numberGrid[i, j].Value = numbers[randomIndex];
                numbers.RemoveAt(randomIndex);

                //Debug.Log(numberGrid[i,j]);
            }
            //Debug.Log("New Row");
        }

        Board board = new Board(numberGrid);

        return board;
    }

    /// <summary>
    /// Draws the board with acual values
    /// </summary>
    /// <param name="board"></param>
    /// <param name="parent"></param>
    public static void DrawBoard(Board board, Transform parent) {
        
        if (_tilePrefab == null || _rowPrefab == null) {
            Debug.LogError("Prefabs not initialized. Call InitializePrefabs before using DrawBoard.");
            return;
        }

        //Destroy any already existing child before we draw a new board
        if (parent.childCount > 0) {
            List<Transform> children = new List<Transform>();
            //Ensuring that the collection does not change before modifying the collection
            foreach (Transform child in parent) {
                children.Add(child);
            }

            foreach (Transform child in children) {
                Object.Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < GameManager.Instance.Rows; i++) {
            Transform rowTransform = Object.Instantiate(_rowPrefab, parent).transform;

            for (int j = 0; j < GameManager.Instance.Columns; j++) {
                Tile tile = Object.Instantiate(_tilePrefab, rowTransform).GetComponent<Tile>();
                tile.Initialize(j, i, board.Grid[i,j].Value, board.Grid[i,j].IsSelected);
            }
        }
    }

    ///// <summary>
    ///// Draws the board with placeholder values
    ///// </summary>
    ///// <param name="parent"></param>
    //public static void DrawBoard(Transform parent) {

    //    if (_tilePrefab == null || _rowPrefab == null) {
    //        Debug.LogError("Prefabs not initialized. Call InitializePrefabs before using DrawBoard.");
    //        return;
    //    }

    //    //Destroy any already existing child before we draw a new board
    //    if (parent.childCount > 0) {
    //        List<Transform> children = new List<Transform>();
    //        //Ensuring that the collection does not change before modifying the collection
    //        foreach (Transform child in parent) {
    //            children.Add(child);
    //        }

    //        foreach (Transform child in children) {
    //            Object.Destroy(child.gameObject);
    //        }
    //    }

    //    for (int i = 0; i < GameManager.Instance.Rows; i++) {
    //        Transform rowTransform = Object.Instantiate(_rowPrefab, parent).transform;

    //        for (int j = 0; j < GameManager.Instance.Columns; j++) {
    //            Tile tile = Object.Instantiate(_tilePrefab, rowTransform).GetComponent<Tile>();
    //            tile.Initialize(j, i, GameManager.Instance.Columns * i + j + 1);
    //        }
    //    }
    //}
}
