using System;
using System.Collections.Generic;
using System.Text;
/* Utils绑定了一个字段，这个字段是静态类的，此时的instance是空的
 * instance是绑定在类Utils上的，调取大写Instance的方法，通过大写的Instance去获取instance的变量
 *  instance = new Utils();到了这一步，Utils就变成了一个工具箱，变成了一个具体的对象了，random是存放在这里的，所以在第一次访问大写Instance的时候才会创建真正的工具箱，这个时候会把创建的工具箱赋值给小写的instance
 *  这个时候的小写instance就不为空，指向工具箱，通过绑定的Utils类可以访问到工具箱里面的randam以及RandomNum函数
 *  工具箱的部分是实例
 * 
*/
namespace _2_2._5_面向对象属性和单例
{
    
    class Utils
    {
        private static Utils instance = null;

        public static Utils Instance
        {
            get
            {
                if(instance == null)
                { instance = new Utils(); }
                return instance;
            }
            
        }

        private Random random = new Random();

        public int RandomNum(int a,int b)
        { return random.Next(a, b); }

    }
}
