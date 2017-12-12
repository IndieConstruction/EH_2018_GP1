using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaggio : MonoBehaviour {

    int Salute = 10;
    public string Name = "Mario";
    public bool IsAlive = false;
    public float Speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive == false) {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void Damage() {
        Debug.Log("Ho subito un danno " + Name);
        Salute = Salute - 1;
        if (Salute == 0) {
            IsAlive = false;
        }
    }

}
