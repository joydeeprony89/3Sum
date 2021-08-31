using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3Sum
{
    class Program
    {
        public EPreAutoValidationStatus? PreAutoValidationStatus { get; set; }
        public enum EPreAutoValidationStatus
        {
            Success = 1,
            Failure = 2
        }

        static List<int> Wait()
        {
            Thread.Sleep(2000);
            Console.WriteLine("2 sec wait");
            return new List<int>() { 1, 2, 3 };
        }

        static void Main(string[] args)
        {
            //var swWhenAll = new Stopwatch();
            //swWhenAll.Start();
            //for (int i = 1; i <= 3; i++)
            //{
            //    var response = Wait();
            //    Console.WriteLine(string.Join(",", response));
            //}
            //swWhenAll.Stop();
            //Console.WriteLine($"WO Task.WhenAll() took { swWhenAll.ElapsedMilliseconds }");
            //swWhenAll.Reset();

            //List<int> responses = new List<int>();
            //Task[] tasks = new Task[3];
            //swWhenAll.Start();
            //for (int i = 0; i < 3; i++)
            //{
            //    var res = Task.Run(() => { responses.AddRange(Wait()); });
            //    tasks[i] = res;
            //}

            //Task.WhenAll(tasks).GetAwaiter().GetResult();
            //Console.WriteLine(string.Join(",", responses));
            //swWhenAll.Stop();
            //Console.WriteLine($"Task.WhenAll() took { swWhenAll.ElapsedMilliseconds }");
            #region commented
            //var t = Guid.Empty;
            //Program p = new Program();
            //var result = default(EPreAutoValidationStatus);
            //if (Enum.TryParse<EPreAutoValidationStatus>("5", true, out result))
            //{
            //    p.PreAutoValidationStatus = result;
            //}


            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            foreach (var num in ThreeSum(nums))
            {
                Console.WriteLine(string.Join(",", num));
            }

            // sum of three nos equal to 200.
            int[] itemPrices = { 100, 75, 150, 200, 50, 65, 40, 30, 15, 25, 60 };
            var result = ThreeSumWithHash(itemPrices);
            foreach (var res in result)
                Console.WriteLine(string.Join(",", res));
            #endregion
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

        static IList<IList<int>> ThreeSumWithHash(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] > 200) continue;
                if (i == 0 || nums[i] != nums[i - 1])
                    GetTwoMoreNumbers(nums, i, result);
            }
            return result;
        }

        static void GetTwoMoreNumbers(int[] nums, int i, IList<IList<int>> result)
        {
            HashSet<int> seen = new HashSet<int>();
            int j = i + 1;
            while (j < nums.Length)
            {
                int anotherno = 200 - nums[i] - nums[j];
                if (seen.Contains(anotherno))
                {
                    result.Add(new List<int>() { nums[i], nums[j], anotherno });
                    while(j+1 < nums.Length && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                }
                seen.Add(nums[j]);
                j++;
            }
        }
    }
}
