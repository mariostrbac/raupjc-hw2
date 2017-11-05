using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad0607
{
    public class Class1
    {
        static  void  Main(string [] args)
        {
            var sum = FactorialDigitSum(4);
            

            // Main  method  is the  only  method  that
            // can ’t be  marked  with  async.
            // What we are  doing  here is just a way  for us to  simulate
            // async -friendly  environment  you  usually  have  with
            // other .NET  application  types (like  web apps , win  apps  etc.)
            //  Ignore  main  method , you  can  just  focus on LetsSayUserClickedAButtonOnGuiMethod () as a
            // first  method  in the  call  hierarchy.
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        public static async Task<int> FactorialDigitSum(int n)
        {
             return await Task.Run(() =>
                {
                    int x = 1;

                    for (int i = n; i > 0; i--)
                    {
                        x *= i;
                    }

                    int sum = 0;
                    for (int i = 0; i < x.ToString().Length; i++)
                    {
                        sum += int.Parse(x.ToString().ElementAt(i).ToString());
                    }

                    return sum;
                });
        }

        private  static  void  LetsSayUserClickedAButtonOnGuiMethod()
        {
            var  result = GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private  static async Task<int>  GetTheMagicNumber()
        {
            return  await IKnowIGuyWhoKnowsAGuy();
        }

        private  static  async Task<int>  IKnowIGuyWhoKnowsAGuy()
        {
            return  await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }

        private async static  Task<int>  IKnowWhoKnowsThis(int n)
        {
            return  FactorialDigitSum(n).Result;
        }
      }
}
