using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; private set; } = true;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject[] gameOverMenu;

    void Update()
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
}
