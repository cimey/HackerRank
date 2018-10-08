using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Climbing_The_Leaderboard
{
    public class Solution
    {
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            //create new scores array not including 
            //repeating ones 
            var idx = scores.GroupBy(x => x).Select(x => x.Key).ToList();
            //with binary search we could find their position
            var result = new List<int>();
            foreach (var aliceScore in alice)
            {
                var lowerBound = 0;
                var upperBound = idx.Count - 1;

                var isFound = false;
                var middle = 0;
                while (!isFound)
                {
                    if (upperBound < lowerBound)
                    {
                        //    if (middle == idx.Count && aliceScore < idx[middle - 1])
                        //        Console.WriteLine(middle + 1);
                        //    else if (middle == idx.Count && aliceScore == idx[middle - 1])
                        //        Console.WriteLine(middle);
                        //    else 
                        var t = 0;
                        if (aliceScore < idx[middle])
                            t = middle + 2;
                        else if (aliceScore >= idx[middle])
                            t = middle + 1;

                        result.Add(t);
                        break;
                    }
                    middle = (upperBound + lowerBound) / 2;
                    if (aliceScore == idx[middle])
                    {
                        result.Add(middle + 1);
                        break;

                    }
                    if (aliceScore > idx[middle])
                    {
                        //go to left side 
                        upperBound = middle - 1;


                    }
                    else
                    {
                        lowerBound = middle + 1;
                    }
                }
            }


            return result.ToArray();
        }

    }
}
