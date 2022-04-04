using System;
using System.Collections.Generic;

namespace DelegateLesson
{
    internal class Program
    {
        public delegate bool CheckNum(int num);
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9,14 };

            //var result = FindAll(nums, delegate(int num) { return num % 2 == 0; });
            var result = FindAll(nums, x=>x%3==0);


            Console.WriteLine("Result");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Result end");

            //Console.WriteLine(SumEven(nums));
            //Console.WriteLine(SumOdd(nums));
            //Console.WriteLine(SumDividedBy7(nums));

            CheckNum check = IsEven;
            check = IsOdd;

            check = delegate (int num) { return num % 7 == 0; };

            check = (int x) => x % 3 == 0;


            Console.WriteLine(Sum(nums,IsEven));
            Console.WriteLine(Sum(nums, IsOdd));
            Console.WriteLine(Sum(nums,x=>x%5==0));
            Console.WriteLine(Sum(nums, delegate(int x) { return x % 11 == 0; }));


            //anonymous
            Func<int, bool> func = delegate(int x) { return x % 2 == 0; };

            //arrow func
            func = x => x % 3 == 0;

            Action<List<int>> action = delegate (List<int> nums)
            {
                foreach (var item in nums)
                {
                    if (item % 2 == 0)
                        Console.WriteLine(item);
                }
            };
            action = null;

            Console.WriteLine("Action works");
            action?.Invoke(nums);

            Predicate<int> predicate = IsEven;

            List<Human> humans = new List<Human>
            {
                new Human("Name1",34),
                new Human("Name2",17),
                new Human("Name3",89),
                new Human("Name4",8),
                new Human("Name5",9),
                new Human("Name6",19),
                new Human("Name7",39),
            };


            var humanResult = FindAll(humans, x=>x.Age>=18);
            humanResult = humans.FindAll(x => x.Age >= 18);

            Console.WriteLine("Humans");
            foreach (var item in humanResult)
            {
                Console.WriteLine(item.FullName + " "+item.Age);
            }

            var wantedHuman = humans.Find(x => x.Age >= 80);
            wantedHuman = humans.Find(x => x.FullName == "Name4");
            Console.WriteLine(humans.Exists(x=>x.Age>90));

        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }


        static bool IsOdd(int num)
        {
            return num % 2 == 1;
        }

        static void ShowEven(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (IsEven(nums[i]))
                    Console.WriteLine(nums[i]);
            }
        }

        static int Sum(List<int> nums, CheckNum check)
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (check(nums[i]))
                    sum += nums[i];
            }

            return sum;
        }


        static int SumEven(List<int> nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                    sum += nums[i];
            }

            return sum;
        }

        static int SumOdd(List<int> nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 1)
                    sum += nums[i];
            }

            return sum;
        }

        static int SumDividedBy7(List<int> nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 7 == 0)
                    sum += nums[i];
            }

            return sum;
        }

        static List<int> FindAll(List<int> nums, Predicate<int> predicate)
        {
            List<int> result = new List<int>();
            foreach (var item in nums)
            {
                if (predicate(item))
                    result.Add(item);
            }

            return result;
        }

        static List<Human> FindAll(List<Human> humans,Predicate<Human> predicate)
        {
            List<Human> result = new List<Human>();
            foreach (var item in humans)
            {
                if (predicate(item))
                    result.Add(item);
            }

            return result;
        }

        static bool IsUnder18(Human human)
        {
            return human.Age < 18;
        }
    }
}
