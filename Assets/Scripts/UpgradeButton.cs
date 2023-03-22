using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] ShopManager shopManager;
    [SerializeField] TextMeshProUGUI buttonText;   

    [SerializeField] string buttonName;
    [SerializeField] int buttonPrice;
    [SerializeField] BuildingType.TypeOfBuilding typeOfBuilding;
    [SerializeField] int increase;

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
        shopManager.Upgrade(buttonPrice, typeOfBuilding, increase);
    }

    public int GetPrice()
    {
        return buttonPrice;
    }
}
