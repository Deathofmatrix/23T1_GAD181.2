using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] ShopManager shopManager;
        [SerializeField] TextMeshProUGUI buttonText;

        [SerializeField] string buttonName;
        [SerializeField] int buttonPrice;
        [SerializeField] BuildingType.TypeOfBuilding typeOfBuilding;
        [SerializeField] int increase;
        [SerializeField] Color colour;

        private void Start()
        {
            shopManager = GameObject.Find("Shop Manager").GetComponent<ShopManager>();
        }

        private void Update()
        {
            buttonText.SetText(buttonName + " $" + buttonPrice);
        }

        public void OnClick()
        {
            shopManager.Upgrade(buttonPrice, typeOfBuilding, increase, colour);
        }

        public int GetPrice()
        {
            return buttonPrice;
        }
        public void SetPrice(int price)
        {
            buttonPrice = price;
        }
    }
}

