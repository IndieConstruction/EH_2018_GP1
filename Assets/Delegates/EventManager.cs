using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    /// <summary>
    /// Tipologia generica di evento delegato.
    /// </summary>
    public delegate void GameEvent();

    /// <summary>
    /// Verrà richiamata al termine di tutti i settaggi di gioco.
    /// </summary>
    public static GameEvent OnPlayStart;

    /// <summary>
    /// Verrà richiamata al termine del gioco.
    /// </summary>
    public static GameEvent OnPlayEnd;

}
