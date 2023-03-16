using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            other.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
            Debug.Log("Building entered" + this.name);
        }
    }
    private void OnMouseEnter()
    {
        
    }
}
