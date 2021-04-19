using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece_End : Piece
{
    void Start()
    {
        up = true;
        down = true;

        right = false;
        left = false;

        GetComponent<Image>().sprite = Resources.Load<Sprite>("END");
    }
    
    void Update()
    {
        Piece pieceConnected = currentCell.grid.allCells[currentCell.gridPosition.x, currentCell.gridPosition.y + 1].currentPiece;

        if (pieceConnected.down == true)
            if (pieceConnected.connected == true)
                Debug.Log("VICTORY");
    }
}
