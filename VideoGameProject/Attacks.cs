using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameProject
{
    class Attacks
    {
        private int AttackDamage;
        private int AttackChance;
        private string AttackName;
        static int AttackAmount = 0;
        public bool IsUnlocked;

        public Attacks(int ADMG, int ACHA)
        {
            AttackAmount++;
            AttackDamage = ADMG;
            AttackChance = ACHA;

        }

        public Attacks() { AttackAmount++; }


        public void SetAttackDamage(int newAttackDamage)
        {
            AttackDamage = newAttackDamage;
        }
        public int GetAttackDamage() { return AttackDamage; }

        public void SetAttackChance(int newAttackChance)
        {
            if (newAttackChance >= 0)
                AttackChance = newAttackChance;
        }
        public int GetAttackChance() { return AttackChance; }

        public static int GetAttackAmount() { return AttackAmount; }

        public void SetAttackName(string newAttackName)
        {
            AttackName = newAttackName;
        }
        public string GetAttackName() { return AttackName; }

        public void SetIsUnlocked(bool newIsUnlocked) { IsUnlocked = newIsUnlocked; }
        public bool GetIsUnlocked() { return IsUnlocked; }
    }
}
