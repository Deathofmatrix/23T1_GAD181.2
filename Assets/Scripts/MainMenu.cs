using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button startGame;
    public TMP_InputField farmName;

    private void Awake()
    {
        farmName = GetComponent<TMP_InputField>();

        farmName.onValueChanged.AddListener(EnableButton);
    }


    private void OnEnable()
    {
        EnableButton(farmName.text);
    }


    private void EnableButton(string input)
    {
        startGame.interactable = !string.IsNullOrWhiteSpace(input);
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("SheepClicker");
        NewsReports.farmNameString = farmName.text;
        
    }

}
