using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Example;
using System.Threading.Tasks;

public class UiManager : MonoBehaviour
{
    [SerializeField] UpgradePickaxe pickaxeManager;
    [SerializeField] UpgradeLucky luckyManager;
    [SerializeField] MoneyManager coinsManager;

    [SerializeField] Button pickaxeButton;
    [SerializeField] Button luckyButton;
    [SerializeField] Button coinsButton;

    [SerializeField] string _en;
    [SerializeField] string _ru;

    private void Start()
    {
        pickaxeButton.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
        luckyButton.onClick.AddListener(delegate { ExampleOpenRewardAd(2); });
        coinsButton.onClick.AddListener(delegate { ExampleOpenRewardAd(3); });
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
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
            luckyManager.GetMaxTextValue(_en);
        }

        if (YandexGame.EnvironmentData.language == "ru")
        {
            luckyManager.GetMaxTextValue(_ru);
        }
    }

    private void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void Rewarded(int id)
    {
        if (id == 1)
        {
            pickaxeManager.Upgrade(3);
        }
        else if (id == 2)
        {
            luckyManager.Upgrade(3);
        }
        else if (id == 3)
        {
            coinsManager.AddMoney(100);
        }
    }


}
