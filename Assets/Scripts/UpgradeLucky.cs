using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YG;
using System.Threading.Tasks;

public class UpgradeLucky : MonoBehaviour
{
    private int costOfUpgrade = 10;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    public int currentLevel = 1;

    [SerializeField] MoneyManager moneyManager;
    [SerializeField] RandomButtonPlace randomButtonPlace;

    private bool max = false;


    [SerializeField] string _en;
    [SerializeField] string _ru;

    private string currentMaxText;

/*    private void Start()
    {
        currentLevel = Progress.Instance.PlayerInfo.luckyLevel;
        costOfUpgrade = Progress.Instance.PlayerInfo.costLuckyUpgrade;
        StartSetText();
    }*/

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetData;
    }

    public async void GetData()
    {
        while (!YandexGame.SDKEnabled)
        {
            await Task.Delay(200);
        }
        await Task.Delay(100);
        
        if (YandexGame.EnvironmentData.language == "en")
        {
            currentMaxText = _en;
        }

        if (YandexGame.EnvironmentData.language == "ru")
        {
            currentMaxText = _ru;
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
/*        Progress.Instance.Save();*/
    }

    public void Upgrade(int levels = 1)
    {
        randomButtonPlace.UpgradeLuckyLevel();
        moneyManager.RemoveMoney(costOfUpgrade);
        costOfUpgrade *= 2;
        currentLevel+= levels;

        SetText();

        YandexGame.FullscreenShow();
        /*        if (Progress.Instance.PlayerInfo.luckyLevel != currentLevel || Progress.Instance.PlayerInfo.costLuckyUpgrade != costOfUpgrade)
                {
                    SetText();
                }*/
    }

/*    public void StartSetText()
    {
        costText.text = costOfUpgrade.ToString();
        levelText.text = currentLevel.ToString();
    }*/

    public void SetText()
    {
        costText.text = costOfUpgrade.ToString();
        levelText.text = currentLevel.ToString();

/*        if (Progress.Instance.PlayerInfo.luckyLevel != currentLevel || Progress.Instance.PlayerInfo.costLuckyUpgrade != costOfUpgrade)
        {
            Progress.Instance.PlayerInfo.luckyLevel = currentLevel;
            Progress.Instance.PlayerInfo.costLuckyUpgrade = costOfUpgrade;

            Progress.Instance.Save();
        }  */
    }

    public void SetMax()
    {
        costText.text = currentMaxText;
        levelText.text = currentMaxText;
        max = true;
    }

/*    public void ShowAdForUpgradeLucky() //функция для кнопки
    {
        AddLuckyLevel();
        Time.timeScale = 0;
        //music.volume = 0f;
    }*/
}