using HackerRank.Common_Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            int result = Solution.commonChild(s1, s2);

            Console.WriteLine(result);
        }
    }
}
