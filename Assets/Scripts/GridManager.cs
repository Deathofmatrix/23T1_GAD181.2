using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class GridManager : MonoBehaviour
    {
        public static bool isBuildingReadyToSpawn = true;

        [SerializeField] private GameObject cell;

        [SerializeField] private int width;
        //width == z
        [SerializeField] private int depth;
        //depth == x
        [SerializeField] private int cellSize;
        [SerializeField] private int[,] gridArray;

        [SerializeField] private int numberOfSheepToSpawn = 1;


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
                    newCell.GetComponent<Cell>().SetCellNumber(z, x);
                    
                    newCell.transform.parent = this.transform;
                }
            }
        }
        private Vector3 GetPosition(int z, int x)
        {
            return new Vector3(z, 0, x) * cellSize;
        }

        /// <summary>
        /// This works, try not to rework too much
        /// </summary>
        /// <param name="click">this is the click variable</param>
        /// <param name="isPositive"></param>
        public void SetClickLevel(int click, bool isPositive)
        {
            if (isPositive)
            {
                numberOfSheepToSpawn += click;
                if (numberOfSheepToSpawn < 5)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder();
                }
                else if (numberOfSheepToSpawn < 9)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 5;
                }
                else if (numberOfSheepToSpawn < 13)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 25;
                }
            }
            else if (!isPositive)
            {
                numberOfSheepToSpawn -= click;
                if (numberOfSheepToSpawn < 5)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder();
                }
                else if (numberOfSheepToSpawn < 9)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 5;
                }
                else if (numberOfSheepToSpawn < 13)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 25;
                }
            }
        }
        private int Remainder()
        {
            int remainder = numberOfSheepToSpawn % 4;
            if (remainder == 0)
            {
                remainder = 4;
            }
            return remainder;
        }

        /// <summary>
        /// This Method gets called when a building is placed
        /// </summary>
        private void IterateThroughGrid()
        {
            // TODO 22/03 11:13 come back to this later (grid update)
            //loop through every cell in the grid (2 for loops)
            //for each cell check if it has a building
            //if it has a building check if its a buffing building and apply to its neighbors
            //Update click / spawn
        }
    }
}