using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class Weapon
    {
        protected int attack { get; private set; }
        protected int attackSpeed { get; private set; }
        
        /// <summary>
        /// 무기 공격력, 공격 속도 설정
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="attackSpeed"></param>
        protected void SetWeaponDamage(int attack, int attackSpeed) { this.attack = attack; this.attackSpeed = attackSpeed;}

        public virtual List<int> GetInfo()
        {
            List<int> info = new List<int>();
            info.Add(attack);
            info.Add(attackSpeed);

            return info;
        }
    }
}
