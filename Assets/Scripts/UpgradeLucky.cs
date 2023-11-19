using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeLucky : MonoBehaviour
{
    private int costOfUpgrade = 10;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    public int currentLevel = 1;

    [SerializeField] MoneyManager moneyManager;
    [SerializeField] RandomButtonPlace randomButtonPlace;

    private bool max = false;

    [DllImport("__Internal")]
    private static extern void AddLuckyLevel();

    [SerializeField] string _en;
    [SerializeField] string _ru;

    private string currentMaxText;
    private void Start()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            currentMaxText = _en;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            currentMaxText = _ru;
        }
        else
        {
            currentMaxText = _en;
        }
    }
    public void UpgradeCheck()
    {
        if (moneyManager.totalMoney >= costOfUpgrade && !max)
        {
            Upgrade();
        }
        else if (max)
        {
            SetMax();
        }
    }

    public void Upgrade()
    {
        randomButtonPlace.UpgradeLuckyLevel();
        moneyManager.RemoveMoney(costOfUpgrade);
        costOfUpgrade *= 2;
        costText.text = costOfUpgrade.ToString();
        currentLevel++;
        levelText.text = currentLevel.ToString();
    }

    public void SetMax()
    {
        costText.text = currentMaxText;
        levelText.text = currentMaxText;
        max = true;
    }

    public void ShowAdForUpgradeLucky() //функция для кнопки
    {
        AddLuckyLevel();
        Time.timeScale = 0;
        //music.volume = 0f;
    }

    public void AddLevels()
    {
        Time.timeScale = 1f;
        //music.volume = 1f;
        for (int i = 0; i < 3; i++)
        {
            Upgrade();
        }
    }
}