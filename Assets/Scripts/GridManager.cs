using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GameObject cell;

        [SerializeField] private int width;
        //width == z
        [SerializeField] private int depth;
        //depth == x
        [SerializeField] private int cellSize;
        [SerializeField] private int[,] gridArray;

        private void Start()
        {
            SpawnGrid();
        }

        public void SpawnGrid()
        {
            gridArray = new int[depth, width];

            for (int z = 0; z < gridArray.GetLength(0); z++)
            {
                for (int x = 0; x < gridArray.GetLength(1); x++)
                {
                    GameObject newCell = Instantiate(cell);
                    Vector3 currentCellPos = GetPosition(z, x) + transform.position;
                    newCell.transform.position = currentCellPos;
                    newCell.transform.localScale = new Vector3(cellSize, 0.1f, cellSize);
                    newCell.name = z + ", " + x;
                    
                    newCell.transform.parent = this.transform;
                }
            }
        }
        private Vector3 GetPosition(int z, int x)
        {
            return new Vector3(z, 0, x) * cellSize;
        }
    }
}

