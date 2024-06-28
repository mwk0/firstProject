using System;
using Script.Card;
using UnityEngine;

namespace Script.Prefabs
{
    public class BattleCell:MonoBehaviour
    {
        private bool isEnemy;
        private int battleCellType;

        public bool IsEnemy
        {
            get => isEnemy;
            set => isEnemy = value;
        }

        public int BattleCellType
        {
            get => battleCellType;
            set => battleCellType = value;
        }
        
        private void Start()
        {
           
        }
        
    }
}