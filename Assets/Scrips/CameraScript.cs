using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private int xSpeed = 10;
    [SerializeField] private int zSpeed = 10;
    [SerializeField] private int ySpeed = 10;

    private float tickRate = 0.1f;
    private float timeToNextAction = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GameControles();
    }

    void GameControles()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Time.timeScale >= 0.5)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }

    void Movement()
    {
        //Z movement
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, zSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -zSpeed, ForceMode.Acceleration);
        }

        //X movement
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(-xSpeed, 0, 0, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(xSpeed, 0, 0, ForceMode.Acceleration);
        }

        //Y movement
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(0, ySpeed, 0, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody>().AddForce(0, -ySpeed, 0, ForceMode.Acceleration);
        }
    }
}
