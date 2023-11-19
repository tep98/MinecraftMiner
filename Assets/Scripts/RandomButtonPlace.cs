using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomButtonPlace : MonoBehaviour
{
    [SerializeField] private Transform[] Places;
    [SerializeField] private Transform Cross;
    [SerializeField] private Image blockImage;

    private int randPosition;
    private int randBlock;
    private Transform currentPlace;

    private int costOfBlock = 3;
    [SerializeField] MoneyManager moneyManager;

    private int[] luckyRatio = {10, 5, 5, 5, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    private int randNum;

    private int luckyLevel;

    [SerializeField] UpgradeLucky upgradeLucky;

    private void Start()
    {
        luckyLevel = luckyRatio.Length;        
    }
    public void SetNewPosition()
    {
        gameObject.GetComponent<Animator>().SetBool("playBreack", false);
        randPosition = Random.Range(0, Places.Length);
        currentPlace = Places[randPosition];

        Cross.position = currentPlace.position;

        SetNewBlock();
    }

    public void UpgradeLuckyLevel()
    {
        if ( luckyLevel > 1 ) 
        {
            luckyLevel--;   
        }
        else
        {
            upgradeLucky.SetMax();
        }
    }

    public void SetNewBlock()
    {
        randBlock = Random.Range(0, 12);

        randNum = Random.Range(0, luckyLevel);

        switch(randBlock)
        {
            case 0:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/Bambook");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 1:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/BrownWool");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
            case 2:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/BEE");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 4 * luckyRatio[randNum];
                break;
            case 3:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/BlueWool");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
            case 4:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/Brushes");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 5:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/DarkWoodLogs");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 6:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/BlackWoodBlock");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
            case 7:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/Dirt");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 8:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/GrassBlock");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 1 * luckyRatio[randNum];
                break;
            case 9:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/LogsAkacia");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 10:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/OakPlanks");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 3 * luckyRatio[randNum];
                break;
            case 11:
                blockImage.sprite = Resources.Load<Sprite>("Blocks/OakWood");
                moneyManager.AddMoney(costOfBlock);
                costOfBlock = 2 * luckyRatio[randNum];
                break;
        }

        
    }
}
