using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public bool up = false;
    public bool right = false;
    public bool down = false;
    public bool left = false;

    public bool connected = false;

    [SerializeField] protected Cell currentCell = null;
    protected RectTransform rectTransform = null;
    protected PieceManager pieceManager;
    Quaternion targetRotation = Quaternion.identity;

    [SerializeField] private Button button;

    [SerializeField] public List<Piece> connectedPieces;

    protected void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(delegate { RotateCW(); });
    }

    protected void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.01f);

        connectedPieces = new List<Piece>();

        if (Manager.gridFinished)
        {
            Piece pieceConnected;

            if (currentCell.gridPosition.y + 1 < Grid.cellSizeY)
            {
                if (up == true)
                {
                    pieceConnected = currentCell.grid.allCells[currentCell.gridPosition.x, currentCell.gridPosition.y + 1].currentPiece;

                    if (pieceConnected.down == true)
                    {
                        connectedPieces.Add(pieceConnected);
                    }
                }
            }

            if (currentCell.gridPosition.x + 1 < Grid.cellSizeX)
            {
                if (right == true)
                {
                    pieceConnected = currentCell.grid.allCells[currentCell.gridPosition.x + 1, currentCell.gridPosition.y].currentPiece;

                    if (pieceConnected.left == true)
                    {
                        connectedPieces.Add(pieceConnected);
                    }
                }
            }

            if (currentCell.gridPosition.y - 1 >= 0)
            {
                if (down == true)
                {
                    pieceConnected = currentCell.grid.allCells[currentCell.gridPosition.x, currentCell.gridPosition.y - 1].currentPiece;

                    if (pieceConnected.up == true)
                    {
                        connectedPieces.Add(pieceConnected);
                    }
                }
            }

            if (currentCell.gridPosition.x - 1 >= 0)
            {
                if (left == true)
                {
                    pieceConnected = currentCell.grid.allCells[currentCell.gridPosition.x - 1, currentCell.gridPosition.y].currentPiece;

                    if (pieceConnected.right == true)
                    {
                        connectedPieces.Add(pieceConnected);
                    }
                }
            }

            if (connected)
            {
                currentCell.mOutlineImage.color = new Color(0.07f, 1f, 0f, 0.47f);

                foreach (Piece piece in connectedPieces)
                    piece.connected = true;
            }
            else
            {
                currentCell.mOutlineImage.color = currentCell.originalColor;
            }
        }
    }

    public virtual void Setup(PieceManager newPieceManager)
    {
        pieceManager = newPieceManager;

        rectTransform = GetComponent<RectTransform>();
    }

    public void SetCell(Cell newCell)
    {
        currentCell = newCell;
        currentCell.currentPiece = this;

        transform.position = newCell.transform.position;
        gameObject.SetActive(true); //???
    }

    public void RotateCW()
    {
        targetRotation *= Quaternion.Euler(0, 0, -90);

        bool up2 = up;
        bool right2 = right;
        bool down2 = down;
        bool left2 = left;

        up = left2;
        right = up2;
        down = right2;
        left = down2;

        foreach (Cell cell in currentCell.grid.allCells)
        {
            cell.currentPiece.connected = false;
        }

        AudioManager.instance.sound.Play();
    }

    public void RotateCCW()
    {
        targetRotation *= Quaternion.Euler(0, 0, 90);

        bool up2 = up;
        bool right2 = right;
        bool down2 = down;
        bool left2 = left;

        up = right2;
        left = up2;
        down = left2;
        right = down2;
    }
}
