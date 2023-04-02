using SheepGame.Chonnor;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewsReports : MonoBehaviour
{
    private GameObject currentNewsObject;
    public GameObject newsPrefab; // a variable for the prefab which shows the news
    public float scrollSpeed = 50f; // the speed at which the instantiated prefab scrolls across the bottom
    public RectTransform panelTransform; // the size and psotition of the panel the prefab is on
    public Vector2 newsSize = new Vector2(720f, 90f); // the size of the instantiated prefab 
    public static string farmNameString;
    private Text farmName;
    private bool alreadyNews = false; 

    // if there is already news on screen, there will be no new instantiation 

    private static int[] moneyMilestone = { 50, 250, 500, 1000 }; // the list of milestones that the player can make - this can be added to at any time
    private static bool[] moneyMilestoneReached = new bool[moneyMilestone.Length]; // a bool to check if the milestone in the list has been reached once before, and never triggers again
    private static int[] buildingMilestone = { 1, 2, 3, 6, 9 }; // same for buildings
    private static bool[] buildingMilestoneReached = new bool[buildingMilestone.Length];
    private static int[] tutorialMilestones =  { 0, 10 , 100, 3000 };
    private static string[] tutorialMessages = { "Why don't you try clicking on Spawn Sheep?", "Ten already?! You're a natural at this!" , "Why don't you check out the Upgrades?", "Why are you still playing?" };
    private static bool[] tutorialMilestonesReached = new bool[tutorialMilestones.Length];

    // we can add in new "moneyMilestone" and simply create a method to make more news headlines
    // i've started one for Buildings - I just need a static variable for the number of buildings in the grid manager



    // checks the list of moneymilestones to see if any have been reached 
    // if they have it prints the headline, and checks that milestone off - making it impossible to check off again
    // even if the player goes below that milestone again

    private void Start()
    {
        farmName.text = farmNameString.ToString();
    }

    private void TutorialLevel(int tutorialLevel)
    {
        for(int i = 0 ; i < tutorialMilestones.Length; i++)
        {
            if (tutorialLevel == tutorialMilestones[i] && !tutorialMilestonesReached[i] && !alreadyNews)
            {
                string headline = tutorialMessages[i];
                SpawnNews(headline);
                tutorialMilestonesReached[i] = true;
                alreadyNews = true;
                Debug.Log("News is True");
            }

        }
    }
    // set a timer for the alreadyNews bool to return to false

    private void CheckmoneyMilestoneReached(int currentMoney)  
    {
        for (int i = 0; i < moneyMilestone.Length; i++)
        {
            if (currentMoney >= moneyMilestone[i] && !moneyMilestoneReached[i])
            {
                string headline = farmNameString + " Just reached $" + moneyMilestone[i] + "!";
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
        currentNewsObject = Instantiate(newsPrefab, panelTransform) as GameObject;
        currentNewsObject.transform.localPosition = new Vector3(panelTransform.rect.width / 2f, 0f, 0f);
        TextMeshProUGUI textMesh = currentNewsObject.GetComponent<TextMeshProUGUI>();
        textMesh.text = headline;
        textMesh.rectTransform.sizeDelta = newsSize;
        StartCoroutine(MoveNewsObject(currentNewsObject));
    }

    private IEnumerator MoveNewsObject(GameObject newsObject)
    {
        float width = newsObject.GetComponent<RectTransform>().rect.width;
        float panelWidth = panelTransform.rect.width;
        float edgeX = -panelWidth * 2f - width * 2f;

        while (newsObject.transform.localPosition.x + (width * 2f) > edgeX)
        {
            newsObject.transform.Translate(-scrollSpeed * Time.deltaTime, 0f, 0f);
            yield return null;
        }
        Destroy(newsObject);
    }


    private void Update()
    {
        // int currentBuildings = GridManager.currentbuildings;
        int currentMoney = MoneyManager.currentMoney;
        CheckmoneyMilestoneReached(currentMoney);

        TutorialLevel(currentMoney);

        // CheckNumberOfBuildings()
        
    }
}
