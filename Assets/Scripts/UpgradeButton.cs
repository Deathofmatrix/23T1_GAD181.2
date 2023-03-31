using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SheepGame.Chonnor
{
    public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] ShopManager shopManager;
        [SerializeField] TextMeshProUGUI buttonText;

        [SerializeField] string buttonName;
        [SerializeField] int buttonPrice;
        [SerializeField] BuildingType.TypeOfBuilding typeOfBuilding;
        [SerializeField] int increase;
        [SerializeField] Color colour;
        [SerializeField] private GameObject toolTip;

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

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            Debug.Log("Cursor Entering " + name + " GameObject");
            toolTip.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            Debug.Log("Cursor Exiting " + name + " GameObject");
            toolTip.gameObject.SetActive(false);
        }
    }
}

