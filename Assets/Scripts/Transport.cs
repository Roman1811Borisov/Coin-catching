using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    private MainManager mainManager;
    [SerializeField ]protected GameManager gameManager;
    [SerializeField] private float xBound;
    [SerializeField] protected float horizontalInput;
    [SerializeField] protected float movingSpeed;
    [SerializeField] protected uint copperScore = 1;
    [SerializeField] protected uint silverScore = 3;
    [SerializeField] protected uint goldenScore = 15;

    void Start()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CopperCoin"))
        {
            gameManager.UpdateMoney(copperScore);
            Destroy(other.gameObject);
            return;
        }
        if (other.CompareTag("SilverCoin"))
        {
            gameManager.UpdateMoney(silverScore);
            Destroy(other.gameObject);
            return;
        }
        if (other.CompareTag("GoldenCoin"))
        {
            gameManager.UpdateMoney(copperScore);
            Destroy(other.gameObject);
            return;
        }
    }
}
