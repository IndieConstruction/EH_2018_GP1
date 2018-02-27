using System.Collections;
using System.Collections.Generic;
// using UnityEditor;
using UnityEngine;

public class Enemy : Agent {

    public int UniqueID = -1;

    public Vector3 ArrivePoint;
    private Vector3 destination;
    private bool goToRight;
    private bool goUp;

    public bool isHorizontal;

    public EnemyData Data;

    private void Start() {

    }

    private void OnEnable() {
        EventManager.OnPlayStart += onPlayStart;
    }


    private void onPlayStart() {
        transform.position = respawnPosition;
        // Variabili di movimento
        goToRight = true;
        destination = ArrivePoint;
        Setup();

        Debug.Log("Enemy pronto");
    }

    private void OnDisable() {
        EventManager.OnPlayStart -= onPlayStart;
    }


    EnemyData instanceData;

    void Setup() {
        if (!Data)
            return;
        instanceData = GameObject.Instantiate<EnemyData>(Data);
        instanceData.Life = 1000;
        Life = instanceData.Life;
        MovementSpeed = instanceData.MovementSpeed;
        UniqueID = instanceData.UniqueId;
    }

    // SOLO IN EDITOR

    //void SaveNewEnemyData() {

    //    instanceData.Level = instanceData.Level + 1;
    //    instanceData.Life = Life;
    //    instanceData.MovementSpeed = MovementSpeed;
    //    AssetDatabase.CreateAsset(instanceData, string.Format("Assets/Scripts/Data/Enemies/EnemyLevel{0}.asset", instanceData.Level) );
    //    AssetDatabase.SaveAssets();



    //}

    private void Update() {
        Movement();
        //if (Input.GetKeyDown(KeyCode.Alpha1)) {
        //    Life++;
        //    if (Life > 1010) {
        //        SaveNewEnemyData();
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<BasePlayer>().Kill();
        }
    }
    public void Movement() {
        if (isHorizontal == true) {
            if (transform.position.x < destination.x) {
                // sono a sx dell'obbiettivo
                if (goToRight == false) {
                    goToRight = true;
                    destination = ArrivePoint;
                }
            } else {
                // sono a dx dell'obbiettivo
                if (goToRight == true) {
                    goToRight = false;
                    destination = respawnPosition;
                }
            }
            if (goToRight == true) {
                // vado a dx
                transform.Translate(Vector3.right * Time.deltaTime * MovementSpeed);
            } else {
                // varo a sx
                transform.Translate(Vector3.left * Time.deltaTime * MovementSpeed);
            }
        }
        if (isHorizontal == false) {
            if (transform.position.y < destination.y) {
                // sono a sx dell'obbiettivo
                if (goUp == false) {
                    goUp = true;
                    destination = ArrivePoint;
                }
            } else {
                // sono a dx dell'obbiettivo
                if (goUp == true) {
                    goUp = false;
                    destination = respawnPosition;
                }
            }
            if (goUp == true) {
                // vado su
                transform.Translate(Vector3.up * Time.deltaTime);
            } else {
                // varo giu
                transform.Translate(Vector3.down * Time.deltaTime);
            }
        }
    }

    public override void Kill() {
        base.Kill();
        Destroy(this.gameObject);
    }
}

