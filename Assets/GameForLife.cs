using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class GameForLife : MonoBehaviour
{

    int numberOfColums, numberOfRows;
    float cellSize = 0.25f;
    float alivePercentege = 20;
    Cell[,] cells;
    public GameObject cell;

    int neighbor;
    // Start is called before the first frame update
    void Start()
    {
        numberOfColums = (int)Mathf.Floor((Camera.main.orthographicSize * Camera.main.aspect * 2) / cellSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / cellSize);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 4;

        cells = new Cell[numberOfColums, numberOfRows];  
        
        for (int x = 0; x < numberOfColums; x++)
        {

            for (int y = 0; y < numberOfRows; y++)
            {
                Vector2 position = new Vector2(x, y);
                GameObject newCell = Instantiate(cell, position, Quaternion.identity);
                newCell.transform.localScale = Vector2.one * cellSize;
                cells[x, y] = newCell.GetComponent<Cell>();

                if (Random.Range(0, 100) < alivePercentege)
                {
                    cells[x, y].alive = true;

                    

                }

                cells[x, y].UpdateStatus();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int y = 1; y < numberOfRows; y++)
        {

            for (int x = 1; x < numberOfColums; x++)
            {
                neighbor = 0;

                if(x + 1 < numberOfColums && x - 1 >= 0 && y + 1 < numberOfRows && y - 1 >= 0)

                {
                    if (cells[x + 1, y].alive)
                    {
                        neighbor++;
                    }

                    if (cells[x - 1, y].alive)
                    {
                        neighbor++;
                    }

                    if (cells[x, y - 1].alive)
                    {
                        neighbor++;
                    }

                    if (cells[x, y + 1].alive)
                    {
                        neighbor++;                      
                    }


                    if (neighbor < 2)
                    {
                        cells[x, y].alive = false;
                    }

                    if(neighbor > 2)
                    {
                        cells[x, y].alive = true;
                    }

                    if (neighbor > 3)
                    {
                        cells[x, y].alive = false;
                    }
                    if (neighbor == 3)
                    {
                        cells[x, y].alive = true;
                        Instantiate(cell, cells[x, y].transform.position, Quaternion.identity);
                    }

                    cells[x, y].UpdateStatus();
            }


        }
    }
}
}
