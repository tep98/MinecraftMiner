using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney = 0;
    [SerializeField] Text moneyText;

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

    private void SetText()
    {
        moneyText.text = totalMoney.ToString();
    }
}
