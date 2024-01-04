using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ChoosingTransportMenu;
    [SerializeField] private TMP_InputField NameField;

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GoToChoosingTransport()
    {
        MainMenu.SetActive(false);
        ChoosingTransportMenu.SetActive(true);

        MainManager.Instance.PlayerName = NameField.text;
    }

    public void GoToMainMenu()
    {
        MainMenu.SetActive(true);
        ChoosingTransportMenu.SetActive(false);
    }

    public void StartBoatGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartCarGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartPlaneGame()
    {
        SceneManager.LoadScene(3);
    }

}
