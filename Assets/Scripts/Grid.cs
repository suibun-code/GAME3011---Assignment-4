﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public static int cellSizeX = 6;
    public static int cellSizeY = 6;

    public GameObject cellPrefab;
    public Cell[,] allCells = new Cell[cellSizeX, cellSizeY];

    public void Init()
    {
        for (int i = 0; i < cellSizeX; i++)
        {
            for (int j = 0; j < cellSizeY; j++)
            {
                GameObject newCell = Instantiate(cellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector3(j * 100f, i * 100f);

                allCells[j, i] = newCell.GetComponent<Cell>();
                allCells[j, i].Setup(new Vector2Int(j, i), this);
            }
        }

        for (int i = 0; i < cellSizeX; i += 2)
        {
            for (int j = 0; j < cellSizeY; j++)
            {
                int offset = (j % 2 != 0) ? 0 : 1;
                int finalX = i + offset;

                allCells[finalX, j].GetComponent<Image>().color = new Color32(175, 175, 175, 25);
            }
        }
    }
}