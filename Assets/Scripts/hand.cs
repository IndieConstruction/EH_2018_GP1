using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {
    public GameManager gm;
    public FireBall fireball;
    

    private void Start() {
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F) && gm.Mario.isFlower) {
            fireball.Shoot(gameObject.GetComponent<hand>());
        }
    }
}

