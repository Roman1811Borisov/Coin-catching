using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    private MainManager mainManager;

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ChoosingTransportMenu;
    [SerializeField] private TMP_InputField NameField;

    private void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }

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

    public void StartCarGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartTankGame()
    {
        SceneManager.LoadScene(2);
    }
}
