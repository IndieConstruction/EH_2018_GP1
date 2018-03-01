using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour {

    int X, Y;

    public void SetPosition(int _x, int _y) {
        X = _x;
        Y = _y;
    }
    

    private void OnMouseDown() {
        Debug.Log("Click on position : " + FindObjectOfType<GridController>().GetWorldPosition(X, Y));
        FindObjectOfType<PlayerController>().SetPositionAndMove(X, Y);
    }

}
