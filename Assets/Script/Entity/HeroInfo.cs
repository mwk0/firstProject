using System.Collections.Generic;

namespace Script.Entity
{
    /// <summary>
    /// 队员信息
    /// </summary>
    public class HeroInfo
    {
        public string name;
        public HeroWork Work;//职业
        public int attrStr;//力
        //public int attrAgi;//敏
        public int attrInt;//智
        public int health;//生命
        public int defense;//防御力
        public int speed;//速度
        public List<SkillInfo> skills;
        public string desc;
    }

    public enum HeroWork
    {
        Knight,
        Archer,
        Wizard
        
    }
}