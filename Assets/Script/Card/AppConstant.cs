
namespace Script.Card
{
    //常量类
    public class AppConstant
    {
        //卡牌类型
        public const int cardType_discard = 0;
        public const int cardType_draw = 1;
        public const int cardType_damage = 2;
        public const int cardType_buff = 3;
        public const int cardType_debuff = 4;
        public const int cardType_poison = 5;
        //主属性
        public const int hero_attribute_str = 1;
        //public const int hero_attribute_agi = 2;
        public const int hero_attribute_int = 3;
        
        //打牌状态
        public const int handCardState_wait = 0;//待机
        public const int handCardState_cardToUse = 1;//选择手牌后与选择目标前
        public const int handCardState_discard = 2;//等待弃牌
        public const int handCardState_discard_move = 3;//弃牌动画期间
        public const int handCardState_drawCards = 4;//摸牌动画期间
        public const int handCardState_effect = 5;//计算效果期间
        public const int handCardState_detail = 6;//查看详细信息
        
        //预估的结算结果类型
        public const int expectResultType_discard = 0;//弃牌
        public const int expectResultType_draw = 1;//抽牌
        public const int expectResultType_damage = 2;//伤害
        public const int expectResultType_buff = 3;//buff
        public const int expectResultType_debuff = 4;//debuff
        public const int expectResultType_poison = 5;//毒
        public const int expectResultType_heal = 6;//治疗
        public const int expectResultType_death = 9;//死亡

    }
}