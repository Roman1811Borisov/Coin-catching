using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; private set; } = true;

    private float money;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject[] gameOverMenu;

    void Start()
    {
    }

    public void GameOver()
    {
        foreach (var UIObject in gameOverMenu)
        {
            UIObject.gameObject.SetActive(true);
        }
        isGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateMoney(uint increaseMoney)
    {
        money += increaseMoney;
        moneyText.text = "MONEY: " + money;
    }
}
