using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class GameForLife : MonoBehaviour
{

    Cell[,] cells;
    bool shouldLive = true;
    float timer;
    int numberOfColums, numberOfRows;
    int neighbor;


    public GameObject cell;

    public float cellSize = 0.25f;
    public float alivePercentege = 10;
    public float countDown = 3;
    public bool isRuning = true;
    


    // Start is called before the first frame update
    void Start()
    {
        timer = countDown;
        QualitySettings.vSyncCount = 0;
        CreateRows();
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if(isRuning) 
        {
        RuningGameOfLife();
        }
    }

    private void RuningGameOfLife()
    {
        

        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                neighbor = 0;
                cells[x, y].transform.localScale = Vector2.one * cellSize;
                if (x + 1 < numberOfColums && x - 1 >= 0 && y + 1 < numberOfRows && y - 1 >= 0)
                {
                    CalculateNeighbor(y, x);
                    SetRules(y, x);
                }
            }
        }
        ExecuteRules();
    }

    private void CreateRows()
    {

        numberOfColums = (int)Mathf.Floor((Camera.main.orthographicSize * Camera.main.aspect * 2) / cellSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / cellSize);

        cells = new Cell[numberOfColums, numberOfRows];


        for (int x = 0; x < numberOfColums; x++)
        {

            for (int y = 0; y < numberOfRows; y++)
            {

                Vector2 newPos = new Vector2(x * cellSize - Camera.main.orthographicSize * Camera.main.aspect, y
                    * cellSize - Camera.main.orthographicSize);


                GameObject newCell = Instantiate(cell, newPos, Quaternion.identity);
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
    private void CalculateNeighbor(int y, int x)
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

        // diagonal

        if (cells[x + 1, y - 1].alive)
        {
            neighbor++;
        }

        if (cells[x - 1, y - 1].alive)
        {
            neighbor++;
        }

        if (cells[x - 1, y + 1].alive)
        {
            neighbor++;
        }

        if (cells[x + 1, y + 1].alive)
        {
            neighbor++;
        }

        
    }

    private void SetRules(int y, int x)
    {
        

        if (neighbor < 2)
        {
            cells[x, y].shouldLive = false;

        }

        if (neighbor == 3)
        {
            cells[x, y].shouldLive = true;
        }

        if (neighbor > 3)
        {
            cells[x, y].shouldLive = false;
        }
    }

    private void ExecuteRules()
    {
        for (int y = 0; y < numberOfRows; y++)
        {

            for (int x = 0; x < numberOfColums; x++)
            {

                if (x + 1 < numberOfColums && x - 1 >= 0 && y + 1 < numberOfRows && y - 1 >= 0)

                {

                    if (cells[x, y].shouldLive == true)
                    {
                        cells[x, y].alive = true;
                    }

                    if (cells[x, y].shouldLive == false)
                    {
                        cells[x, y].alive = false;
                    }


                    if (cells[x, y].alive == false)
                    {

                        
                    }

                    cells[x, y].UpdateStatus();

                }


            }
        }
    }
}
