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
            if (HandCardArea.GetInstance().cardToUse == null)
            {
                Vector3 currentPostion = gameObject.transform.localPosition;
                currentPostion.y = 20;
                transform.localPosition = currentPostion;
            }
        }

        //离开该区域时调用
        public void OnPointerExit(PointerEventData eventData)
        {
            if (HandCardArea.GetInstance().cardToUse == null)
            {
                Vector3 currentPostion = gameObject.transform.localPosition;
                currentPostion.y = 0;
                transform.localPosition = currentPostion;
            }
        }

        private float lastClickTime = 0;
        public void OnPointerClick(PointerEventData eventData)
        {

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (Time.time - lastClickTime < 0.3f)
                {
                    Debug.Log("双击了:"+cardName);

                }
                else
                {
                    Debug.Log("单击了:"+cardName);
                    gameObject.transform.SetAsLastSibling();
                    HandCardArea.GetInstance().cardToUse = transform;

                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)//右键取消选中
            {
                HandCardArea.GetInstance().cardToUse = null;
            }
            
            

            lastClickTime = Time.time;

        }
        
        
        
    }
}