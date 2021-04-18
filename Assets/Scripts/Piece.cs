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

    [SerializeField] protected Cell currentCell = null;
    protected RectTransform rectTransform = null;
    protected PieceManager pieceManager;
    Quaternion targetRotation = Quaternion.identity;

    [SerializeField] private Button button;

    protected void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(delegate { RotateCW(); });
    }

    protected void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);
    }

    public void Setup(PieceManager newPieceManager)
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
