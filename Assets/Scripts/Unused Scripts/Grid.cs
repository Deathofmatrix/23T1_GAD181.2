using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class Grid
    {
        private int width;
        private int depth;
        private float cellSize;
        private int[,] gridArray;

        public Grid(int width, int depth, float cellSize)
        {
            this.width = width;
            this.depth = depth;
            this.cellSize = cellSize;

            gridArray = new int[width, depth];

            for (int z = 0; z < gridArray.GetLength(0); z++)
            {
                for (int x = 0; x < gridArray.GetLength(1); x++)
                {
                    Debug.Log(z + ", " + x);
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = GetWorldPosition(z,x);
                    cube.transform.localScale = new Vector3(cellSize - 0.1f, 0.1f, cellSize - 0.1f);
                    cube.name = z + ", " + x;

                    Debug.DrawLine(GetWorldPosition(z, x), GetWorldPosition(z, x + 1), Color.black, 100f);
                    Debug.DrawLine(GetWorldPosition(z, x), GetWorldPosition(z + 1, x), Color.black, 100f);
                }
            }

            Debug.DrawLine(GetWorldPosition(0, depth), GetWorldPosition(width, depth), Color.black, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, depth), Color.black, 100f);

            SetValue(2, 1, 10);
        }

        private void GetZX(Vector3 worldPosition, out int z, out int x)
        {
            z = Mathf.FloorToInt(worldPosition.z / cellSize);
            x = Mathf.FloorToInt(worldPosition.x / cellSize);
        }

        private Vector3 GetWorldPosition(int z, int x)
        {
            return new Vector3(z, 0, x) * cellSize;
        }

        public void SetValue(int z, int x, int value)
        {
            if (z >= 0 && x >= 0 && x < depth)
            {
                gridArray[z, x] = value;
            }
            
        }
        
        public void SetValue(Vector3 worldposition, int value)
        {
            int z, x;
            GetZX(worldposition,out z,out x);
            SetValue(z, x, value);
        }
    }
}

