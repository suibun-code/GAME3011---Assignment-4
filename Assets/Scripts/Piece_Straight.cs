using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece_Straight : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        up = true;
        down = true;

        right = false;
        left = false;

        GetComponent<Image>().sprite = Resources.Load<Sprite>("STRAIGHT");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
