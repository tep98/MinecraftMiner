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

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            LoadSaveCloud();
        }
    }

    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;

    public void UpgradeCheck()
    {
        if(moneyManager.totalMoney >= costOfUpgrade)
        {
            Upgrade();
            moneyManager.RemoveMoney(costOfUpgrade);
        }
    }

    public void Upgrade(int levels = 1)
    {
        speed += (0.2f * levels);
        anim.SetFloat("animSpeed", speed);
        costOfUpgrade *= 2;
        currentLevel+= levels;
        SetText();
        // Добавьте логи для отладки
        Debug.Log("Upgraded Pickaxe. Speed: " + speed + ", Cost: " + costOfUpgrade + ", Level: " + currentLevel);

        YandexGame.FullscreenShow();
    }


    public void SetText()
    {
        costText.text = costOfUpgrade.ToString();
        levelText.text = currentLevel.ToString();

        MySave();
    }

    public void LoadSaveCloud()
    {
        currentLevel = YandexGame.savesData.pickaxeLevel;
        costOfUpgrade = YandexGame.savesData.costPickaxeUpgrade;
        speed = YandexGame.savesData.pickaxeSpeed;

        SetText();
    }

    public void MySave()
    {
        YandexGame.savesData.pickaxeLevel = currentLevel;
        YandexGame.savesData.costPickaxeUpgrade = costOfUpgrade;
        YandexGame.savesData.pickaxeSpeed = speed;

        YandexGame.SaveProgress();
    }
}
