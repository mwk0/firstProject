using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Script.Entity;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using Script.Util;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Card
{
    //进入战斗场景触发的事件
    public class StartEvent : MonoBehaviour
    {
        //cardFrame预制体的宽带
        public static float CardFrameWidth;
        //手牌区域的宽度
        public static float HandAreaWidth;
        //手牌区域左右空格
        public static float HandCardPadding = 20;
        

        private PrefabPool _cardPool;//card对象池
        private List<CardInfo> _handCards = new List<CardInfo>();//手牌
        private List<GameObject> _handCardFrames = new List<GameObject>();//手牌物体
        private Queue<CardInfo> _deck = new Queue<CardInfo>();//卡组
        private int _init_handCards_Num = 30;
        private Vector3 deck_icon_position;//卡组的位置，抽卡从这里出现
        private GameObject handCardArea;//手牌区域
        private GameObject leftBoot;
        
        private void Start()
        {
            deck_icon_position = GameObject.Find("deck").transform.position;
            handCardArea = GameObject.Find("handCardArea");
            leftBoot = GameObject.Find("leftBoot");

            CardFrameWidth = Resources.Load("prefabs/cardFrame").GetComponent<RectTransform>().rect.width;
            HandAreaWidth = handCardArea.GetComponent<RectTransform>().rect.width;
            
            //初始化对象池
            BasePoolMap basePoolMap = BasePoolMap.GetInstance();
            _cardPool = basePoolMap.GetPoolByPrefabPath("prefabs/cardFrame", handCardArea.transform, 10, 30,true, null, null, null, null);
            /*deck乱序转队列，形成卡组，第一次洗牌*/
            //卡组列表
            List<CardInfo> deckCards = AllParamEntity.GetInstance().GETDeckCards();
            ShuffleDeck(deckCards);
            //获取手牌数据
            DrawInitCards();
            
        }
        
        
        private void Update()
        {
           
        }
        
        

        //洗牌
        private void ShuffleDeck(List<CardInfo> cardList)
        {
           ListUtil.Shuffle(cardList);
           foreach (var card in cardList)
           {
               _deck.Enqueue(card);
           }
           
        }
        
        //初始抽卡 
        private void DrawInitCards()
        {
            
            for (int i = 0; i < _init_handCards_Num; i++)
            {
                CardInfo card = _deck.Dequeue();
                _handCards.Add(card);
                Debug.Log(card.cardArt.name);
                //前端
                GameObject cardFrame = _cardPool.Get();
                CardCreater create = cardFrame.GetComponent<CardCreater>();
                create.InitCardCreaterByCardinfo(card);
                //设置卡牌初始位置
                Debug.Log(deck_icon_position);
                cardFrame.transform.position = deck_icon_position;
                _handCardFrames.Add(cardFrame);
            }

            ResetHandCardPositon();


        }

        private void ResetHandCardPositon()
        {
            float[] cardXPostionArray = GetHandCardTargetPosition(_handCardFrames.Count);
            //动画执行链
            LTSeq seq = LeanTween.sequence();
            for (int i = 0; i < _handCardFrames.Count; i++)
            {
                seq.append(LeanTween.moveLocalX(_handCardFrames[i], cardXPostionArray[i], 1f).setEaseInOutQuint());
            }
        }
        
        //计算所有手牌的位置
        private float[] GetHandCardTargetPosition(int handCardNum)
        {
            float[] cardXPostionArray = new float[handCardNum];
            cardXPostionArray[0] = HandCardPadding;//第一张牌的位置在可用区域最左侧
            //可用区域宽度
            float areaWidth = HandAreaWidth - CardFrameWidth - (HandCardPadding * 2);
            Debug.Log(areaWidth);
            if (CardFrameWidth * handCardNum < areaWidth)//手牌很少
            {
                for (int i = 1; i < handCardNum; i++)
                {
                    cardXPostionArray[i] = cardXPostionArray[0] + CardFrameWidth*i;
                }
            }
            else//手牌较多，覆盖排列
            {
                float space = areaWidth / handCardNum;
                Debug.Log(space);
                for (int i = 1; i < handCardNum; i++)
                {
                    cardXPostionArray[i] = cardXPostionArray[0] + space * i;
                    Debug.Log(cardXPostionArray[i]);
                }
            }

            return cardXPostionArray;
        }

    }
}