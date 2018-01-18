using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool isFirstManager;
    public BasePlayer Mario;
    public Text Score;
    public int numero = 1;

    void Awake() {
        Score.text = numero.ToString() ;
        DontDestroyOnLoad(gameObject);
        GameManager[] gms = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gms.Length; i++) {
            if (gms[i].isFirstManager == true) {
                return;
            }
        }
        isFirstManager = true;
        for (int i = 0; i < gms.Length; i++) {
            if (gms[i].isFirstManager == false) {
                Destroy(gms[i].gameObject);
            }
        }
    }

}
