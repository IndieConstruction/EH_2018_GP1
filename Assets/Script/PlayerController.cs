using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public GridController gridController;
    public int XPos;
    public int YPos;

    public Button btn;

    int XPos_old;
    int YPos_old;

    IPointerClickHandler myFunction;

    // Use this for initialization
    void Start () {
        transform.position = gridController.GetWorldPosition(XPos, YPos);

        // EventSystem.current.SetSelectedGameObject(btn.gameObject);
        

        
    }

    
	
	// Update is called once per frame
	void Update () {
        XPos_old = XPos;
        YPos_old = YPos;

        if (Input.GetKeyDown(KeyCode.A)) {
            // sx
            XPos--;
            move();
        } else if (Input.GetKeyDown(KeyCode.D)) {
            XPos++;
            move();
            // dx
        } else if (Input.GetKeyDown(KeyCode.W)) {
            // up
            YPos++;
            move();
        } else if (Input.GetKeyDown(KeyCode.S)) {
            // down
            YPos--;
            move();
        }
    }



    void move() {
        if (gridController.IsValidPosition(XPos, YPos)) {
            transform.DOMove(gridController.GetWorldPosition(XPos, YPos), 0.6f).SetEase(Ease.Linear);
            CustomLogger.Log("Mi muovo in {0}:{1}", XPos, YPos);
        } else {
            CustomLogger.Log("Non posso muovere in {0}:{1}", XPos, YPos);
            XPos = XPos_old;
            YPos = YPos_old;
        }
          
    }


    #region API

    public void SetPositionAndMove(int _x, int _y) {
        XPos = _x;
        YPos = _y;
        move();
    }

    #endregion

}
