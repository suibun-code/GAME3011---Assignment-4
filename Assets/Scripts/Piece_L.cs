using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece_L : Piece
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        up = true;
        right = true;

        down = false;
        left = false;

        GetComponent<Image>().sprite = Resources.Load<Sprite>("L");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
