using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            {
                switch (HackingSkill.currentLevel)
                {
                    case 0:

                        break;

                    case 1:
                        SceneManager.LoadScene("Level 2");
                        HackingSkill.currentLevel = 2;
                        break;

                    case 2:
                        SceneManager.LoadScene("Level 3");
                        HackingSkill.currentLevel = 3;
                        break;

                    case 3:
                        SceneManager.LoadScene("VictoryLevel");
                        HackingSkill.currentLevel = 4;
                        break;
                }
            }
    }
}
