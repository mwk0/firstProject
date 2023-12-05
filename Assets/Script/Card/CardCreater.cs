using System;
using System.Linq;
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
            int stateCode = HandCardArea.GetInstance().stateCode;
            if (stateCode is AppConstant.handCardState_wait or AppConstant.handCardState_discard)
            {
                CardUp();
            }
        }

        //离开该区域时调用
        public void OnPointerExit(PointerEventData eventData)
        {
            int stateCode = HandCardArea.GetInstance().stateCode;
            if (stateCode is AppConstant.handCardState_wait or AppConstant.handCardState_discard)
            {
                CardDown();
            }
        }

        private float lastClickTime = 0;
        public void OnPointerClick(PointerEventData eventData)
        {
            int stateCode = HandCardArea.GetInstance().stateCode;
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (Time.time - lastClickTime < 0.3f)
                {
                    Debug.Log("双击了:"+cardName);

                }
                else
                {
                    Debug.Log("单击了:"+cardName);
                    //待机状态
                    if (stateCode is AppConstant.handCardState_wait)
                    {
                        Debug.Log("当前为待机状态");
                        if (cardInfo.target.Length>1)
                        {
                            Debug.Log("此牌不需要目标");
                            //结算
                            
                        }
                        else
                        {
                            HandCardArea.GetInstance().cardToUse = this;
                            HandCardArea.GetInstance().stateCode = AppConstant.handCardState_cardToUse;
                        }
                        
                    }else if (stateCode is AppConstant.handCardState_discard)
                    {
                        Debug.Log("当前为弃牌状态");
                        //调用弃牌事件
                    }
                    gameObject.transform.SetAsLastSibling();

                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)//右键
            {
                if (stateCode is AppConstant.handCardState_wait)//待机时可以放大查看
                {
                    HandCardArea.GetInstance().stateCode = AppConstant.handCardState_detail;
                    
                }
            }
            
            lastClickTime = Time.time;

        }


        //把手牌放下去
        public void CardDown()
        {
            Vector3 currentPostion = gameObject.transform.localPosition;
            currentPostion.y = 0;
            transform.localPosition = currentPostion;
        }
        //把手牌抬起来
        public void CardUp()
        {
            Vector3 currentPostion = gameObject.transform.localPosition;
            currentPostion.y = 20;
            transform.localPosition = currentPostion;
        }
        
        
        
    }
}