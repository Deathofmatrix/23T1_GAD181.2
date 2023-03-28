using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class BuildingType : MonoBehaviour
    {
        public enum TypeOfBuilding {Undefined, ClickIncrease, SpawnIncreaser, AdjacencyBonus };
        [SerializeField] private TypeOfBuilding typeOfBuilding = TypeOfBuilding.Undefined;

        [SerializeField] private string buildingName;

        [SerializeField] private int clickIncrease;
        [SerializeField] private int spawnIncrease;
        [SerializeField] private int adjacencyBonus;
        [SerializeField] private Vector3 originalPosition;

        [SerializeField] private bool isBuildingLocked = false;


        public TypeOfBuilding GetBuildingType()
        {
            return typeOfBuilding;
        }

        public int GetBuildingClick()
        {
            return clickIncrease;
        }
        public int GetBuildingSpawn()
        {
            return spawnIncrease;
        }
        public int GetBuildingAdjacency()
        {
            return adjacencyBonus;
        }
        public void SetOriginalPosition(Vector3 position)
        {
            originalPosition = position;
        }
        public Vector3 GetOriginalPosition()
        {
            return originalPosition;
        }
        public bool GetLockStatus()
        {
            return isBuildingLocked;
        }
        public void SetLockStatus(bool islocked)
        {
            isBuildingLocked = islocked;
        }

        public void SetBuildingStats(TypeOfBuilding buildingType, int increaseOrDecrease, bool isIncreased)
        {
            typeOfBuilding = buildingType;
            switch (buildingType)
            {
                case TypeOfBuilding.ClickIncrease:
                    if (isIncreased)
                    {
                        clickIncrease += increaseOrDecrease;
                    }
                    else if (!isIncreased)
                    {
                        clickIncrease -= increaseOrDecrease;
                    }
                    break;
                case TypeOfBuilding.SpawnIncreaser:
                    if (isIncreased)
                    {
                        spawnIncrease += increaseOrDecrease;
                    }
                    else if(!isIncreased)
                    {
                        spawnIncrease -= increaseOrDecrease;
                    }
                    break;
                case TypeOfBuilding.AdjacencyBonus:
                    if (isIncreased)
                    {
                        adjacencyBonus += increaseOrDecrease;
                    }
                    else if(!isIncreased)
                    {
                        adjacencyBonus -= increaseOrDecrease;
                    }
                    break;
                default:
                    Debug.LogError("Invalid Type passed through: ");
                    break;
            }
        }
        
        //private void OnMouseUp()
        //{
        //    transform.position = originalPosition;
        //}
    }
}


