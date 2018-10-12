using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Common_Child
{
    public class Solution
    {

        public static int commonChild(string s1, string s2)
        {
            //we have to iterate on two strings 
            //start from beginning character and check second string has this character
            //if yes we keep the track of the index of character in second string


            var dict = new Dictionary<char, List<int>>();

            //creates second strings character dictionary
            //this dictionary keep indexes of each character in s2
            //for example dictionary of string AANADDE will be
            //[A, {0,1,3}] [N, {2}] [D,{4,5}] etc
            //if we check the any index of ny character we will easily find

            for (int i = 0; i < s2.Length; i++)
            {
                if (!dict.ContainsKey(s2[i]))
                    dict.Add(s2[i], new List<int>());
                dict[s2[i]].Add(i);
            }
            var max = -1;
            for (int i = 0; i < s1.Length; i++)
            {
                var result = RecursiveCommonChild(s1, i, dict);
                max = result > max ? result : max;
            }

            return max;
        }


        static int RecursiveCommonChild(string s1, int startPosition, Dictionary<char, List<int>> dict)
        {
            var list = new List<int>();
            //SHINCHAN
            //NOHARAAA

            //ABEDDEFE
            //ABDCDFCE

            //ABCDDD
            //ABDCDE
            var result = 0;
            var lastIdx = -1;
            var prevlastidx = -1;
            for (int i = startPosition; i < s1.Length; i++)
            {
                //if s1[i] in dict 
                if (dict.ContainsKey(s1[i]))
                {
                    if (dict[s1[i]].Count(x => x > lastIdx) > 0)
                    {
                        prevlastidx = lastIdx;
                        lastIdx = dict[s1[i]].First(x => x >= lastIdx);
                        result++;
                    }

                    else if (dict[s1[i]].Count(x => x > prevlastidx) > 0)
                    {
                        lastIdx = prevlastidx;
                    }
                }
            }

            return result;
        }
    }
}
