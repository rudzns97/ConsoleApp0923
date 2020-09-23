using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    class MyClass
    {
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public void Plus(int val = 0)
        {
            number += val;
        }
        public void Minus(int val)
        {
            number -= val;
        }
        public void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }
        public static void PrintHello(int val)
        {
            for(int i = 0; i < val; i++)
            {
                Console.WriteLine("Hello");
            }
        }
    }

    delegate void Sample(int value);

    class Delegate1
    {
        
        static void Main()
        {
            MyClass c1 = new MyClass(); //number = 0

            //직접 인스턴스 메소드를 호출
            //c1.Plus(100); // number = 100
            //c1.Minus(10); // number = 90
            //c1.Add(10, 20); //30출력
            //Console.WriteLine(c1.Number); //90출력

            Sample s1 = new Sample(c1.Plus);
            s1 += new Sample(c1.Minus);
            s1(100); //plus(100), minus(100)
            s1 -= new Sample(c1.Minus);
            s1(100); //plus(100)
            Console.WriteLine(c1.Number);//100출력

            s1 = c1.Minus;
            s1 += c1.Plus;
            s1 += c1.Plus;
            s1(200); //minus(200), plus(200), plus(200)
            Console.WriteLine(c1.Number); //300

            s1 += MyClass.PrintHello; //static 메서드도 가능
            s1(5); //minus(5), plus(5), plus(5)
            Console.WriteLine(c1.Number); //305
        }

    }
}
