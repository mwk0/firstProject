using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Card
{
    public class HandCardArea : MonoBehaviour
    {
        //cardFrame预制体的宽带
        public static float CardFrameWidth;
        //手牌区域的宽度
        public static float HandAreaWidth;
        //手牌区域左右空格
        public static float HandCardPadding = 20;
        
        
        
        private void Start()
        {
            CardFrameWidth = Resources.Load("prefabs/cardFrame").GetComponent<RectTransform>().rect.width;
            HandAreaWidth = gameObject.GetComponent<RectTransform>().rect.width;
        }

        private void Update()
        {
            //根据手牌数量调整手牌位置
        }
        
        //计算所有手牌的位置
        private float[] GetHandCardTargetPosition(int handCardNum)
        {
            float[] cardXPostionArray = new float[handCardNum];
            cardXPostionArray[0] = HandCardPadding;//第一张牌的位置在可用区域最左侧
            //可用区域宽度
            float areaWidth = HandAreaWidth - CardFrameWidth - (HandCardPadding * 2);
            //Debug.Log(areaWidth);
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
                //Debug.Log(space);
                for (int i = 1; i < handCardNum; i++)
                {
                    cardXPostionArray[i] = cardXPostionArray[0] + space * i;
                    //Debug.Log(cardXPostionArray[i]);
                }
            }

            return cardXPostionArray;
        }
    }
}