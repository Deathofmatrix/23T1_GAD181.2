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
            Destroy(other.gameObject);
            BuildingType buildingScript = other.GetComponent<BuildingType>();
            if (buildingScript.GetLockStatus() == false)
            {
                GridManager.isBuildingReadyToSpawn = true;
            }
        }
    }
}
