using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class PlacementConfirmation : MonoBehaviour
    {
        [SerializeField] private Canvas confirmationCanvas;
        public static BuildingDrag lastDraggedBuilding;

        public void ActivateConfirmation()
        {
            if (!lastDraggedBuilding.GetPromptedStatus())
            {
                confirmationCanvas.enabled = true;
                Debug.Log("confirm?");
                lastDraggedBuilding.SetPromptedStatus(true);
            }

        }

        public void Confirmation()
        {
            confirmationCanvas.enabled = false;
        }

        public void Deny()
        {
            confirmationCanvas.enabled = false;
            lastDraggedBuilding.transform.position = ShopManager.spawnPoint.position;
            lastDraggedBuilding.SetPromptedStatus(false);
            BuildingType lastDraggedBuildingType = lastDraggedBuilding.GetComponent<BuildingType>();
            lastDraggedBuildingType.SetLockStatus(false);
            lastDraggedBuildingType.SetOriginalPosition(ShopManager.newSpawn);
        }
    }
}

