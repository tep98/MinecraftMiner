using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeLucky : MonoBehaviour
{
    private int costOfUpgrade = 0;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    private int currentLevel = 1;

    [SerializeField] MoneyManager moneyManager;
    [SerializeField] RandomButtonPlace randomButtonPlace;

    private bool max = false;
    public void Upgrade()
    {
        if (moneyManager.totalMoney >= costOfUpgrade && !max)
        {
            randomButtonPlace.UpgradeLuckyLevel();
            moneyManager.RemoveMoney(costOfUpgrade);
            costOfUpgrade *= 2;
            costText.text = costOfUpgrade.ToString();
            currentLevel++;
            levelText.text = currentLevel.ToString();
        }
        else
        {
            SetMax();
        }
    }

    public void SetMax()
    {
        costText.text = "Max";
        levelText.text = "Max";
        max = true;
    }
}