using System.Collections.Generic;

namespace Script.Entity
{
    //全局参数
    public class AllParamEntity
    {
        //卡组
        private List<CardInfo> _deckCards = new List<CardInfo>();

        public List<CardInfo> GETDeckCards()
        {
            return _deckCards;
        }
    }
}