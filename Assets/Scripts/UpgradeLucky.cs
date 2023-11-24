using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UpgradeLucky : MonoBehaviour
{
    private int costOfUpgrade = 10;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    public int currentLevel = 1;

    [SerializeField] MoneyManager moneyManager;
    [SerializeField] RandomButtonPlace randomButtonPlace;

    private bool max = false;

    private string currentMaxText;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            LoadSaveCloud();
        } 
    }

    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;

    public void GetMaxTextValue(string currentMax)
    {
        currentMaxText = currentMax;
    }

    public void UpgradeCheck()
    {
        if (moneyManager.totalMoney >= costOfUpgrade && !max)
        {
            Upgrade();
            moneyManager.RemoveMoney(costOfUpgrade);
        }
        else if (max)
        {
            SetMax();
        }
    }

    public void Upgrade(int levels = 1)
    {
        randomButtonPlace.UpgradeLuckyLevel(levels);
        
        costOfUpgrade *= 2;
        currentLevel+= levels;
        SetText();

        YandexGame.FullscreenShow();
    }

    public void SetText()
    {
        costText.text = costOfUpgrade.ToString();
        levelText.text = currentLevel.ToString();

        if (currentLevel >= 87)
        {
            SetMax();
        }

        MySave();
    }

    public void SetMax()
    {
        costText.text = currentMaxText;
        levelText.text = currentMaxText;
        max = true;
    }

    public void LoadSaveCloud()
    {
        currentLevel = YandexGame.savesData.luckyLevel;
        costOfUpgrade = YandexGame.savesData.costLuckyUpgrade;

        SetText();
    }

    public void MySave()
    {
        YandexGame.savesData.luckyLevel = currentLevel;
        YandexGame.savesData.costLuckyUpgrade = costOfUpgrade;

        YandexGame.SaveProgress();
    }
}