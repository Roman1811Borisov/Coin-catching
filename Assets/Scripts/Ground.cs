using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ground : MoveBack // INHERITANCE 
{
    private Vector3 startPosition;
    private float repeatWidth;
    private GameManager gameManager;

    private void Start()
    {
        startPosition = transform.position;
        repeatWidth = transform.lossyScale.z / 2;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Moving(); 
        if(transform.position.z < (startPosition.z - repeatWidth))
        {
            transform.position = startPosition;
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
