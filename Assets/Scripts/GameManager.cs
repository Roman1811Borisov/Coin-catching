using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; private set; } = true;
    //public uint TotalMoney;

    private uint money;
    private uint score;
    //private uint bestScore;
    //private string bestPlayerName;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalMoneyText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private uint scoreIcreaseNumber = 10;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject totalMoneyBestScorePanel;

    void Start()
    {
        LoadBestRecord();

        //TotalMoney = MainManager.Instance.TotalMoney;
        bestScoreText.text = "BEST SCORE: " + MainManager.Instance.BestPlayerName + ": " + MainManager.Instance.BestScore;
        totalMoneyText.text = "TOTAL MONEY: " + MainManager.Instance.TotalMoney;
    }

    public void GameOver()
    {
        SaveActiveUIElementsToGameOver();

        UpdateTotalMoney();

        if (score > MainManager.Instance.BestScore)
        {
            UpdateBestScore();
        }
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

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public string BestScore;
        public string TotalMoney;
    }

    public void SaveBestRecord()
    {
        SaveData data = new SaveData();
        data.BestPlayerName = MainManager.Instance.BestPlayerName;
        data.BestScore = Convert.ToString(MainManager.Instance.BestScore);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MainManager.Instance.BestPlayerName = data.BestPlayerName;
            MainManager.Instance.BestScore = Convert.ToUInt32(data.BestScore);
        }
    }

    void SaveActiveUIElementsToGameOver()
    {
        gameOverMenu.SetActive(true);
        totalMoneyBestScorePanel.SetActive(true);
        isGameActive = false;
    }

    void UpdateTotalMoney()
    {
        //TotalMoney += money;
        MainManager.Instance.TotalMoney += money;
        totalMoneyText.text = "TOTAL MONEY: " + MainManager.Instance.TotalMoney;
    }

    void UpdateBestScore()
    {
        MainManager.Instance.BestScore = score;
        MainManager.Instance.BestPlayerName = MainManager.Instance.PlayerName;
        bestScoreText.text = "BEST SCORE: " + MainManager.Instance.BestPlayerName + ": " + MainManager.Instance.BestScore;
        SaveBestRecord();
    }
}
