using System.Collections.Generic;
using Script.Pub.Singletonbase;

namespace Script.Entity
{
    //全局参数
    public class AllParamEntity:SingletonBaseManager<AllParamEntity>
    {
        //卡组
        private List<CardInfo> _deckCards = new List<CardInfo>();

        public List<CardInfo> GETDeckCards()
        {
            return _deckCards;
        }
    }
}