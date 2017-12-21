﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : Agent {

    private static int PlayerCount = 0;

    private Transform myTransform = null;
       

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.freezeRotation = true;
        }
        
        PlayerCount = PlayerCount + 1;
        myTransform = gameObject.GetComponent<Transform>();
        Debug.Log("Player count: " + PlayerCount);

    }

    private void Update()
    {
        if (Name == "Mario")
        {
            // Movimento sinistra P1
            if (Input.GetKey(KeyCode.A))
            {
                myTransform.position = myTransform.position + new Vector3(-MovementSpeed, 0, 0);
            }
            // Movimento destra P1
            if (Input.GetKey(KeyCode.D))
            {
                myTransform.position = myTransform.position + new Vector3(MovementSpeed, 0, 0);
            }
            // Salto P1
            if (Input.GetKeyDown(KeyCode.W) == true && IsJumping == false ) {
                rigidbody.AddForce(new Vector3(0, JumpForce, 0));
                IsJumping = true;
            }


        }
        else if (Name == "Luigi") {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myTransform.position = myTransform.position + new Vector3(-MovementSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                myTransform.position = myTransform.position + new Vector3(MovementSpeed, 0, 0);
            }
            // Salto P2
            if (Input.GetKeyDown(KeyCode.UpArrow) == true && IsJumping == false)
            {
                rigidbody.AddForce(new Vector3(0, JumpForce, 0) );
                IsJumping = true;
            }
        }

    }

    /// <summary>
    /// Viene chiamata quando l'oggetto entra in collisione con un altro oggetto.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        IsJumping = false;

        if (collision.gameObject.tag == "Respawn") {
            Damage();
        }
    }

    public static void PrintLog()
    {
        Debug.Log("Sono una funzione statica");
    }



}
