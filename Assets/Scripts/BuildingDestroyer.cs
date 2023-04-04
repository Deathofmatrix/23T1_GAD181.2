using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SheepGame.Chonnor
{

    public class BuildingDestroyer : MonoBehaviour
    {

        [SerializeField] private GameObject whatTheBinDoes;

        private void Start()
        {
            whatTheBinDoes.SetActive(false);
        }

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

        private void OnMouseOver()
        {
            Debug.Log("MouseOverBin");
            whatTheBinDoes.gameObject.SetActive(true);
        }

        private void OnMouseExit()
        {
            whatTheBinDoes.gameObject.SetActive(false);
        }
    }
}