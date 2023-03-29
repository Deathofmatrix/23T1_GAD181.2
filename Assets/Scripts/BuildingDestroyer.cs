using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            BuildingType buildingScript = other.GetComponent<BuildingType>();

            //if (buildingScript.GetLockStatus() == true)
            //{
            //    GridManager.isBuildingReadyToSpawn = true;
            //}

            GridManager.isBuildingReadyToSpawn = true;
            Destroy(other.gameObject);  
        }
    }
}
