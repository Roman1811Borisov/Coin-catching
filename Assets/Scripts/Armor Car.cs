using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorCar : Transport
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject[] wheels;
    
    void Update()
    {
        Moving();
    }
    protected override void Moving()
    {
        if (gameManager.isGameActive)
        {
            base.Moving();
            foreach (var wheel in wheels)
            {
                wheel.transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
            }
        }
    }
}
