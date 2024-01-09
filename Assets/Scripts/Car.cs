using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Transport //INHERITANCE
{

    private void Start()
    {
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
