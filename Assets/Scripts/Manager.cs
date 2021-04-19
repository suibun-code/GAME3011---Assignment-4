using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
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
        
    }
}
