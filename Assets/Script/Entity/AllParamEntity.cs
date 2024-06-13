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
        
        
        public List<CardInfo> GETDeckCards()
        {
            return _deckCards;
        }
        
       
    }
}