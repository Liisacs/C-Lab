using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    class abilities
    {
        private string name {  get; set; }  
        private int agility {  get; set; }
        private int strength {  get; set; }
        private int intelligence {  get; set; }

        public string Name
        {
            get { return name; }
        }
        public abilities(int a, int b, int c, string name)
        {
            this.name = name;
            this.agility = a;
            this.strength = b;
            this.intelligence = c;
        }
        public abilities(abilities t)
        {
            if(t == null) throw new ArgumentNullException("Произошёл анлак");
            this.name = t.name;
            this.agility = t.agility;
            this.strength = t.strength;
            this.intelligence = t.intelligence;
        }

        public override string ToString()
        {
            return ($"имя:{name}  Ловкость = {agility}, Сила = {strength}, Интелект = {intelligence}");
        }

        public int multiplication() { return agility * strength * intelligence; }
    }

    class skills : abilities
    {
        private bool melee { get; set; }
        private bool archery { get; set; }
        private bool spellin { get; set; }

        public skills(int agility, int strenght, int intelligence, string name) : base(agility, strenght, intelligence, name)
        {
            this.melee = strenght > 60;
            this.archery = agility > 60;
            this.spellin = intelligence > 60;
        }

        public skills(skills t) : base(t)
        {
            this.melee = t.melee;
            this.archery = t.archery;
            this.spellin=t.spellin;
        }

        public void combat(skills a, skills b)
        {
            int a1 =  new[] { melee, archery, spellin}.Count(x => x);
            int b1 = new[] { melee, spellin, archery, archery, spellin}.Count(y => y);
            Console.WriteLine(a1 == b1 ? "Ничья" : a1 > b1 ? $"победил {a.Name}" : $"победил {b.Name}");
        }
    }
}
