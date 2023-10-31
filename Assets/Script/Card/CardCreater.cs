using System;
using Script.Entity;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Card
{
    public class CardCreater:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
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

        //进入该区域时调用
        public void OnPointerEnter(PointerEventData eventData)
        {
           Debug.Log(cardName);
           Vector3 currentPostion = gameObject.transform.localPosition;
           currentPostion.y = 20;
           transform.localPosition = currentPostion;
        }

        //离开该区域时调用
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log(cardName);
            Vector3 currentPostion = gameObject.transform.localPosition;
            currentPostion.y = 0;
            transform.localPosition = currentPostion;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("点击了:"+cardName);
            gameObject.transform.SetAsLastSibling();

        }
    }
}