using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MoveBack
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

    protected void DestroyOutOfBounds()
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
