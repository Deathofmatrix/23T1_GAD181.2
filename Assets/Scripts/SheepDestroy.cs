using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{

    public class SheepDestroy : MonoBehaviour
    {
        public LayerMask SheepLayer;
        public MoneyManager MoneyManager;

        public void OnTriggerEnter(Collider other)
        {
            // the 1 << is a Bitwise operation, which is used to check if the specific layer exists in the array of Layer Masks in the inspector
            // it functions by literaaly shifting the ""0" and"1" in the bit to count up from 0
            // I have tried this script without this incredibly conveluted method - It does not work

            if (SheepLayer == (SheepLayer | (1 << other.gameObject.layer)))
            {
                Destroy(other.gameObject);
            }

            MoneyManager.MoneyCount();

        }

    }

}