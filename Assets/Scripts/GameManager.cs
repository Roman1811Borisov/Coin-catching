using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; private set; } = true;
    public uint TotalMoney;

    private MainManager mainManager;
    private uint money;
    private uint score;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalMoneyText;
    [SerializeField] private uint scoreIcreaseNumber = 10;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject totalMoneyPanel;

    void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        TotalMoney = mainManager.TotalMoney;
        totalMoneyText.text = "TOTAL MONEY: " + TotalMoney;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        totalMoneyPanel.SetActive(true);
        isGameActive = false;

        TotalMoney += money;
        mainManager.TotalMoney += money;
        totalMoneyText.text = "TOTAL MONEY: " + TotalMoney;
    }

    public void RestartCarGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartArmorCarGame()
    {
        SceneManager.LoadScene(2);
    }

    public void UpdateMoney(uint increaseMoney)
    {
        money += increaseMoney;
        moneyText.text = "MONEY: " + money;
    }

    public void IncreaseScore()
    {
        score += scoreIcreaseNumber;
        scoreText.text = "SCORE: " + score;
    }

    public void StartGame()
    {
        isGameActive = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
