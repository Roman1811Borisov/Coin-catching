using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField] private float zBound;
    [SerializeField] protected float horizontalInput;
    [SerializeField] protected float movingSpeed;

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

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }
}
