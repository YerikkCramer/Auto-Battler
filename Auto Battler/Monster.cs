using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler
{
    public class Monster
    {
        public string Name { get; set; }
        protected int evasion;
        private string secret;
    }

    public class Goblin:Monster
    {
        public void gobble()
        {
            //rawr
        }
    }
}
