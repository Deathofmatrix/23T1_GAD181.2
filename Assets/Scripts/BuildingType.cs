using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class BuildingType : MonoBehaviour
    {
        [SerializeField] private string buildingName;

        [SerializeField] private bool isClickIncreaser;
        [SerializeField] private bool isSpawnkIncreaser;
        [SerializeField] private bool isAdjacencyBonus;

        [SerializeField] private float clickIncrease;
        [SerializeField] private float spawnIncrease;
        [SerializeField] private float adjacencyBonus;

        public bool GetBuildingClickStatus()
        {
            return isClickIncreaser;
        }
        public bool GetBuildingSpawnStatus()
        {
            return isSpawnkIncreaser;
        }
        public bool GetBuildingAdjacencyStatus()
        {
            return isAdjacencyBonus;
        }

        public float GetBuildingClick()
        {
            return clickIncrease;
        }
        public float GetBuildingSpawn()
        {
            return spawnIncrease;
        }
        public float GetBuildingAdjacency()
        {
            return adjacencyBonus;
        }
    }
}


