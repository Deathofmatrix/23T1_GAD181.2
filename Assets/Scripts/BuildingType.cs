using System.Collections;
using System.Collections.Generic;

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

        public void SetBuildingStats(TypeOfBuilding buildingType, int increase)
        {
            typeOfBuilding = buildingType;
            switch (buildingType)
            {
                case TypeOfBuilding.ClickIncrease:
                    clickIncrease = increase;
                    break;
                case TypeOfBuilding.SpawnIncreaser:
                    spawnIncrease = increase;
                    break;
                case TypeOfBuilding.AdjacencyBonus:
                    adjacencyBonus = increase;
                    break;
                default:
                    Debug.LogError("Invalid Type passed through: ");
                    break;


            }
        }
    }
}


