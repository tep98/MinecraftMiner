using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RandomButtonPlace : MonoBehaviour
{
    [SerializeField] private Transform[] Places;
    [SerializeField] private Transform Cross;
    [SerializeField] private Image blockImage;

    private int randPosition;
    private int randBlock;
    private Transform currentPlace;

    private int costOfBlock = 2;
    [SerializeField] MoneyManager moneyManager;

    public int[] luckyRatio = {10, 5, 5, 5, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    private int randNum;

    private int luckyLevel;

    [SerializeField] UpgradeLucky upgradeLucky;

    private void Start()
    {
        luckyLevel = luckyRatio.Length;

        if (YandexGame.SDKEnabled)
        {
            LoadSaveCloud();
        }
    }

    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;

    public void SetNewPosition()
    {
        gameObject.GetComponent<Animator>().SetBool("playBreack", false);
        randPosition = Random.Range(0, Places.Length);
        currentPlace = Places[randPosition];

        Cross.position = currentPlace.position;

        SetNewBlock();

        MySave();
    }

    public void UpgradeLuckyLevel(int levels)
    {
        if ( luckyLevel > 1 ) 
        {
            luckyLevel-= levels;
        }
        else
        {
            upgradeLucky.SetMax(); 
        }
        MySave();
    }

    public void LoadSaveCloud()
    {
        luckyLevel = YandexGame.savesData.realLuckyLevel;
    }

    public void MySave()
    {
        YandexGame.savesData.realLuckyLevel = luckyLevel;

        YandexGame.SaveProgress();
    }

    public void SetNewBlock()
    {
        randBlock = Random.Range(0, 12);

        randNum = Random.Range(0, luckyLevel);

        switch (randBlock)
        {
            case 0:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/tnt_side");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 4 * luckyRatio[randNum];
                break;
            case 1:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/oak_planks");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
            case 2:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/nether_gold_ore");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 3:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/nether_bricks");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 4:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/melon_side");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 5:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/Obsidian");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 6:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/grass_block_side");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 7:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/end_stone");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
            case 8:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/emerald_ore");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 5 * luckyRatio[randNum];
                break;
            case 9:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/chiseled_quartz_block_top");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 10:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/bricks");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
            case 11:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/birch_log");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 12:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/bee_nest_side");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
        }

        
    }
}
