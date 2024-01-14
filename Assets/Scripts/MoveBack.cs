using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    private float speed = 300;

    void Update()
    {
        Moving();
    }

    protected virtual void Moving() // ABSTRACTION
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}
