using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{

    public class SheepDestroy : MonoBehaviour
    {
        public LayerMask SheepLayer;

        public void OnTriggerEnter(Collider other)
        {
            if (SheepLayer == (SheepLayer | (1 << other.gameObject.layer)))
            {
                Destroy(other.gameObject);
            }

        }

    }

}