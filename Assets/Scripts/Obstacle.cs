using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MoveBack
{
    private float zBound = -420;
    private float yBound = -10;

    void Start()
    {
        
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

}
