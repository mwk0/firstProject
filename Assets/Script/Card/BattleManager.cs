using System.Collections.Generic;
using Script.Entity;
using Script.Pub.Singletonbase;

namespace Script.Card
{
    public class BattleManager:SingletonMonoManager<BattleManager>
    {
        public List<ExpectResult> Expect(CardInfo cardInfo,MonsterInfo monsterInfo)
        {
            List<ExpectResult> expectResults = new List<ExpectResult>();
            
            return expectResults;
        }
        
        public void HandleCardInfo(CardInfo cardInfo,MonsterInfo monsterInfo)
        {
            
        }
    }

    public class ExpectResult
    {
        //预计结果类型，静态字典值
        public string type;
        public int value;//数值
    }
}