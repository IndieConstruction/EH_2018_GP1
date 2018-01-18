using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public Rigidbody rb;
    public float force;
    public BallState status;
    public float ballduration;
    private float timer;
    public hand currentHand;

    // Use this for initialization
    void Awake() {
        rb.useGravity = false;
        status = BallState.inHand;
    }
    private void Update() {
        if (status == BallState.shooted) {
            timer = timer + Time.deltaTime;
            BallTimer();
        }
        if (status == BallState.inHand) {
            gameObject.transform.position = currentHand.transform.position;
        }
    }

    public void Shoot(hand hand) {
        this.currentHand = hand;
        if (status == BallState.inHand) {
            status = BallState.shooted;
            rb.useGravity = true;
            rb.AddForce(new Vector3(1 * force, 0, 0));
        }
    }

    /// <summary>
    ///funzione che disabilità la fireball
    /// </summary>
    private void DisableFireBall() {
        gameObject.transform.position = currentHand.transform.position;
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);
        status = BallState.inHand;
    }

    private void BallTimer() {
        if (timer >= ballduration) {
            DisableFireBall();
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().Kill();
            DisableFireBall();
        }
    }
}

public enum BallState {
    inHand, shooted
}
