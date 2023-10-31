using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Script.Entity;
using Script.Pub.Event;
using Script.Pub.Pool;
using Script.Pub.Singletonbase;
using Script.Util;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Script.Card
{
    //进入战斗场景触发的事件
    public class StartEvent : MonoBehaviour
    {
        //事件系统
        public static EventCenter EventCenter;

        //cardFrame预制体的宽带
        public static float CardFrameWidth;
        //手牌区域的宽度
        public static float HandAreaWidth;
        //手牌区域左右空格
        public static float HandCardPadding = 20;

        private GameObject _cardFramePrefab;//卡牌预制体
        private List<GameObject> _handCardFrames = new List<GameObject>();//手牌
        private Queue<GameObject> _deckQueue = new Queue<GameObject>();//卡组

        private int _init_handCards_Num = 30;
        private Vector3 deck_icon_position;//卡组的位置，抽卡从这里开始移动
        private GameObject handCardArea;//手牌区域
        private GameObject deckCardArea;//卡组区域
        private GameObject graveArea;//墓地区域
        private Vector3 deckOutPosition;//屏幕外的卡组卡牌位置
        private Vector3 graveOutPosition;//屏幕外的墓地卡牌位置
       
        private void Awake()
        {
            EventCenter = EventCenter.GetInstance();
            /*EventCenter.AddListenerOne(AppConstant.event_initBattleGround,InitDeck);
            EventCenter.AddListener(AppConstant.event_drawCards,drawCards);*/
            Action<List<CardInfo>> initDeck = InitDeck;
            Action<int> drawCards = DrawCards;
            EventCenter.AddListener(EventDefine.initDeck,initDeck);
            EventCenter.AddListener(EventDefine.drawCards,drawCards);
        }
        
        private void Start()
        {
            _cardFramePrefab = (GameObject) Resources.Load("prefabs/cardFrame");
            handCardArea = GameObject.Find("handCardArea");
            deckCardArea = GameObject.Find("deck");
            graveArea = GameObject.Find("grave");
            deck_icon_position = deckCardArea.transform.position;
            deckOutPosition = GameObject.Find("deckOut").transform.position;
            graveOutPosition = GameObject.Find("graveOut").transform.position;
            CardFrameWidth = _cardFramePrefab.GetComponent<RectTransform>().rect.width;
            HandAreaWidth = handCardArea.GetComponent<RectTransform>().rect.width;
            
            //生成卡组
            /*deck乱序转队列，形成卡组，第一次洗牌*/
            List<CardInfo> deckCardInfoList = AllParamEntity.GetInstance().GETDeckCards();
            //InitDeck(deckCardInfoList);
            EventCenter.TriggerEvent(EventDefine.initDeck,deckCardInfoList);
            //抽初始卡牌
            //DrawCards(_init_handCards_Num);
            EventCenter.TriggerEvent(EventDefine.drawCards,_init_handCards_Num);
            
        }
        
        
        private void Update()
        {
           
        }



        //游戏开始生成卡组
        private void InitDeck(List<CardInfo> deckCardInfoList)
        {
            //乱序
            ListUtil.Shuffle(deckCardInfoList);
            foreach (var cardInfo in deckCardInfoList)
            {
                GameObject cardFrame = Instantiate(_cardFramePrefab,deckCardArea.transform);
                //缩小10倍
                cardFrame.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                cardFrame.transform.position = deckOutPosition;//放到屏幕外
                //设置卡牌信息
                CardCreater cardCreater = cardFrame.GetComponent<CardCreater>();
                cardCreater.cardInfo = cardInfo;
                cardCreater.InitCardCreaterByCardinfo();
                //加入卡组
                _deckQueue.Enqueue(cardFrame);
            }
          
        }
        
       

        //摸牌
        private void DrawCards(int num)
        {
            for (int i = 0; i < num; i++)
            {
                GameObject cardFrame = _deckQueue.Dequeue();
                cardFrame.transform.parent = handCardArea.transform;
                cardFrame.transform.position = deck_icon_position;//移动的起点为
                _handCardFrames.Add(cardFrame);
            }
            ResetHandCardPositon();
        }
        
        //洗牌
        private void ShuffleDeck(List<GameObject> cardFrameList)
        {
            ListUtil.Shuffle(cardFrameList);
        }
        
        private void ResetHandCardPositon()
        {
            float[] cardXPostionArray = GetHandCardTargetPosition(_handCardFrames.Count);
            //动画执行链
            LTSeq seq = LeanTween.sequence();
            LTSeq seq1 = LeanTween.sequence(false);
            for (int i = 0; i < _handCardFrames.Count; i++)
            {
                LTDescr ltDescr = LeanTween.moveLocal(_handCardFrames[i], new Vector3(cardXPostionArray[i], 0, 0), 5f)
                    .setEaseInOutQuart();
                seq.append(ltDescr);
                seq1.append(LeanTween.scale(_handCardFrames[i], Vector3.one, 5f));
            }
            /*LeanTween.moveLocal(_handCardFrames[0], new Vector3(cardXPostionArray[0], 0, 0), 5f)
                .setEaseInOutQuart();
            LeanTween.scale(_handCardFrames[0], Vector3.one, 5f);*/
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