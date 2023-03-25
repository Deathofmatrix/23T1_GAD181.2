using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    static public string farmName;
    [SerializeField] private Button startGame;
    [SerializeField] private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();

        inputField.onValueChanged.AddListener(EnableButton);
    }

    private void OnEnable()
    {
        EnableButton(inputField.text);
    }


    private void EnableButton(string input)
    {
        startGame.interactable = !string.IsNullOrWhiteSpace(input);
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("SheepClicker");
    }

}
