using System;
using UnityEngine;

namespace Script.AutoChess
{
    public class BattleGroundInit:MonoBehaviour
    {
        private void Start()
        {
            SetObjectInBattleGroundFaceToCamera();
        }

        //战场所有物体面向主摄像机，制造2.5d视角
        private void SetObjectInBattleGroundFaceToCamera()
        {
            Transform[] children = new Transform[transform.childCount];
            for (int i = 0; i < children.Length; i++)
            {
                transform.GetChild(i).rotation = Camera.main.transform.rotation;

            }
        }
    }
}