using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class BuildingDrag : MonoBehaviour
    {
        //private bool dragging = false;
        private Vector3 preDragPosition;

        private void OnMouseDrag()
        {
            //dragging = true;
            transform.position = MousePosition.worldPosition - preDragPosition;
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
