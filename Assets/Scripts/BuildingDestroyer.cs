using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingDestroyer : MonoBehaviour
{

    [SerializeField] private GameObject whatTheBinDoes;

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

    private void OnMouseEnter(PointerEventData pointerEventData)
    {
        whatTheBinDoes.gameObject.SetActive(true);
    }

    private void OnMouseExit(PointerEventData pointerEventData)
    {
        whatTheBinDoes.gameObject.SetActive(false);
    }
}
