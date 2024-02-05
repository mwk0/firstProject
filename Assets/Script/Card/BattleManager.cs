using System.Collections.Generic;
using System.Linq;
using Script.Entity;
using Script.Pub.Singletonbase;

namespace Script.Card
{
    /// <summary>
    /// 管理卡牌效果结算的方法类
    /// </summary>
    public class BattleManager:SingletonMonoManager<BattleManager>
    {
        ///轮次
        public int RoundCount;
        /// 当前回合的角色
        public HeroInfo currentHero;

        /// <summary>
        /// 预估卡牌结算
        /// </summary>
        /// <param name="cardInfo"></param>
        /// <param name="monsterInfo"></param>
        /// <returns></returns>
        public List<ExpectResult> Expect(CardInfo cardInfo,MonsterInfo monsterInfo,HeroInfo heroInfo)
        {
            List<ExpectResult> expectResults = new List<ExpectResult>();
            int[] cardTypes = cardInfo.type;
            if (cardTypes.Contains(AppConstant.cardType_draw))
            {
                ExpectResult expectResult = new ExpectResult(AppConstant.expectResultType_draw,cardInfo.drawNum);
                expectResults.Add(expectResult);
            }

            if (cardTypes.Contains(AppConstant.cardType_discard))
            {
                ExpectResult expectResult = new ExpectResult(AppConstant.expectResultType_discard, cardInfo.disCardNum);
                expectResults.Add(expectResult);
            }

            if (cardTypes.Contains(AppConstant.cardType_buff))
            {
                //一般不会加buff
            }

            if (cardTypes.Contains(AppConstant.cardType_debuff))
            {
                
            }

            if (cardTypes.Contains(AppConstant.cardType_damage))
            {
                
            }

            if (cardTypes.Contains(AppConstant.cardType_poison))
            {
                
            }
            return expectResults;
        }
        
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="cardInfo"></param>
        /// <param name="monsterInfo"></param>
        public void HandleCardInfo(CardInfo cardInfo,MonsterInfo monsterInfo)
        {
            
        }
        
    }

    /// <summary>
    /// 卡牌结算预计的结果类
    /// </summary>
    public class ExpectResult
    {
        //预计结果类型，静态字典值
        public int type;
        public int value;//数值

        public ExpectResult()
        {
        }

        public ExpectResult(int type, int value)
        {
            this.type = type;
            this.value = value;
        }
    }
}