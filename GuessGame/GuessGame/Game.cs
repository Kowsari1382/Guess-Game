using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    abstract class Game
    {
        protected string name;
        protected char sex;
        protected int age;
        public Game(string name, char sex, int age)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
        }
        public abstract void PrintUsers();
        public abstract void SearchByName(string name);
        public abstract void PrintBests();
        public abstract void SearchByAge();
        public virtual void Help() { }
    }
}
