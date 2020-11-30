using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;


public class MovementController : MonoBehaviour
{
    public Rigidbody rb;
    public int speed = 1000;
    private GameObject iteraction_object;
    public bool Iteraction = false;
    public Material red;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Dotknęł do obiektu");
            CanInteract();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void PresF()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Press F");
            CanInteract();
        }
    }
  

    private void GetInputAndUpdatePosition() {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }

    }

    void CanInteract()
    {
        iteraction_object = GameObject.FindGameObjectWithTag("Collectible");
        var dist = Vector3.Distance(transform.position, iteraction_object.transform.position);
        Debug.Log("Distance = " + dist);
        if (dist <= 4f)
        {
            Iteraction = true;
            if (Iteraction == true)
            {
                InteractWithInteractibale();
            }
        }
        else
        {
            if (Iteraction == false)
            {
                Debug.Log("Iteraction FALSE");
            }
        }
    }
    void InteractWithInteractibale()
    {
        Debug.Log("Iteraction TRUE");
        iteraction_object = GameObject.FindGameObjectWithTag("Collectible");
        iteraction_object.GetComponent<Renderer>().material = red;
        Iteraction = false;
    }

    void Update()
    {
        GetInputAndUpdatePosition();
        PresF();
    }
}
