using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GuessGame
{
    class GuessGame:Game
    {
        private List<GuessGame>users=new List<GuessGame>();
        private int rndNumber;
        private int chances;
        private int score;
        private int dificulty;
        private int numberoftrueguess = 0;
        private int numberofgame = 0;
        private int bestscore = 0;
        public GuessGame(int dificulty,string name,char sex,int age):base(name,sex,age)
        { 
            GenerateRandomNumber(dificulty);
            this.dificulty = dificulty;
            chances = 4;
            score = 0;
        }
        public GuessGame(int dificulty,int numberoftrueguess,int score,string name,char sex,int age,int numberofgame,int bestscore):base(name,sex,age)
        {
            this.dificulty = dificulty;
            this.numberoftrueguess = numberoftrueguess;
            this.score = score;
            this.numberofgame = numberofgame;
            this.bestscore = bestscore;
        }
        public void SaveFile()
        {
            StreamWriter sw = new StreamWriter("C:\\New folder\\GuessGame.txt");
            for (int i = 0; i < users.Count; i++)
            {
                sw.WriteLine(users[i].dificulty + "," + users[i].numberoftrueguess + "," + users[i].score + "," + users[i].name + "," + users[i].sex + "," + users[i].age + "," + users[i].numberofgame + "," + users[i].bestscore);
            }
            sw.WriteLine(dificulty + "," + numberoftrueguess + "," + score + "," + name + "," + sex + "," + age + "," + numberofgame + "," + bestscore);
            sw.Flush();
            sw.Close();
        }
        public void LoadFile()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\New folder\\GuessGame.txt");
                while (sr.Peek() != -1)
                {
                    string st = sr.ReadLine();
                    string[] param = st.Split(',');
                    int dificulty = int.Parse(param[0]);
                    int numberoftrueguess = int.Parse(param[1]);
                    int score = int.Parse(param[2]);
                    string name = param[3];
                    char sex = Convert.ToChar(param[4]);
                    int age = Convert.ToInt32(param[5]);
                    int numberofgame = Convert.ToInt32(param[6]);
                    int bestscore=int.Parse(param[7]);
                    GuessGame gs = new GuessGame(dificulty, numberoftrueguess, score, name, sex, age,numberofgame,bestscore);
                    users.Add(gs);
                }
                sr.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in loading file!");
            }
        }
        public void PlayAgain()
        {
            GenerateRandomNumber(dificulty);
            score = 0;
            chances = 4;
        }
        public void GenerateRandomNumber(int dificulty)
        {
            Random rn = new Random();
            if (dificulty==0)
            {
                rndNumber = rn.Next(100);
            }
            else
            {
                rndNumber = rn.Next(1000);
            }
        }
        public int CheckUserInput(int number)
        {
            if(number==rndNumber)
            {
                GoToNextNumber();
                numberoftrueguess++;
                return 1;
            }
            chances--;
            if(chances>0)
            {
                if(rndNumber>number)
                {
                    Console.WriteLine("Enter a bigger number");
                }
                else
                {
                    Console.WriteLine("Enter a smaller number");
                }
                ContinueGuessing();
                return 0;
            }
            return -1;
        }
        public void GoToNextNumber()
        {
            Console.WriteLine("Correct!");
            if(dificulty==0)
            { score += chances * 10; }
            else
            { score += chances * 50; }
            Console.WriteLine("Current score:" + score);
            Console.WriteLine("Next Number");
            if (dificulty == 0)
            { GenerateRandomNumber(0); }
            else
            { GenerateRandomNumber(1); }
            chances = 4;
        }
        public void ContinueGuessing()
        {
            Console.WriteLine("Remaind chances:" + chances);
            Console.WriteLine("Guess Again:");
        }
        public void PrintResult()
        {
            Console.WriteLine("You Lost!");
            Console.WriteLine("Number was:" + rndNumber);
            Console.WriteLine("Your score:" + score);
            Console.WriteLine("Number of true guess:" + numberoftrueguess);
            numberofgame++;
            if(score>bestscore)
            {
                bestscore = score;
            }
        }
        public override void Help()
        {
            if (score>=5)
            {
                Console.WriteLine("Number is between " + (rndNumber - 5) + " to " + (rndNumber + 5));
                score = score - 5;
                return;
            }
            Console.WriteLine("You dont have enough score for help");
        }
        public override void PrintUsers()
        {
            for(int i=0;i<users.Count;i++)
            {
                Console.WriteLine("dificulty:"+users[i].dificulty+" Number of true guess:"+users[i].numberoftrueguess+" score:"+users[i].score+" name:"+users[i].name+" sex:"+users[i].sex+" age:"+users[i].age+" Number of game:"+users[i].numberofgame+" Best score:"+users[i].bestscore);
            }
        }
        public override void SearchByName(string name)
        {
            for(int i=0;i<users.Count;i++)
            {
                if(users[i].name==name)
                {
                    Console.WriteLine("dificulty:" + users[i].dificulty + " Number of true guess:" + users[i].numberoftrueguess + " score:" + users[i].score + " name:" + users[i].name + " sex:" + users[i].sex + " age:" + users[i].age+" Number of game:"+users[i].numberofgame+" Best score:"+users[i].bestscore);
                }
            }
        }
        public override void PrintBests()
        {
            GuessGame[] bests = new GuessGame[5];
            for(int i=0;i<bests.Length;i++)
            {
                bests[i] = new GuessGame(0,0,0,"a",'m',0,0,0);
            }
            bests[0] = users[0];
            for(int i=0;i<users.Count;i++)
            {
                if(users[i].score>bests[0].score)
                {
                    bests[0] = users[i];
                }
            }
            for(int i=1;i<bests.Length;i++)
            {
                for(int j=0;j<users.Count;j++)
                {
                    if(bests[i].score<users[j].score && bests[i-1].score>users[j].score)
                    {
                        bests[i] = users[j];
                    }
                }
            }
            for(int i=0;i<5;i++)
            {
                Console.WriteLine("dificalty:"+bests[i].dificulty+" Number of True Guess:"+bests[i].numberoftrueguess+" score:"+bests[i].score+" name:"+bests[i].name+" sex:"+bests[i].sex+" age:"+bests[i].age+" Number of game:"+bests[i].numberofgame+" Best score:"+bests[i].bestscore);
            }
        }
        public override void SearchByAge()
        {
            Console.WriteLine("input a minimum for age:");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("input a maximum for age:");
            int max = int.Parse(Console.ReadLine());
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].age >= min && users[i].age <= max)
                {
                    Console.WriteLine("dificulty:" + users[i].dificulty + " Number of true guess:" + users[i].numberoftrueguess + " score:" + users[i].score + " name:" + users[i].name + " sex:" + users[i].sex + " age:" + users[i].age + " Number of game:" + users[i].numberofgame+" Best score:"+users[i].bestscore);
                }
            }
        }
        public void BestRecord(string name)
        {
            for(int i=0; i<users.Count; i++)
            {
                if(users[i].name == name)
                {
                    Console.WriteLine("Best record for:" + users[i].name + "is:" + users[i].bestscore);
                }
            }
        }
    }
}
