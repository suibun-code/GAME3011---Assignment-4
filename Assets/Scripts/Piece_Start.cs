using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece_Start : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("START");
    }

    // Update is called once per frame
    void Update()
    {
        Piece pieceConnected = currentCell.grid.allCells[currentCell.gridPosition.x, currentCell.gridPosition.y + 1].currentPiece;

        if (pieceConnected.down == true)
            pieceConnected.connected = true;
    }
}
