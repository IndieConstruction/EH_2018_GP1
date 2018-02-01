using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherClass : MonoBehaviour {

    public GameplayManager GM;

    // Use this for initialization
    void Start () {
        Debug.Log(GM.CurrentState);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
