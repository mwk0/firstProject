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

        public float health;
        public float mana;

        private Rigidbody2D _rigidbody2D;
        
        public int currentBehave = AutoChessConstant.CreatureBehaveStand;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (currentBehave != AutoChessConstant.CreatureBehaveAttack)
            {
                GameObject firstEnemy = GetFirstEnemy(out currentBehave);
                if (firstEnemy == null)//没有敌人了
                {
                    //结束战斗
                    currentBehave = AutoChessConstant.CreatureBehaveStand;
                }
                else
                {
                    if (currentBehave == AutoChessConstant.CreatureBehaveMove)
                    {
                        //转向
                        transform.LookAt(firstEnemy.transform);
                        //敌人在身后要把图片翻转
                        gameObject.GetComponent<SpriteRenderer>().flipX = transform.position.x > firstEnemy.transform.position.x;
                        //移动
                        Vector2 direction = ((firstEnemy.transform.position - transform.position).normalized);
                        _rigidbody2D.velocity = direction * _speed;
                        //transform.Translate((firstEnemy.transform.position - transform.position) * (Time.deltaTime * _speed));
                    }
                }
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            checkCollisionForBehave(other);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            GameObject otherObj = other.gameObject;
            if (otherObj.tag.Equals(AutoChessConstant.CreatureTagEnemy))
            {
                currentBehave = AutoChessConstant.CreatureBehaveMove;
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            checkCollisionForBehave(other);
        }
        
        private void checkCollisionForBehave(Collision2D other)
        {
            GameObject otherObj = other.gameObject;
            if (otherObj.tag.Equals(AutoChessConstant.CreatureTagEnemy))
            {
                currentBehave = AutoChessConstant.CreatureBehaveAttack;
            }
            else
            {
                currentBehave = AutoChessConstant.CreatureBehaveMove;
            }
        }

        private GameObject GetFirstEnemy(out int behave)
        {
            //获取所有敌人标签的物体
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag(AutoChessConstant.CreatureTagEnemy);
            if (enemyList.Length == 0)
            {
                behave = AutoChessConstant.CreatureBehaveStand;
                return null;
            }
            float shortestDistance = float.MaxValue;
            int enemyIndex = 0;
            for (int i = 0; i < enemyList.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, enemyList[i].transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    enemyIndex = i;
                }
            }
            //判断是否在_attackRange内
            if (_attackRange >= shortestDistance)
            {
                behave = AutoChessConstant.CreatureBehaveAttack;
            }
            else
            {
                behave = AutoChessConstant.CreatureBehaveMove;
            }
            //最近的敌人物体
            GameObject firstEnemy = enemyList[enemyIndex];
            return firstEnemy;
        }
        
    }
}