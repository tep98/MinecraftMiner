using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney = 0;
    public int maxMoney = 0;
    [SerializeField] Text moneyText;

    private void Start()
    {
        YandexGame.FullscreenShow();

        if (YandexGame.SDKEnabled)
        {
            LoadSaveCloud();
        }

    }

    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;

    public void AddMoney(int money)
    {
        totalMoney += money;
        SetText();

        TrySaveHighScore();
    }

    public void RemoveMoney(int money)
    {
        totalMoney -= money;
        SetText();
    }

    private void SetText()
    {
        moneyText.text = totalMoney.ToString();

        MySave();
    }

    public void LoadSaveCloud()
    {
        totalMoney = YandexGame.savesData.coins;
        maxMoney = YandexGame.savesData.maxMoney;

        SetText();
    }

    public void MySave()
    {
        YandexGame.savesData.coins = totalMoney;
        YandexGame.savesData.maxMoney = maxMoney;

        YandexGame.SaveProgress();
    }

    private void TrySaveHighScore()
    {
        if (totalMoney <= maxMoney)
        {
            return;
        }
        else
        {
            maxMoney = totalMoney;

            YandexGame.NewLeaderboardScores("Leaderboard", maxMoney);
        }
        
    }
}
