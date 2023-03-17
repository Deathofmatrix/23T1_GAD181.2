using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SheepGame.Chonnor
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Vector2 cellNumber;
        [SerializeField] private GameObject gManager;

        private int colliderInTrigger;
        private Rigidbody buildingRB;
        private BuildingType building;

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
            gManager = GameObject.Find("Grid");
            FindAdjacent();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Building") && colliderInTrigger <= 1)
            {
                other.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
                Debug.Log("Building entered" + this.name);
                buildingRB = other.GetComponent<Rigidbody>();
                buildingRB.constraints = RigidbodyConstraints.FreezePosition;
                buildingRB.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            colliderInTrigger++;
            if (other.gameObject.CompareTag("Building") && colliderInTrigger == 1)
            {
                building = other.GetComponent<BuildingType>();
                if (building.GetBuildingClickStatus())
                {
                    SheepSpawner.clickAmount += building.GetBuildingClick();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            colliderInTrigger--;
            if (other.gameObject.CompareTag("Building") && colliderInTrigger == 0)
            {
                if (building.GetBuildingClickStatus())
                {
                    SheepSpawner.clickAmount -= building.GetBuildingClick();
                    building = null;
                }
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
