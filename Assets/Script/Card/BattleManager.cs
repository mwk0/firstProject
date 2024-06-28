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