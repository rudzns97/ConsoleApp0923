using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    delegate void FindDelegate(int prime);

    class MyPrime
    {
        public event FindDelegate FindPrime;
        public void CheckPrime(int maxNum)
        {
            for(int i = 2; i <= maxNum; i++)
            {
                bool bPrime = true;
                for(int p = 2; p < maxNum; p++)
                {
                    if (i % p == 0)
                    {
                        bPrime = false;
                        break;
                    }
                        
                }
                if (bPrime)
                {
                    Console.WriteLine(i);
                }
                //break가 되어서 내려온경우, 2번을 다 돌고 내려온건지
            }
        }
    }
    class MyPrimeTest
    {
        static void Main()
        {
            Console.Write("소수를 구하고 싶은 범위의 최대값을 입력: ");
            int maxNum = int.Parse(Console.ReadLine());

            MyPrime pi = new MyPrime();

            //이벤트핸들러 등록 (이벤트명 += 메서드명)
            //pi.FindPrime += new FindDelegate(PrintPrime); //C#1.0
            pi.FindPrime += PrintPrime; //C#2.0

            pi.CheckPrime(maxNum);
        }
        //델리게이트와 똑같은 타입으로 정의되어 있어야 함
        private static void PrintPrime(int prime)
        {
            Console.WriteLine("이벤트 발생:  " + prime);
        }
    }
}
