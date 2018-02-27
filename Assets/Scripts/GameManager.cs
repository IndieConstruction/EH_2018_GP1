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

    public delegate void Mydelegate();
    public Mydelegate delegatoSalvataggio;
    public Mydelegate delegatoLettura;

    public delegate bool DelegateBehaviour(bool _type, Delegate _saveBehaviour);
    public DelegateBehaviour SalvataggioDati;

    bool GetGameplayStatusAndSave(bool _isInGame, Mydelegate _saveBehaviour) {
        // Logiche di raccolta dati gameplay
        _saveBehaviour();
        return true;
    }

    bool GetGameoverStatusAndSave(bool _isInGame, Mydelegate _saveBehaviour) {
        // Logiche di raccolta dati gameover
        _saveBehaviour();
        return true;
    }


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

    private void Start() {
        // inizializzazione dell'oggetto di score testuale

        delegatoLettura = LoadGameStatus;
        delegatoSalvataggio = SaveGameStatus;

        Debug.Log("Gamemanager scatena evento OnPlayStart");
        if (EventManager.OnPlayStart != null)
            EventManager.OnPlayStart();
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if(delegatoSalvataggio != null)
                delegatoSalvataggio();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            delegatoLettura();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            delegatoSalvataggio = SaveLogic.Save;
        }
    }

    public void SaveGameStatus() {
        PlayerPrefs.SetString("PlayerName", Mario.Name);
        PlayerPrefs.SetInt("PlayerLife", Mario.Life);
        PlayerPrefs.SetFloat("App_Version", 0.4f);

        LevelData levelData = new LevelData();
        string enemiesString = string.Empty;
        // App version
        levelData.AppVersion = 0.4f;
        levelData.EnemyTest = new EnemyData() { Level = 1, Life = 10, MovementSpeed = 1 };
        
        foreach (var enemy in FindObjectsOfType<Enemy>()) {
            levelData.Enemies.Add(enemy.Data);
        }
        enemiesString = JsonUtility.ToJson(levelData);
        PlayerPrefs.SetString("LevelState", enemiesString);
        Debug.Log("Logica di salvataggio interna");

        Debug.Log("Gamemanager scatena evento OnPlayEnd");
        if (EventManager.OnPlayEnd != null)
            EventManager.OnPlayEnd();
    }

    public void LoadGameStatus() {
        Mario.Name = PlayerPrefs.GetString("PlayerName");
        Mario.Life = PlayerPrefs.GetInt("PlayerLife");
        Mario.Life = PlayerPrefs.GetInt("PlayerLife");
        string levelData = PlayerPrefs.GetString("LevelState");
        LevelData loadedLevelData = JsonUtility.FromJson<LevelData>(levelData);
    }

}

[Serializable]
public class LevelData {
    public float AppVersion;
    public List<EnemyData> Enemies = new List<EnemyData>();
    public EnemyData EnemyTest;
}
