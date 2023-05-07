using System;
using UnityEngine;

namespace Script.AutoChess
{
    public class Creature : MonoBehaviour
    {
        
        public String _name;
        public int _level;
        public float _speed;
        public float _attackRange;

        private void Start()
        {
           
        }

        private void Update()
        {
           
        }

        private void MoveToFirstEnemy(String enemyTagName)
        {
            //获取所有敌人标签的物体
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag(enemyTagName);
            float shortestDistance = float.MaxValue;
            int enemyIndex = 0;
            for (int i = 0; i < enemyList.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, enemyList[i].transform.position);
                if (distance < shortestDistance)
                {
                    enemyIndex = i;
                }
            }
            //最近的敌人物体
            GameObject firstEnemy = enemyList[enemyIndex];
            //转向
            transform.LookAt(firstEnemy.transform);
            //移动
            transform.Translate(firstEnemy.transform.position*Time.deltaTime*_speed);

        }
    }
}