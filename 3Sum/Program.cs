using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            foreach(var num in ThreeSum(nums))
            {
                Console.WriteLine(string.Join(",", num));
            }
        }

        static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int l = i + 1, h = nums.Length - 1;
                while (l < h)
                {
                    int sum = nums[i] + nums[l] + nums[h];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[l], nums[h] });
                        while (l < h && nums[i] == nums[l + 1]) l++; // ex = -4, -1, -1, -1, 2, 2
                        while (l < h && nums[h] == nums[h -1]) h--; // ex = -4, -1, -1, -1, 2, 2
                        l++; h--;
                    }
                    else if (sum < 0) l++;
                    else h--;
                }
            }
            return result;
        }
    }
}
