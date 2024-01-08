using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MoveBack // INHERITANCE
{
    private float zBound = -800;
    private float yBound = -10;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        Moving();
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.z < zBound || transform.position.y < yBound)
        {
            Destroy(gameObject);
        }
    }

    protected override void Moving()  // POLYMORPHISM
    {
        if (gameManager.isGameActive)
        {
            base.Moving();
        }
    }
}
