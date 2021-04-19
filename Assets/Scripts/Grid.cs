using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public int cellSizeXHelper = 6;
    public int cellSizeYHelper = 6;

    [SerializeField] public static int cellSizeX = 6;
    [SerializeField] public static int cellSizeY = 6;

    public GameObject cellPrefab;
    public Cell[,] allCells;

    public void OnAfterDeserialize()
    {
        cellSizeX = cellSizeXHelper;
        cellSizeY = cellSizeYHelper;
    }

    public void OnBeforeSerialize()
    {
        //cellSizeXHelper = cellSizeX;
        //cellSizeYHelper = cellSizeY;
    }

    public void Init()
    {
        int count = 0;
        int num = 2;

        OnAfterDeserialize();

        allCells = new Cell[cellSizeX, cellSizeY];

        for (int i = 0; i < cellSizeX; i++)
            for (int j = 0; j < cellSizeY; j++)
            {
                num++;

                GameObject newCell = Instantiate(cellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector3(j * 100f, i * 100f);

                allCells[j, i] = newCell.GetComponent<Cell>();

                //Debug.Log("I: " + i + " J: " + j);

                if (count == cellSizeX)
                {
                    num++;
                    count = 0;
                }

                Debug.Log(num);

                if (num % 2 == 0)
                    allCells[j, i].GetComponent<Image>().color = new Color32(0, 198, 255, 120);

                allCells[j, i].Setup(new Vector2Int(j, i), this);

                count++;
            }
    }
}
