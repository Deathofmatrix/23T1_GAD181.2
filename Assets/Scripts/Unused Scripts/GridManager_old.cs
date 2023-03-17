using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

namespace SheepGame.Chonnor
{
    public class GridManager_old : MonoBehaviour
    {
        [SerializeField] private float cellSize = 1f;

        [SerializeField] private int gridX;
        [SerializeField] private int gridZ;
        public Vector3 GetNearestPointOnGrid(Vector3 position)
        {
            position -= transform.localPosition;

            int xCount = Mathf.RoundToInt(position.x / cellSize);
            int yCount = Mathf.RoundToInt(position.y / cellSize);
            int zCount = Mathf.RoundToInt(position.z / cellSize);

            Vector3 result = new Vector3(
                (float) xCount * cellSize,
                (float) yCount * cellSize,
                (float) zCount * cellSize);

            result += transform.localPosition; 

            return result;
        }

        private void Start()
        {
            for (float x = 0; x < gridX; x += cellSize)
            {
                for (float z = 0; z < gridZ; z += cellSize)
                {
                    GameObject gameObject = new GameObject(x + ", " + z);
                    gameObject.transform.localPosition = new Vector3(x, 0f, z);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            for (float x = 0; x < gridX; x += cellSize)
            {
                for (float z = 0; z < gridZ; z += cellSize)
                {
                    var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                    //Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}
