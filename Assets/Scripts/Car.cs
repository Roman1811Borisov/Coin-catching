using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Transport //INHERITANCE
{
    private GameManager gameManager;
    private Rigidbody carRigidbody;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Moving();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

    protected override void Moving()
    {
        if (gameManager.isGameActive)
        {
            base.Moving();
        }
    }
}
