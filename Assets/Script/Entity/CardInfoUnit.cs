using System;
using System.Collections.Generic;
using Script.Card;
using Script.Prefabs;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Script.Entity
{
    [Serializable]
    public class CardInfoUnit:CardInfo
    {
        public int race;
        public int level;
        public int rarity;
        public int job;
        public int health;
        public int morale;
        public int attack;
        public int counterAttack;
        public int defense;
        public int speed;
        public int required;
        public List<UnitSkillInfo> SkillInfos;
        
    }
}