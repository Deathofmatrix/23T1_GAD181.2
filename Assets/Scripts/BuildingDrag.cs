using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
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

        private void Start()
        {
            mRend = GetComponent<MeshRenderer>();
            currentBuilding = this.GetComponent<BuildingType>();
            //transparent.a = 1f;
        }

        private void OnMouseDrag()
        {
            dragging = true;
            transform.position = MousePosition.worldPosition - preDragPosition;

            newColour = mRend.material.color;
            newColour.a = 0.5f;
            mRend.material.color = newColour;
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
                this.transform.position = currentBuilding.GetOriginalPosition();
                dragging = false;
                newColour = mRend.material.color;
                newColour.a = 1f;
                mRend.material.color = newColour;
            }
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
