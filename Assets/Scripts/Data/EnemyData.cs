using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "GameData/Agents", order = 1)]
public class EnemyData : ScriptableObject {

    public int UniqueId = -1;
    public int Life;
    public int Level = 1;
    public float MovementSpeed;
    public Color MaterialColor;

    static int maxUniqueId = 0;

    private void Awake() {
        maxUniqueId++;
        UniqueId = maxUniqueId;
    }

}
