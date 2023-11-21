using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
public class PlayerInfo
{
    public int coins = 0;
    public int pickaxeLevel = 1;
    public int luckyLevel = 1;
    public int realLuckyLevel = 85;
    public int costPickaxeUpgrade = 10;
    public float pickaxeSpeed = 0.5f;
    public int costLuckyUpgrade = 10;
}


public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static Progress Instance;
    private void Start()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadExtern(); // Вызываем загрузку данных при старте
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        Debug.Log("Saving: " + jsonString);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        // Обновляем данные в Unity
        // ...
    }


}
