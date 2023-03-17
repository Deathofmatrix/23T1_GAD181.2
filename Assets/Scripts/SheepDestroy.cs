using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{

    public class SheepDestroy : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Sheep"))
            {
                Destroy(other.gameObject);
            }

        }

    }

}