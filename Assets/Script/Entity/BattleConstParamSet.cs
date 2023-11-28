using System.Collections.Generic;
using Script.Pub.Singletonbase;
using UnityEngine;

namespace Script.Entity
{
    public class BattleConstParamSet:SingletonBaseManager<BattleConstParamSet>
    {
        //cardFrame预制体的宽度
        public  float CardFrameWidth;
        //手牌区域的宽度
        public  float HandAreaWidth;
        //手牌区域左右空格
        public float HandCardPadding = 20;
        
        public GameObject _cardFramePrefab;//卡牌预制体
        public List<GameObject> _handCardFrames = new List<GameObject>();//手牌
        public Queue<GameObject> _deckQueue = new Queue<GameObject>();//卡组

        public int _init_handCards_Num = 20;
        public Vector3 deck_icon_position;//卡组的位置，抽卡从这里开始移动
        public GameObject handCardArea;//手牌区域
        public GameObject deckCardArea;//卡组区域
        public GameObject graveArea;//墓地区域
        public Vector3 deckOutPosition;//屏幕外的卡组卡牌位置
        public Vector3 graveOutPosition;//屏幕外的墓地卡牌位置
        
    }
}