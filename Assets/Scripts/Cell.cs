using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image mOutlineImage;
    public Piece currentPiece;
    public Vector2Int gridPosition = Vector2Int.zero;
    public Grid grid = null;
    public RectTransform rectTransform = null;

    public void Setup(Vector2Int newGridPosition, Grid newGrid)
    {
        gridPosition = newGridPosition;
        grid = newGrid;

        rectTransform = GetComponent<RectTransform>();
    }
}
