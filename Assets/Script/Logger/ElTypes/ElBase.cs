using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElBase : MonoBehaviour, IEl {

    public virtual void DoAttack() {
        // attacco base
    }

}

public interface IEl {
    void DoAttack();
}