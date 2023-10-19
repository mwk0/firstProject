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
        public CardInfo card_1;
        
        
        private void Start()
        {
            cardName = card_1.carName;
            image.sprite = card_1.cardArt;
            cardText.text = card_1.cardText;
            cardCost.text = card_1.cardCost.ToString();
        }
    }
}