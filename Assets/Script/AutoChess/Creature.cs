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
            //_rigidbody2D.drag = 100;
        }

        private void Update()
        {
            
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                GameObject.Find("bit").SetActive(false);
            }
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject otherObj = other.collider.gameObject;
            if (otherObj.tag.Equals(AutoChessConstant.CreatureTagEnemy))
            {
                currentBehave = AutoChessConstant.CreatureBehaveAttack;
                _rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
            //碰撞后，防止撞飞
            
            //other.otherCollider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            currentBehave = AutoChessConstant.CreatureBehaveMove;
            //退出碰撞，设置身体类型
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            //other.otherCollider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            GameObject otherObj = other.collider.gameObject;
            Debug.Log(otherObj.tag);
            if (otherObj.tag.Equals(AutoChessConstant.CreatureTagEnemy))
            {
                currentBehave = AutoChessConstant.CreatureBehaveAttack;
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
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
            Debug.Log(currentBehave);
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