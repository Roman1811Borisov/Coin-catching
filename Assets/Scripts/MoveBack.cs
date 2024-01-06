using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float speed = 40;

    void Update()
    {
        Moving();
    }

    protected void Moving()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}
