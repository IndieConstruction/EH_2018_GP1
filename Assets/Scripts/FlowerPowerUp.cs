using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPowerUp : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            BasePlayer p = collision.gameObject.GetComponent<BasePlayer>();
            p.ActiveFlower();
            gameObject.SetActive(false);
        }
    }
}
