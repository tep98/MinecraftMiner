using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney = 0;
    [SerializeField] Text moneyText;

    [DllImport("__Internal")]
    private static extern void AddMoney();

    private void Start()
    {
        YandexGame.FullscreenShow();
        /*totalMoney = Progress.Instance.PlayerInfo.coins;
        StartSetText();*/
    }

    public void AddMoney(int money)
    {
        totalMoney += money;
        SetText();
    }

    public void RemoveMoney(int money)
    {
        totalMoney -= money;
        SetText();
    }

/*    private void StartSetText()
    {
        moneyText.text = totalMoney.ToString();
    }*/

    private void SetText()
    {
        moneyText.text = totalMoney.ToString();

/*        if (Progress.Instance.PlayerInfo.coins != totalMoney)
        {
            Progress.Instance.PlayerInfo.coins = totalMoney;
            Progress.Instance.Save();
        } */
    }

    public void ShowAdForBonusMoney() //функция для кнопки
    {
        AddMoney();
        Time.timeScale = 0;
        //music.volume = 0f;
    }

    public void AddBonusMoney()
    {
        Time.timeScale = 1f;
        //music.volume = 1f;
        totalMoney += 100;
        SetText();
    }
}
