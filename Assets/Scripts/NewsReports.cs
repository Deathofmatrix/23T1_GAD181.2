using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NewsReports : MonoBehaviour
{

    public GameObject newsPrefab; // a variable for the prefab which shows the news
    public float scrollSpeed = 50f; // the speed at which the instantiated prefab scrolls across the bottom
    public RectTransform panelTransform; // the size and psotition of the panel the prefab is on
    public Vector2 newsSize = new Vector2(720f, 90f); // the size of the instantiated prefab 

 //   private bool introNews = false;
    private static int[] moneyMilestone = { 50, 250, 500, 1000 }; // the list of milestones that the player can make - this can be added to at any time
    private static bool[] moneyMilestoneReached = new bool[moneyMilestone.Length]; // a bool to check if the milestone in the list has been reached once before, and never triggers again
    private static int[] buildingMilestone = { 1, 2, 3, 6, 9 }; // same for buildings
    private static bool[] buildingMilestoneReached = new bool[buildingMilestone.Length];

    // we can add in new "moneyMilestone" and simply create a method to make more news headlines
    // i've started one for Buildings - I just need a static variable for the number of buildings in the grid manager



    // checks the list of moneymilestones to see if any have been reached 
    // if they have it prints the headline, and checks that milestone off - making it impossible to check off again
    // even if the player goes below that milestone again
    private void CheckmoneyMilestoneReached(int currentMoney)  
    {
        for (int i = 0; i < moneyMilestone.Length; i++)
        {
            if (currentMoney >= moneyMilestone[i] && !moneyMilestoneReached[i])
            {
                string headline = "You reached $" + moneyMilestone[i] + "!";
                SpawnNews(headline);
                moneyMilestoneReached[i] = true;
            }
        }
    }

    private void CheckNumberOfBuildings(int currentBuildings)
    {
        for(int i = 0; i < buildingMilestone.Length; i++)
        {
            if ( currentBuildings >= buildingMilestone[i] && !buildingMilestoneReached[i])
            {
                string headline = "FARM_NAME now has " + buildingMilestone[i] + "building's on their farm!";
                SpawnNews(headline);
                buildingMilestoneReached[i] = true;
            }
        }
    }

    private void SpawnNews(string headline)
    {
        GameObject newsObject = Instantiate(newsPrefab, panelTransform) as GameObject;
        newsObject.transform.localPosition = new Vector3(panelTransform.rect.width / 2f, 0f, 0f);
        TextMeshProUGUI textMesh = newsObject.GetComponent<TextMeshProUGUI>();
        textMesh.text = headline;
        textMesh.rectTransform.sizeDelta = newsSize;
        StartCoroutine(MoveNewsObject(newsObject));
    }

    private IEnumerator MoveNewsObject(GameObject newsObject)
    {
        float width = newsObject.GetComponent<RectTransform>().rect.width;
        float panelWidth = panelTransform.rect.width;
        float edgeX = -panelWidth / 2f - width / 2f;

        while (newsObject.transform.localPosition.x + (width / 2f) > edgeX)
        {
            newsObject.transform.Translate(-scrollSpeed * Time.deltaTime, 0f, 0f);
            yield return null;
        }

        Destroy(newsObject);
    }

    void Update()

    {
        /*
        if (introNews == true)
        {
            return;
        }
        else
        {
            string headline = "Welcome to yoour farm! Try Click the sheep icon";
            SpawnNews(headline);
            introNews = true;

        }
        */
        int currentMoney = MoneyManager.currentMoney;
        CheckmoneyMilestoneReached(currentMoney);

        // int currentBuildings = ; need to locate or create a static variable to see how many buildings are in the grid manager

    }



}
