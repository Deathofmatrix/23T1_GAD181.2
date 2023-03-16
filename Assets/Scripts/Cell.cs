using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Vector2 cellNumber;

        [SerializeField] GameObject topLeft;
        [SerializeField] GameObject topMiddle;
        [SerializeField] GameObject topRight;
        [SerializeField] GameObject Left;
        [SerializeField] GameObject Right;
        [SerializeField] GameObject bottomLeft;
        [SerializeField] GameObject bottomMiddle;
        [SerializeField] GameObject bottomRight;

        private void Start()
        {
            FindAdjacent();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Building"))
            {
                other.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
                Debug.Log("Building entered" + this.name);
            }
        }
        public void SetCellNumber(int x, int z)
        {
            cellNumber = new Vector2(x, z);
        }

        private void FindAdjacent()
        {
            float y = this.cellNumber.x;
            float x = this.cellNumber.y;

            topLeft = GameObject.Find((x - 1) + ", " + (y - 1));
            topMiddle = GameObject.Find((x - 1) + ", " + (y));
            topRight = GameObject.Find((x - 1) + ", " + (y + 1));
            Left = GameObject.Find((x) + ", " + (y - 1));
            Right = GameObject.Find((x) + ", " + (y + 1));
            bottomLeft = GameObject.Find((x + 1) + ", " + (y - 1));
            bottomMiddle = GameObject.Find((x + 1) + ", " + (y));
            bottomRight = GameObject.Find((x + 1) + ", " + (y + 1));
        }
    }
}
