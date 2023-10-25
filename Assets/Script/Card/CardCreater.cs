using System;
using Script.Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Card
{
    public class CardCreater:MonoBehaviour
    {
       

        public string cardName;
        public Image image;
        public TextMeshProUGUI cardText;
        public TextMeshProUGUI cardCost;
        public CardInfo cardInfo;
        

        //用cardInfo初始化
        public void InitCardCreaterByCardinfo()
        {
            cardName = cardInfo.carName;
            image.sprite = cardInfo.cardArt;
            cardText.text = cardInfo.cardText;
            cardCost.text = cardInfo.cardCost.ToString();
        }
    }
}