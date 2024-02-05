using System.Collections.Generic;
using Script.Entity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Card
{
    public class MonsterCreater:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
    {
        public string monsterName;

        public MonsterInfo MonsterInfo;
        public void OnPointerEnter(PointerEventData eventData)
        {
            HandCardArea handCardArea = HandCardArea.GetInstance();
            BattleManager battleManager = BattleManager.GetInstance();
            //伤害预估
            if (handCardArea.stateCode is AppConstant.handCardState_cardToUse)
            {
                List<ExpectResult> results = BattleManager.GetInstance().Expect(handCardArea.cardToUse.cardInfo,this.MonsterInfo,battleManager.currentHero);
                //todo 前端显示
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //取消伤害预估
            if (HandCardArea.GetInstance().stateCode is AppConstant.handCardState_cardToUse)
            {
                //todo 前端去除显示
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //卡牌结算
            
        }
    }
}