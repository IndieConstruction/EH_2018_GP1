using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool isFirstManager;
    public BasePlayer Mario;
    public Text Score;
    public int numero = 1;

    void Awake() {
        Score.text = numero.ToString();
        DontDestroyOnLoad(gameObject);
        GameManager[] gms = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gms.Length; i++) {
            if (gms[i].isFirstManager == true) {
                return;
            }
        }
        isFirstManager = true;
        for (int i = 0; i < gms.Length; i++) {
            if (gms[i].isFirstManager == false) {
                Destroy(gms[i].gameObject);
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SaveGameStatus();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            LoadGameStatus();
        }
    }

    public void SaveGameStatus() {
        PlayerPrefs.SetString("PlayerName", Mario.Name);
        PlayerPrefs.SetInt("PlayerLife", Mario.Life);

        LevelData levelData = new LevelData();
        string enemiesString = string.Empty;
        foreach (var enemy in FindObjectsOfType<Enemy>()) {
            levelData.Enemies.Add(enemy.Data);
        }
        enemiesString = JsonUtility.ToJson(levelData);
        PlayerPrefs.SetString("LevelState", enemiesString);
    }

    public void LoadGameStatus() {
        Mario.Name = PlayerPrefs.GetString("PlayerName");
        Mario.Life = PlayerPrefs.GetInt("PlayerLife");
        Mario.Life = PlayerPrefs.GetInt("PlayerLife");
        string levelData = PlayerPrefs.GetString("LevelState");
        LevelData loadedLevelData = JsonUtility.FromJson<LevelData>(levelData)
    }

}

[Serializable]
public class LevelData {
    public List<EnemyData> Enemies = new List<EnemyData>();
}
