using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    public TextMeshProUGUI LableFase;

    public static UIManager Instance;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(gameObject);
    }

    public void ShowFase(string _faseName) {
        LableFase.text = "Fase: " + _faseName;
    }

}
