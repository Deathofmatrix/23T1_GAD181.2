using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace SheepGame.Chonnor
{
    public class BuildingDrag : MonoBehaviour

    {
        
        private bool dragging = false;
        private Vector3 preDragPosition;
        [SerializeField] private Color transparent;
        private BuildingType currentBuilding;
        private Color newColour;
        private MeshRenderer mRend;
        [SerializeField] private PlacementConfirmation placementConfirmation;
        public bool hasBeenPrompted;

        //[SerializeField] private PlacementConfirmation placementConfirmation;

        private void Start()
        {
            placementConfirmation = GameObject.Find("Confirmation Canvas").GetComponent<PlacementConfirmation>();
            mRend = GetComponent<MeshRenderer>();
            currentBuilding = this.GetComponent<BuildingType>();
            //transparent.a = 1f;
        }

        private void OnMouseDrag()
        {
            PlacementConfirmation.lastDraggedBuilding = this;
            dragging = true;
            transform.position = MousePosition.worldPosition - preDragPosition;

            newColour = mRend.material.color;
            newColour.a = 0.5f;
            mRend.material.color = newColour;
            GridManager.lastDraggedBuilding = this.GetComponent<GameObject>();
            //if (!Input.GetMouseButton(0))
            //{
            //    BuildingType currentBuilding = this.GetComponent<BuildingType>();
            //    this.transform.position = currentBuilding.GetOriginalPosition();
            //}
        }
        private void OnMouseUp()
        {
            if (dragging)
            {
                if (GridManager.isBuildingReadyToSpawn)
                {
                    placementConfirmation.ActivateConfirmation();
                }
                this.transform.position = currentBuilding.GetOriginalPosition();
                dragging = false;
                newColour = mRend.material.color;
                newColour.a = 1f;
                mRend.material.color = newColour;
            }
        }

        public bool GetPromptedStatus()
        {
            return hasBeenPrompted;
        }
        
        public void SetPromptedStatus(bool prompted)
        {
            hasBeenPrompted = prompted;
        }




        //private void OnMouseUp()
        //{
        //    if (dragging)
        //    {
        //        preDragPosition = transform.position;
        //        preDragPosition.y = 0;
        //        dragging = false;
        //    }
        //}
    }

}
