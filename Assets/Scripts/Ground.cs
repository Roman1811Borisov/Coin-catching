using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ground : MoveBack
{
    private Vector3 startPosition;
    private float repeatWidth = 30;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Moving();
        if(transform.position.z < (startPosition.z - repeatWidth))
        {
            transform.position = startPosition;
        }
    }
}
