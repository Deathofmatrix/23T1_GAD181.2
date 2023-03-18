using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SheepGame.Chonnor
{

    public class ShopManager : MonoBehaviour
    {

        private Button upragdeOne, upgradeTwo, upgradeThree;


        void Start()
        {
            upragdeOne.enabled = false;
            upgradeTwo.enabled = false;
            upgradeThree.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

            // if money counter is higher than 10 then enable)

            // if money counter is higher than 50 then enable)

            // if money counter is higher than 100 then enable)

        }

        public void UpgradeOne()
        {
            Instantiate(upragdeOne);
        }
    }
}