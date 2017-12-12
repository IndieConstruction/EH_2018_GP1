using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    /// <summary>
    /// Nome dell'agent.
    /// </summary>
    public string Name;
    public int Life;
    public bool IsAlive;
    public float MovementSpeed;

    /// <summary>
    /// Toglie una unità di salute a questo oggetto.
    /// </summary>
    public void Damage()
    {
        Debug.Log("Ho subito un danno " + Name);
        Life = Life - 1;
        if (Life == 0)
        {
            IsAlive = false;
        }
    }

}
