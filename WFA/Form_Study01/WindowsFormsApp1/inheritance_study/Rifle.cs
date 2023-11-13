
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class Rifle : Weapon
    {
        int bullets;

        public Rifle(int bullets)
        {
            this.bullets = bullets;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>전투력 반환</returns>
        public int CombatPoint(int attack, int attackSpeed)
        {
            SetWeaponDamage(attack, attackSpeed);
            return this.attack * this.attackSpeed * bullets;
        }

        public override List<int> GetInfo()
        {
            List<int> info = new List<int>();
            info.Add(attack);
            info.Add(attackSpeed);
            info.Add(bullets);

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

        public void SetCombatPoint(int attack, int attackSpeed, int bullets)
        {
            SetWeaponDamage(attack, attackSpeed);
            this.bullets = bullets;
        }
    }
}
