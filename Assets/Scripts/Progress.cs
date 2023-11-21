using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
public class PlayerInfo
{
/*    public int coins = 0;
    public int pickaxeLevel = 1;
    public int luckyLevel = 1;
    public int realLuckyLevel = 85;
    public int costPickaxeUpgrade = 10;
    public float pickaxeSpeed = 0.5f;
    public int costLuckyUpgrade = 10;*/

    public int coins;
    public int pickaxeLevel;
    public int luckyLevel;
    public int realLuckyLevel;
    public int costPickaxeUpgrade;
    public float pickaxeSpeed;
    public int costLuckyUpgrade;

}


public class Progress : MonoBehaviour
{
    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static Progress Instance;
    private void Awake()
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

        Debug.Log(Progress.Instance.PlayerInfo.coins);
        Debug.Log(Progress.Instance.PlayerInfo.costPickaxeUpgrade);
        Debug.Log(Progress.Instance.PlayerInfo.pickaxeSpeed);
        Debug.Log(Progress.Instance.PlayerInfo.pickaxeLevel);
        Debug.Log(Progress.Instance.PlayerInfo.luckyLevel);
        Debug.Log(Progress.Instance.PlayerInfo.costLuckyUpgrade);
    }

}
