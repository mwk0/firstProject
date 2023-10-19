using UnityEngine;

namespace Script.Entity
{
    [CreateAssetMenu(fileName = "newCard",menuName = "card")]
    //卡牌信息实体类
    public class CardInfo : ScriptableObject
    {
        
        //名称
        public string carName;
        public Sprite cardArt;
        public string cardText;
        public int cardCost;
        
    }
}