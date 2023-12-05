using System.Collections.Generic;
using Script.Card;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Mask
{
    /// <summary>
    /// 遮罩穿透，遮罩层拦截所有的eventsystem（处理和管理 点击、键盘输入、触摸等事件）点击事件,然后根据状态码来执行点击事件
    /// 相当于aop切面
    /// </summary>
    public class PanerateMask:MonoBehaviour,IPointerClickHandler
    {
        public List<GameObject> Targets;
        private readonly List<RaycastResult> _rawRaycastResults = new List<RaycastResult>();
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("mask click!!");
            Raycast(eventData);
        }

        /// <summary>
        /// 穿透方法
        /// </summary>
        /// <param name="eventData"></param>
        private void Raycast(PointerEventData eventData)
        {
            _rawRaycastResults.Clear();
            EventSystem.current.RaycastAll(eventData, _rawRaycastResults);
            foreach (var rlt in _rawRaycastResults)
            {
                Debug.Log($"raycast result target:{rlt.gameObject}");
                //射线碰撞的第一个物体是遮罩本身，跳过它防止死循环
                if (rlt.gameObject.GetComponent<IgnoreEventRaycast>())
                {
                    Debug.Log($"ignore:{rlt.gameObject}");
                    continue;
                }

                stateController(rlt, eventData);


                //ExecuteEvents.ExecuteHierarchy(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
            }
        }

        /// <summary>
        /// 根据状态码和点击对象来判断执行的点击事件
        /// </summary>
        /// <param name="rlt"></param>
        /// <param name="eventData"></param>
        private void stateController(RaycastResult rlt, PointerEventData eventData)
        {
            //待机状态
            if (HandCardArea.GetInstance().stateCode is AppConstant.handCardState_wait)
            {
                Debug.Log("当前为待机状态");
                //手牌
                if (rlt.gameObject.GetComponent<CardCreater>())
                {
                    Debug.Log("点击了手牌:"+rlt.gameObject.name);
                    ExecuteEvents.Execute(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
                }
                else if (rlt.gameObject.GetComponent<MonsterCreater>())//敌人
                {
                    Debug.Log("点击了敌人:"+rlt.gameObject.name);
                    ExecuteEvents.Execute(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
                }
                   
                    
            }
            
        }
    }
}