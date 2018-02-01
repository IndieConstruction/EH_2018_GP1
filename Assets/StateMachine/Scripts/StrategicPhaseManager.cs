using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategicPhaseManager : MonoBehaviour {

    public enum state {
        P1Place,
        P2Place,
        Switch,
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Ciao sono lo StrategicPhaseManager, ora ci penso io!!!");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Ci sto pensando...");
    }

    private void OnDestroy() {
        Debug.Log("No dai!!! proprio sul più bello... ");
    }
}
