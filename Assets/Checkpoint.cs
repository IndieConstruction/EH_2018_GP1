using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            BasePlayer playerScript = other.GetComponent<BasePlayer>();
            playerScript.SetRespawnPoint(transform.position);
        }
    }
}
