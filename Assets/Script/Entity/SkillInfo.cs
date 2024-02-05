namespace Script.Entity
{
    /// <summary>
    /// hero技能
    /// </summary>
    public class SkillInfo
    {
        public string name;
        public SkillTriggerType TriggerType;
        public SkillEffectType EffectType;
        public int value;//数值
    }

    /// <summary>
    /// 技能效果类型
    /// </summary>
    public enum SkillEffectType
    {
        Draw,
        Damage,
        Buff,
        DeBuff,
        Poison
    }

    /// <summary>
    /// 技能触发类型
    /// </summary>
    public enum SkillTriggerType
    {
        PhaseBattleStart,//战斗开始
        PhaseBattleEnd,//战斗结束
        PhaseRoundStart,//轮次开始
        PhaseRoundEnd,//轮次结束
        PhaseTurnStart,//回合开始
        PhaseTurnEnd,//回合结束
        Attack,//攻击触发
        Attacked,//被攻击触发
        Hurt,//受伤触发
        Damage,//造成伤害触发
        Kill,//击杀触发
        Draw,//抽牌触发
        GetArmor,//获取护甲触发
        LoseArmor,//失去护甲触发
        GetPoison,//中毒触发
        SetPoison//放毒触发
    }
}