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
        public int cardCost;
        //目标 dcba 1234 self
        public string target;
        //类型
        public string[] type;
        //基础伤害
        public int baseDamage;
        //额外伤害 = 主属性*系数
        public int extraDamage_Primary;//字典值
        public int extraDamage_factor;
        //抽卡数量
        public int drawNum;
        //弃牌数量
        public int disCardNum;
    }
}