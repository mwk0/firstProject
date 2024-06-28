using Script.Entity;
using Script.Prefabs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Card
{
    public class CardCreater:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler,IDragHandler,IBeginDragHandler,IEndDragHandler
    {

        public string cardName;
        public Image cardArt;
        public TextMeshProUGUI cardText;
        public TextMeshProUGUI cardCost;
        public TextMeshProUGUI attack;
        public TextMeshProUGUI defense;
        public TextMeshProUGUI health;
        public TextMeshProUGUI morale;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI counterAttack;
        public TextMeshProUGUI required;

        public void InitCardCreaterByCardinfo(CardInfo cardInfo)
        {
            cardName = cardInfo.cardName;
            //部队卡牌的样式
            if (cardInfo is CardInfoUnit)
            {
                CardInfoUnit cardInfoUnit = cardInfo as CardInfoUnit;
                cardArt.sprite = Resources.Load("cardSprite/"+cardInfoUnit.cardArt,typeof(Sprite)) as Sprite;
                cardText.text = cardInfoUnit.cardText;
                cardCost.text = cardInfoUnit.cardCost.ToString();
                attack.text = cardInfoUnit.attack.ToString();
                defense.text = cardInfoUnit.defense.ToString();
                health.text = cardInfoUnit.health.ToString();
                morale.text = cardInfoUnit.morale.ToString();
                speed.text = cardInfoUnit.speed.ToString();
                counterAttack.text = cardInfoUnit.counterAttack.ToString();
                required.text = cardInfoUnit.required.ToString();
            }
            else
            {
                
            }
        }
        
        private void Start()
        {
          
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
            string errorMessage;
            /*if (!checkPointCondition(out errorMessage))
            {
                //TODO 显示提示信息
                return;
            }*/
            
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

        /// <summary>
        /// 检查是否可用
        /// </summary>
        /// <param name="errorDetail"></param>
        /// <returns></returns>
        public bool checkPointCondition(out string errorDetail)
        {
            errorDetail = "";
            return true;
        }


        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos;//用以接收世界空间中的点
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle
                (
                    (RectTransform)transform, //要在其中查找点的 RectTransform
                    eventData.position, //屏幕空间位置
                    eventData.pressEventCamera, //与屏幕空间位置关联的摄像机
                    out pos //世界空间中的点
                )
               )
            {
                transform.position = pos;
            }
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.transform.position, transform.position,Mathf.Infinity,6,-Mathf.Infinity,Mathf.Infinity);
            if (hitInfo.collider != null)
            {
                BattleCell hitBattleCell = hitInfo.transform.gameObject.GetComponent<BattleCell>();
                bool isEnemy = hitBattleCell.IsEnemy;
                int cellType = hitBattleCell.BattleCellType;
                
            }
        }
    }
}