using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public IEl elementalBehaviour;

    private void Start() {
        elementalBehaviour = new ElFire() as IEl;
    }

    public void Attack() {
        elementalBehaviour.DoAttack();
    }
}
