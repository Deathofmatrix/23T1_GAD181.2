using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] ShopManager shopManager;

    [SerializeField] int buttonPrice;
    [SerializeField] BuildingType.TypeOfBuilding typeOfBuilding;
    [SerializeField] int increase;

    private void Start()
    {
        shopManager = GameObject.Find("Shop Manager").GetComponent<ShopManager>();
    }

    public void OnClick()
    {
        shopManager.Upgrade(buttonPrice, typeOfBuilding, increase);
    }
}
