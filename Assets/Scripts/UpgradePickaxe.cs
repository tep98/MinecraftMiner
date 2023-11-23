using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YG;

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

/*    private void Start()
    {
        costOfUpgrade = Progress.Instance.PlayerInfo.costPickaxeUpgrade;
        speed = Progress.Instance.PlayerInfo.pickaxeSpeed;
        currentLevel = Progress.Instance.PlayerInfo.pickaxeLevel;
        StartSetText();
    }*/
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
        currentLevel++;
        SetText();
        // Добавьте логи для отладки
        Debug.Log("Upgraded Pickaxe. Speed: " + speed + ", Cost: " + costOfUpgrade + ", Level: " + currentLevel);

        YandexGame.FullscreenShow();
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

/*        if (Progress.Instance.PlayerInfo.costPickaxeUpgrade != costOfUpgrade ||
        Progress.Instance.PlayerInfo.pickaxeSpeed != speed ||
        Progress.Instance.PlayerInfo.pickaxeLevel != currentLevel)
        {
            Progress.Instance.PlayerInfo.costPickaxeUpgrade = costOfUpgrade;
            Progress.Instance.PlayerInfo.pickaxeSpeed = speed;
            Progress.Instance.PlayerInfo.pickaxeLevel = currentLevel;

            Progress.Instance.Save();
        }*/
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
