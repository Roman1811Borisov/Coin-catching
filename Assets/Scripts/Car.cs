using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Transport //INHERITANCE
{
    void Update()
    {
        Moving();
    }

    protected override void Moving()
    {
        if (gameManager.isGameActive)
        {
            base.Moving();
        }
    }
}
