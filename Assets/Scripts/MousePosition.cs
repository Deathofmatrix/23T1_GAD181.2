using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPosition;
    public static Vector3 worldPosition;
    Plane plane = new Plane(Vector3.down, 5);

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        //if (Physics.Raycast(ray, out RaycastHit hitData))
        //{
        //    worldPosition = hitData.point;
        //}

        if (plane.Raycast(ray, out float distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

    }
}
