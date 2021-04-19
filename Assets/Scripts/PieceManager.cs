using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public GameObject piecePrefab;

    private List<Piece> piecesToPlace = null;

    public int whichPieceOrder = 0;

    private enum p
    {
        L_Piece,
        Straight_Piece,
        TRI_Piece,
        START_PIECE,
        END_PIECE
    }

    private int[] pieceOrder = new int[36]
    {
        (int) p.START_PIECE, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.L_Piece,
        (int) p.TRI_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.Straight_Piece, (int) p.L_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.END_PIECE, (int) p.L_Piece,
        (int) p.Straight_Piece, (int) p.TRI_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece
    };

    private int[] pieceOrder2 = new int[64]
    {
        (int) p.TRI_Piece, (int) p.TRI_Piece, (int) p.TRI_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.Straight_Piece,
        (int) p.Straight_Piece, (int) p.TRI_Piece, (int) p.TRI_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.END_PIECE, (int) p.TRI_Piece,
        (int) p.TRI_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.START_PIECE, (int) p.TRI_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.TRI_Piece, (int) p.L_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.Straight_Piece,
        (int) p.L_Piece, (int) p.TRI_Piece, (int) p.Straight_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.TRI_Piece, (int) p.TRI_Piece, (int) p.L_Piece,
        (int) p.TRI_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.Straight_Piece, (int) p.L_Piece, (int) p.Straight_Piece, (int) p.L_Piece,
    };

    private int[] pieceOrder3 = new int[196]
    {
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece,
        (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece, (int) p.L_Piece
    };

    private Dictionary<int, Type> pieceLibrary = new Dictionary<int, Type>()
    {
        {(int) p.L_Piece, typeof(Piece_L)},
        {(int) p.Straight_Piece, typeof(Piece_Straight)},
        {(int) p.TRI_Piece, typeof(Piece_Tri)},
        {(int) p.START_PIECE, typeof(Piece_Start)},
        {(int) p.END_PIECE, typeof(Piece_End)}
    };

    public void Init(Grid grid)
    {
        piecesToPlace = CreatePieces(grid);

        PlacePieces(piecesToPlace, grid);
    }

    private List<Piece> CreatePieces(Grid grid)
    {
        int[] pieceOrderToUse;

        switch (whichPieceOrder)
        {
            case 0:
                pieceOrderToUse = pieceOrder;
                break;

            case 1:
                pieceOrderToUse = pieceOrder2;
                break;

            case 2:
                pieceOrderToUse = pieceOrder3;
                break;

            default:
                pieceOrderToUse = pieceOrder;
                break;
        }

        List<Piece> newPieces = new List<Piece>();

        for (int i = 0; i < pieceOrderToUse.Length; i++)
        {
            GameObject newPieceObject = Instantiate(piecePrefab);
            newPieceObject.transform.SetParent(transform);

            newPieceObject.transform.localScale = new Vector3(1, 1, 1);
            newPieceObject.transform.localRotation = Quaternion.identity;

            int key = pieceOrderToUse[i];
            Type pieceType = pieceLibrary[key];

            Piece newPiece = (Piece)newPieceObject.AddComponent(pieceType);
            newPieces.Add(newPiece);

            newPiece.Setup(this);
        }

        return newPieces;
    }

    private void PlacePieces(List<Piece> pieces, Grid grid)
    {
        int num = 0;

        for (int i = 0; i < Grid.cellSizeX; i++)
        {
            for (int j = 0; j < Grid.cellSizeY; j++)
            {
                pieces[num].SetCell(grid.allCells[i, j]);
                num++;
            }
        }
    }
}
