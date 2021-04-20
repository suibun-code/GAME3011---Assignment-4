using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static bool canvasSwitched = false;

    public Canvas canvas;
    public Canvas canvas2;

    public Grid grid;
    public PieceManager pieceManager;

    public static bool gridFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        grid.Init();
        pieceManager.Init(grid);

        gridFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            canvas.enabled = true;
            canvas2.enabled = false;
            canvasSwitched = true;
        }
    }
}
