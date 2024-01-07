using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField] private float xBound;
    [SerializeField] protected float horizontalInput;
    [SerializeField] protected float movingSpeed;

    void Start()
    {

    }

    void Update()
    {
        Moving();
    }

    protected virtual void Moving() // ABSTRACTION
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movingSpeed * horizontalInput * Time.deltaTime);

        DontGoBeyondBoundaries(xBound);
    }

    void DontGoBeyondBoundaries(float xBound)  // ABSTRACTION
    {
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
