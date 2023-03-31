using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawnChecker : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            GridManager.isBuildingReadyToSpawn = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            GridManager.isBuildingReadyToSpawn = true;
        }
    }
}
