using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameProject
{
    class Player
    {
        private int Health;
        private int Mana;
        private int Damage;
        private int Level;
        private int Experience;


        public void SetHealth(int newHealth){Health = newHealth;}
        public int GetHealth() { return Health; }

        public void SetMana(int newMana){ Mana = newMana; }
        public int GetMana() { return Mana; }
        public void SetDamage(int newDamage){ Damage = newDamage; }
        public int GetDamage() { return Damage; }
        public void SetLevel(int newLevel) { Level = newLevel; }
        public int GetLevel() { return Level; }
        public void SetExperience(int newExperience) { Experience = newExperience; }
        public int GetExperience() { return Experience; }

    }


}
