using UnityEngine;

namespace Script.Entity
{
    [CreateAssetMenu(fileName = "newCard",menuName = "card")]
    //卡牌信息实体类
    public class CardInfo : ScriptableObject
    {

        //编号
        public string no;
        //名称
        public string carName;
        public Sprite cardArt;
        public string cardText;
        public int cardCost_str;//力量消耗
        public int cardCost_int;//智力消耗
        //目标 dcba 1234 
        //4    1 or 2 or 3 or 4
        //12   1 and 2
        //00    self
        //99   no target
        public string target;
        //类型
        public int[] type;
        //基础伤害
        public int baseDamage;
        //额外伤害 = 主属性*系数
        public int extraDamage_Primary;//字典值
        public int extraDamage_factor;
        //抽卡数量
        public int drawNum;
        //弃牌数量
        public int disCardNum;
        //毒量
        public int posionNum;
        //毒回合
        public int posionRound;
    }
}