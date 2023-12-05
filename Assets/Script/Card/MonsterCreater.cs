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
            //伤害预估
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //取消伤害预估
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //卡牌结算
            
        }
    }
}