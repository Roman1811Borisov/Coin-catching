using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField] private float xBound;
    [SerializeField] protected float horizontalInput;
    [SerializeField] protected float movingSpeed;
    [SerializeField] protected float rotatingSpeed;

    void Start()
    {

    }

    void Update()
    {
        Moving(); // ABSTRACTION
    }

    protected void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movingSpeed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.right, horizontalInput * rotatingSpeed * Time.deltaTime);

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
}
