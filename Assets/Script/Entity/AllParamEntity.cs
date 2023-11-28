using System.Collections.Generic;
using Script.Pub.Singletonbase;
using UnityEngine;

namespace Script.Entity
{
    //全局参数
    public class AllParamEntity:SingletonBaseManager<AllParamEntity>
    {
        //全量的卡牌图鉴
        public static CardInfo[] _allCardInfo;
        //卡组
        private List<CardInfo> _deckCards = new List<CardInfo>();
        
        //四个敌人的位置
        public static Vector3 enemy_1 = new Vector3(666, 120, 0);
        public static Vector3 enemy_2 = new Vector3(666+158, 120, 0);
        public static Vector3 enemy_3 = new Vector3(666+158*2, 120, 0);
        public static Vector3 enemy_4 = new Vector3(666+158*3, 120, 0);
        

        public List<CardInfo> GETDeckCards()
        {
            return _deckCards;
        }
        
       
    }
}