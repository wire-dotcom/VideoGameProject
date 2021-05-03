using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VideoGameProject
{
    class Enemy
    {
        private int EnemyHP;
        private int EnemyAttack;
        private string EnemyName;
        static int EnemyAmount = 0;

        public Enemy(int EHP, int EATK)
        {
            EnemyAmount++;
            EnemyHP = EHP;
            EnemyAttack = EATK;

        }

        public Enemy() { EnemyAmount++; }


        public void SetEnemyHP(int newEnemyHP)
        {
            EnemyHP = newEnemyHP;
        }
        public int GetEnemyHP() { return EnemyHP; }

        public void SetEnemyAttack(int newEnemyAttack)
        {
            if (newEnemyAttack >= 0)
                EnemyAttack = newEnemyAttack;
        }
        public void SetEnemyName(string newEnemyName)
        {
            EnemyName = newEnemyName;
        }
        public string GetEnemyName() { return EnemyName; }
        public int GetEnemyAttack() { return EnemyAttack; }

        public static int GetEnemyAmount() { return EnemyAmount; }

    }
}
