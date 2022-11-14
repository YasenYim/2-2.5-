using System;

namespace _2_2._5_面向对象属性和单例
{
  
    // 1. 使用属性语法，进一步优化对战程序

    // 2. 用单例模式编写常用工具类Utils  功能1：生成随机数  功能2：提供打印数组的方法

    // 3. 功能1：创建角色 功能2：打印输出所有的角色信息

    class Character
    {
        public string name;

        // 用属性可以简单实现只读
        public int attack { get; private set; }

        private int _def;  // 这里设置成私有是保存真正的防御力的
        public int def { 
            // Console.WriteLine(def)    //  get
            // int abc = def;            //  get
            get
            {
                Console.WriteLine("读取def" + _def);
                if (_def<0)
                { return 0; }   // _def可能是负值，但是外面人看到的永远不会是负值

                return _def;
            }
            // 属性 = ？？？   setz
            set
            {
                Console.WriteLine("修改def" + value);
                _def = value;   // 下面构造函数中this.def = def;传进来的就是value的值
            }
        }
        private int hp; 

        
        public Character()
        { name = "未知名字"; }

       
        public Character(string name, int hp, int attack, int def)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.def = def;
        }

        public Character(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
            this.attack = Utils.Instance.RandomNum(1,100);
            this.def = 0;
        }

        public void CostHp(int cost)
        {
            this.hp -= cost;
            if (this.hp <= 0)
            { this.hp = 0; }
        }
        public bool IsDead()
        {
            return hp <= 0;
        }

        public override string ToString()
        {
            return $"角色： {name} HP:{hp} 攻击力{attack}   防御力： {def}";  
        }
    }

    class Program
    {
        //static void CostHp(Character c ,int cost)
        //{
        //    c.hp -= cost;
        //    if (c.hp <= 0)
        //    { c.hp = 0; }
        //}
        static void Main(string[] args)
        {
            // 创建对象并初始化
            Character c1 = new Character("汤姆", 100, 15, 1);

            Character c2 = new Character("杰瑞", 10, 150, 10);

            Character c3 = new Character();

            Character c4 = new Character("赛维", 23);

            // 战斗过程
            while (!c1.IsDead() && !c2.IsDead())
            {
                int cost = c1.attack - c2.def;
                c2.CostHp(cost);


                Console.WriteLine($"{c1.name}攻击了{c2.name},{c2.name}损失了{cost}血量");
                Console.WriteLine($"{c2}");

                if (c2.IsDead())
                { break; }

                cost = c2.attack - c1.def;
                c1.CostHp(cost);

                Console.WriteLine($"{c2.name}攻击了{c1.name},{c1.name}损失了{cost}血量");
                Console.WriteLine($"{c1}");
            }

            // 判断胜负
            if (c1.IsDead())
            { Console.WriteLine($"------{c2.name}胜利！------"); }
            else
            { Console.WriteLine($"------{c1.name}胜利！------"); }
            Console.ReadKey();
        }
    }
}