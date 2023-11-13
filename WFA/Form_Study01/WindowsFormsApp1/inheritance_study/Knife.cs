
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class Knife : Weapon
    {
        int sharpness;

        public Knife(int sharpness)
        {
            this.sharpness = sharpness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>전투력 반환</returns>
        public int CombatPoint(int attack, int attackSpeed) 
        { 
            SetWeaponDamage(attack, attackSpeed);
            return this.attack * this.attackSpeed * sharpness; 
        }

        public override List<int> GetInfo()
        {
            List<int> info = new List<int>();
            info.Add(attack);
            info.Add(attackSpeed);
            info.Add(sharpness);

            return info;
        }

        public void SetCombatPoint(int attack)
        {
            SetWeaponDamage(attack, attackSpeed);
        }

        public void SetCombatPoint(int attack, int attackSpeed)
        {
            SetWeaponDamage(attack, attackSpeed);
        }

        public void SetCombatPoint(int attack, int attackSpeed, int sharpness)
        {
            SetWeaponDamage(attack, attackSpeed);
            this.sharpness = sharpness;
        }
    }
}
