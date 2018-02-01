using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public enum State {
        Setup,
        Strategic,
        Combat,
        End,
    }

    public State CurrentState {
        get {
            return _currentState;
        }
        set {
            if (CkeckStateChange(value) == true) {
                OnStateEnd(_currentState);
                _currentState = value;
                OnStateStart(_currentState);
            } else {
                Debug.Log("Non è possibile passare da " + _currentState + " a " + value);
            }
        }
    }
    private State _currentState;


    /// <summary>
    /// Controlla se è possibile cambiare lo stato in quello richiesto in <paramref name="newState"/>.
    /// </summary>
    /// <param name="newState"></param>
    /// <returns></returns>
    bool CkeckStateChange(State newState) {
        switch (newState) {
            case State.Setup:
            case State.Strategic:
                if (CurrentState != State.Setup)
                    return false;
                return true;
                break;
            case State.Combat:
                if (CurrentState != State.Strategic)
                    return false;
                return true;
                break;
            case State.End:
                if (CurrentState != State.Combat)
                    return false;
                return true;
                break;
            default:
                return false;
                break;
        }
    }

    // Use this for initialization
    void Start() {
        CurrentState = State.Setup;
        Debug.Log(UIManager.Instance);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CurrentState = State.Setup;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            CurrentState = State.Strategic;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            CurrentState = State.Combat;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            CurrentState = State.End;
        }

        OnStateUpdate();

    }

    #region State Machine

    /// <summary>
    /// Viene chiamata subito dopo aver settato un nuovo state come current <paramref name="newState"/>.
    /// </summary>
    /// <param name="newState"></param>
    void OnStateStart(State newState) {
        switch (newState) {
            case State.Setup:
                Debug.Log("Sono entrato nello stato di " + newState);
                break;
            case State.Strategic:
                Debug.Log("Sono entrato nello stato di " + newState);
                gameObject.AddComponent<StrategicPhaseManager>();
                break;
            case State.Combat:
                Debug.Log("Sono entrato nello stato di " + newState);
                break;
            case State.End:
                Debug.Log("Sono entrato nello stato di " + newState);
                break;
            default:
                Debug.Log("Sono entrato in uno stato sconosciuto " + newState);
                break;
        }
        UIManager.Instance.ShowFase(newState.ToString());
    }

    /// <summary>
    /// Viene chiamata ad ogni update in modo da eseguire solo il codice dello stato attuale.
    /// </summary>
    void OnStateUpdate() {
        switch (CurrentState) {
            case State.Setup:
                Debug.Log("Sono nello stato di " + CurrentState);
                break;
            case State.Strategic:
                Debug.Log("Sono nello stato di " + CurrentState);
                break;
            case State.Combat:
                Debug.Log("Sono nello stato di " + CurrentState);
                break;
            case State.End:
                Debug.Log("Sono nello stato di " + CurrentState);
                break;
            default:
                Debug.Log("Sono in uno stato sconosciuto " + CurrentState);
                break;
        }
    }

    /// <summary>
    /// Viene chiamata subito prima di uscire dallo stato attuale <paramref name="oldState"/>.
    /// </summary>
    /// <param name="oldState"></param>
    void OnStateEnd(State oldState) {
        switch (oldState) {
            case State.Setup:
                Debug.Log("Sto uscendo dallo stato di " + oldState);
                break;
            case State.Strategic:
                Debug.Log("Sto uscendo dallo stato di " + oldState);
                Destroy(GetComponent<StrategicPhaseManager>());
                break;
            case State.Combat:
                Debug.Log("Sto uscendo dallo stato di " + oldState);
                break;
            case State.End:
                Debug.Log("Sto uscendo dallo stato di " + oldState);
                break;
            default:
                Debug.Log("Sto uscendo da uno stato sconosciuto " + oldState);
                break;
        }
    }

    #endregion


}

