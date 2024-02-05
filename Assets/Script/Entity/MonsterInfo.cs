using System.Collections.Generic;
using UnityEngine;

namespace Script.Entity
{
    [CreateAssetMenu(fileName = "newMonster",menuName = "monster")]
    //敌人实体类信息
    public class MonsterInfo : ScriptableObject
    {
        //编号
        public string no;
        public string monsterName;
        public string type;
        public string level;
        public string attack;
        public string defense;
        public string health;
        public string speed;
        public string desc;
        public List<BehaviorInfo> behaviorList;

    }
}