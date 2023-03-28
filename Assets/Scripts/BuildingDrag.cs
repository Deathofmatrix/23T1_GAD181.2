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
        private Color transparent;
        private BuildingType currentBuilding;

        private void Start()
        {
            currentBuilding = this.GetComponent<BuildingType>();
            //transparent.a = 1f;
        }

        private void OnMouseDrag()
        {
            dragging = true;
            transform.position = MousePosition.worldPosition - preDragPosition;

            //MeshRenderer mRend = GetComponent<MeshRenderer>();
            //mRend.material.color = transparent;
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
