using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "GameData/Agents", order = 1)]
public class EnemyData : ScriptableObject {
    
    [NonSerialized]
    public int UniqueId = -1;
    public int Life;
    public int Level = 1;
    public float MovementSpeed;
    public Color MaterialColor;

    static int maxUniqueId = 0;

    public EnemyData() {
    }

    private void Awake() {
        maxUniqueId++;
        UniqueId = maxUniqueId;
    }

}
