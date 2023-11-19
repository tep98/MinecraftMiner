using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePickaxe : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private float speed = 0.5f;
    private int costOfUpgrade = 10;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    public int currentLevel = 1;

    [SerializeField] MoneyManager moneyManager;

    [DllImport("__Internal")]
    private static extern void AddPickaxeLevel();
    public void UpgradeCheck()
    {
        if(moneyManager.totalMoney >= costOfUpgrade)
        {
            Upgrade();
        }
    }

    public void Upgrade()
    {
        speed += 0.2f;
        anim.SetFloat("animSpeed", speed);
        moneyManager.RemoveMoney(costOfUpgrade);
        costOfUpgrade *= 2;
        costText.text = costOfUpgrade.ToString();
        currentLevel++;
        levelText.text = currentLevel.ToString();
    }

    public void ShowAdForUpgradePickaxe() //функция для кнопки
    {
        AddPickaxeLevel();
        Time.timeScale = 0;
        //music.volume = 0f;
    }

    public void AddLevels()
    {
        Time.timeScale = 1f;
        //music.volume = 1f;
        for (int i = 0; i<3; i++)
        {
            Upgrade();
        }
    }
}
