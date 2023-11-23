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
}
