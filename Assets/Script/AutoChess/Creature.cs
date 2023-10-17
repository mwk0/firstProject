using System;
using UnityEngine;

namespace Script.AutoChess
{
    public class Creature : MonoBehaviour
    {
        
        public String _name;
        private int _level = 1;
        private float _speed = 100;
        private float _attackRange = 0;

        private float health = 100;
        private float mana = 0;

        private Rigidbody2D _rigidbody2D;
        
        public int currentBehave = AutoChessConstant.CreatureBehaveStand;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            //统一设置阻力
            _rigidbody2D.drag = 1000;
        }

        private void Update()
        {
            Debug.Log(currentBehave);
            GameObject firstEnemy = JudgeBehave(out currentBehave);
            if (firstEnemy == null)
            {
                //结束战斗
            }
            else
            {
                //敌人在身后要把图片翻转
                gameObject.GetComponent<SpriteRenderer>().flipX = transform.position.x > firstEnemy.transform.position.x;
                
                if (currentBehave == AutoChessConstant.CreatureBehaveMove)
                {
                    Move((firstEnemy.transform.position - transform.position).normalized);
                }else if (currentBehave == AutoChessConstant.CreatureBehaveAttack)
                {
                    Attack();
                }else if (currentBehave == AutoChessConstant.CreatureBehaveSkill)
                {
                    Skill();
                }else if (currentBehave == AutoChessConstant.CreatureBehaveStand)
                {
                    Stand();
                }
            }
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("发生碰撞");
            checkCollisionForBehave(other);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            Debug.Log("退出碰撞");
            GameObject otherObj = other.gameObject;
            if (otherObj.tag.Equals(AutoChessConstant.CreatureTagEnemy))
            {
                currentBehave = AutoChessConstant.CreatureBehaveMove;
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            Debug.Log("持续碰撞");
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

        private GameObject JudgeBehave(out int behave)
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
                //当前不是攻击状态才移动
                if (this.currentBehave != AutoChessConstant.CreatureBehaveAttack)
                {
                    behave = AutoChessConstant.CreatureBehaveMove;
                }
                else
                {
                    behave = AutoChessConstant.CreatureBehaveAttack;
                }
                    
            }
            //最近的敌人物体
            GameObject firstEnemy = enemyList[enemyIndex];
            return firstEnemy;
        }

        private void Move(Vector2 direction)
        {
            //播放动画
            //移动
            _rigidbody2D.velocity = direction * _speed;
        }

        private void Attack()
        {
            //播放动画
        }

        private void Skill()
        {
            
        }

        private void Stand()
        {
            
        }
        
    }
}