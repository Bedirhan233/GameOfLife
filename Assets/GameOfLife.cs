using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{

    public GameObject cellPrefab;
    Cell[,] cells;

    float cellSize = 0.25f;
    int numberOfColums, numberOfRows;
    int spawnChancePercentage = 15;


    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 4;

        numberOfColums = (int)Mathf.Floor((Camera.main.orthographicSize * Camera.main.aspect * 2) / cellSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / cellSize);

        cells = new Cell[numberOfColums, numberOfRows];

   


        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {

                //Vector2 newPos = new Vector2(x * cellSize - Camera.main.orthographicSize * Camera.main.aspect, y
                //    * cellSize - Camera.main.orthographicSize);

                Vector2 Pos = new Vector2(x, y);

                var newCell = Instantiate(cellPrefab, Pos, Quaternion.identity);
                newCell.transform.localScale = Vector2.one * cellSize;
                cells[x, y] = newCell.GetComponent<Cell>();


                if (Random.Range(0, 100) < spawnChancePercentage)
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
        for (int y = 0; y < numberOfRows; y++)
        {

            for (int x = 0; x < numberOfColums; x++)
            {
                cells[x, y].UpdateStatus();
            }


        }
    }
}
