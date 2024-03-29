using System;
using System.Collections.Generic;
using Script.Entity;
using Script.Pub.Singletonbase;
using Script.Util;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Card
{
    public class HandCardArea : SingletonMonoManager<HandCardArea>
    {
        //battle全局参数，单例
        public BattleConstParamSet BattleConstParamSet;

        //状态
        public int stateCode = AppConstant.handCardState_wait;
        public CardCreater cardToUse;


        private void Update()
        {
            /*if (Input.GetMouseButtonDown(0))
            {
                if (stateCode is AppConstant.handCardState_cardToUse)
                {
                   
                    
                }
            }*/

            if (Input.GetMouseButtonDown(1))//右键取消
            {
                if (stateCode is AppConstant.handCardState_cardToUse)
                {
                    cardToUse = null;
                    stateCode = AppConstant.handCardState_wait;
                    //手牌回原位
                    cardToUse.CardDown();
                    
                }
            }
        }


        //游戏开始生成卡组
        public void InitDeck(List<CardInfo> deckCardInfoList)
        {
            //乱序
            ListUtil.Shuffle(deckCardInfoList);
            foreach (var cardInfo in deckCardInfoList)
            {
                GameObject cardFrame = Instantiate(BattleConstParamSet._cardFramePrefab,
                    BattleConstParamSet.deckCardArea.transform);
                //缩小
                cardFrame.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                cardFrame.transform.position = BattleConstParamSet.deckOutPosition; //放到屏幕外
                //设置卡牌信息
                CardCreater cardCreater = cardFrame.GetComponent<CardCreater>();
                cardCreater.cardInfo = cardInfo;
                cardCreater.InitCardCreaterByCardinfo();
                //加入卡组
                BattleConstParamSet._deckQueue.Enqueue(cardFrame);
            }
        }

        public void DrawCards(int num)
        {
            for (int i = 0; i < num; i++)
            {
                GameObject cardFrame = BattleConstParamSet._deckQueue.Dequeue();
                cardFrame.transform.SetParent(BattleConstParamSet.handCardArea.transform);
                cardFrame.transform.position = BattleConstParamSet.deck_icon_position; //移动的起点为
                BattleConstParamSet._handCardFrames.Add(cardFrame);
            }

            ResetHandCardPositon();
        }

        //重新洗牌
        public void ShuffleDeck(List<GameObject> cardFrameList)
        {
            
        }

        public void ResetHandCardPositon()
        {
            float[] cardXPostionArray = GetHandCardTargetPosition(BattleConstParamSet._handCardFrames.Count);
            //动画执行链
            LTSeq seq = LeanTween.sequence();
            for (int i = 0; i < BattleConstParamSet._handCardFrames.Count; i++)
            {
                LTDescr ltDescr = LeanTween.moveLocal(BattleConstParamSet._handCardFrames[i],
                        new Vector3(cardXPostionArray[i], 0, 0), 0.3f)
                    .setEaseInOutQuart();
                seq.append(ltDescr);
                seq.append(LeanTween.scale(BattleConstParamSet._handCardFrames[i], Vector3.one, 0.2f));
            }
            /*LeanTween.moveLocal(_handCardFrames[0], new Vector3(cardXPostionArray[0], 0, 0), 5f)
                .setEaseInOutQuart();
            LeanTween.scale(_handCardFrames[0], Vector3.one, 5f);*/
        }

        //计算所有手牌的位置
        public float[] GetHandCardTargetPosition(int handCardNum)
        {
            float[] cardXPostionArray = new float[handCardNum];
            cardXPostionArray[0] = BattleConstParamSet.HandCardPadding; //第一张牌的位置在可用区域最左侧
            //可用区域宽度
            float areaWidth = BattleConstParamSet.HandAreaWidth - BattleConstParamSet.CardFrameWidth -
                              (BattleConstParamSet.HandCardPadding * 2);
            Debug.Log(areaWidth);
            if (BattleConstParamSet.CardFrameWidth * handCardNum < areaWidth) //手牌很少
            {
                for (int i = 1; i < handCardNum; i++)
                {
                    cardXPostionArray[i] = cardXPostionArray[0] + BattleConstParamSet.CardFrameWidth * i;
                }
            }
            else //手牌较多，覆盖排列
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

        /// <summary>
        /// 弃牌
        /// </summary>
        /// <param name="num">弃牌数量</param>
        /// <param name="isRandom">是否随机</param>
        public void Discards(int num,bool isRandom)
        {
            if (isRandom)//随机弃牌
            {
                
            }
            else
            {
                
            }
        }
    }
}