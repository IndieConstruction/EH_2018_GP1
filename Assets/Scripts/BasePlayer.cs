using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : Agent {

    private static int PlayerCount = 0;

    private Transform myTransform = null;

    private void Start()
    {
        PlayerCount = PlayerCount + 1;
        myTransform = gameObject.GetComponent<Transform>();
        Debug.Log("Player count: " + PlayerCount);
    }

    private void Update()
    {
        if (Name == "Mario")
        {
            if (Input.GetKey(KeyCode.A))
            {
                myTransform.position = myTransform.position + new Vector3(-MovementSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                myTransform.position = myTransform.position + new Vector3(MovementSpeed, 0, 0);
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
        }

    }

    

    public static void PrintLog()
    {
        Debug.Log("Sono una funzione statica");
    }

    public void Damage() {

    }

}
