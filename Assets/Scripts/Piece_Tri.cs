using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece_Tri : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        up = true;
        right = true;
        down = true;

        left = false;

        GetComponent<Image>().sprite = Resources.Load<Sprite>("TRI");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
