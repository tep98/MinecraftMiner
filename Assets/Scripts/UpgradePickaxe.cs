using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePickaxe : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private float speed = 0.5f;
    private int costOfUpgrade = 3;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    private int currentLevel = 1;

    [SerializeField] MoneyManager moneyManager;
    public void Upgrade()
    {
        if(moneyManager.totalMoney >= costOfUpgrade)
        {
            speed += 0.2f;
            anim.SetFloat("animSpeed", speed);
            moneyManager.RemoveMoney(costOfUpgrade);
            costOfUpgrade *= 2;
            costText.text = costOfUpgrade.ToString();
            currentLevel++;
            levelText.text = currentLevel.ToString();
        }
    }
}
