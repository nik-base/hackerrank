using System;
using System.Runtime.Remoting.Messaging;

namespace ScratchPad
{
    public class MyObject
    {
        public string Prop1 { get; set; }
    }

    public class Program
    {
        static int[] solve(int[] grades)
        {
            // Complete this function
            int[] result = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                result[i] = ((grades[i] < 38) || ((grades[i] % 5) < 3)) ? grades[i] : ((grades[i] / 5) + 1) * 5;
            }
            return result;
        }
        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {            
            int appleCount = 0;
            int orangeCount = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                var pointOfImpact = a + apples[i];
                if (pointOfImpact >= s && pointOfImpact <= t)
                {
                    appleCount++;
                }
            }
            Console.WriteLine(appleCount);
            for (int i = 0; i < oranges.Length; i++)
            {
                var pointOfImpact = b + oranges[i];
                if (pointOfImpact >= s && pointOfImpact <= t)
                {
                    orangeCount++;
                }
            }
            Console.WriteLine(orangeCount);
        }

        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            // Complete this function
            if (x1 < x2 && v1 < v2) return "NO";
            if (x1 > x2 && v1 > v2) return "NO";
            if (x1 == x2 && v1 != v2) return "NO";
            if (x1 != x2 && v1 == v2) return "NO";

            return (x1 - x2) % (v2 - v1) == 0 ? "YES" : "NO";
        }

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            // Complete this function
                
            var maxAttackRange = ((n - 1) * 2) + (getMin(Math.Abs(r_q - 1), Math.Abs(c_q - 1)) 
                               + getMin(Math.Abs(r_q - 1), Math.Abs(c_q - n))
                               + getMin(Math.Abs(r_q - n), Math.Abs(c_q - 1))
                               + getMin(Math.Abs(r_q - n), Math.Abs(c_q - n)));
            int blockingObstacles = 0;
            int rlb_max = 1;
            int clb_max = 1;
            int rlt_min = n;
            int clt_max = 1;
            int rrb_max = 1;
            int crb_min = n;
            int rrt_min = n;
            int crt_min = n;
            int cl_max = 1;
            int cr_min = n;
            int rt_min = n;
            int rb_max = 1;
            bool lbFlag = true;
            bool ltFlag = true;
            bool rbFlag = true;
            bool rtFlag = true;
            bool lFlag = true;
            bool rFlag = true;
            bool tFlag = true;
            bool bFlag = true;
            for (int i = 0; i < obstacles.Length; i++)
            {
                var ri = obstacles[i][0];
                var ci = obstacles[i][1];
                if(r_q == ri)
                {
                    if(ci < c_q)
                    {
                        if (ci > cl_max)
                        {
                            maxAttackRange -= ci - cl_max;
                            cl_max = ci;
                            if (lFlag)
                            {
                                lFlag = false;
                                blockingObstacles++;
                            }
                        }
                    }
                    else if (ci > c_q)
                    {
                        if (ci < cr_min)
                        {
                            maxAttackRange -= cr_min - ci;
                            cr_min = ci;
                            if (rFlag)
                            {
                                rFlag = false;
                                blockingObstacles++;
                            }
                        }
                    }
                }
                else if (c_q == ci)
                {
                    if (ri < r_q)
                    {
                        if (ri > rb_max)
                        {
                            maxAttackRange -= ri - rb_max;
                            rb_max = ri;
                            if (bFlag)
                            {
                                bFlag = false;
                                blockingObstacles++;
                            }
                        }
                    }
                    else if (ri > r_q)
                    {
                        if (ri < rt_min)
                        {
                            maxAttackRange -= rt_min - ri;
                            rt_min = ri;
                            if (tFlag)
                            {
                                tFlag = false;
                                blockingObstacles++;
                            }
                        }
                    }
                }
                else
                {
                    var dr = Math.Abs(r_q - ri);
                    var dcp = c_q + dr;
                    var dcn = c_q - dr;
                    var dc = -1;
                    if(dcp == ci)
                    {
                        dc = dcp;
                    }
                    else if (dcn == ci)
                    {
                        dc = dcn;
                    }
                    if(dc >= 0)
                    {
                        if(ri < r_q && ci < c_q)
                        {
                            if(ri > rlb_max && ci > clb_max)
                            {
                                maxAttackRange -= getMin(ri - rlb_max, ci - clb_max);
                                rlb_max = ri;
                                clb_max = ci;
                                if (lbFlag)
                                {
                                    lbFlag = false;
                                    blockingObstacles++;
                                }
                            }
                        }
                        else if (ri > r_q && ci < c_q)
                        {
                            if (ri < rlt_min && ci > clt_max)
                            {
                                maxAttackRange -= getMin(rlt_min - ri, ci - clt_max);
                                rlt_min = ri;
                                clt_max = ci;
                                if (ltFlag)
                                {
                                    ltFlag = false;
                                    blockingObstacles++;
                                }
                            }
                        }
                        else if (ri < r_q && ci > c_q)
                        {
                            if (ri > rrb_max && ci < crb_min)
                            {
                                maxAttackRange -= getMin(ri - rrb_max, crb_min - ci);
                                rrb_max = ri;
                                crb_min = ci;
                            }
                            if (rbFlag)
                            {
                                rbFlag = false;
                                blockingObstacles++;
                            }
                        }
                        else if (ri > r_q && ci > c_q)
                        {
                            if (ri < rrt_min && ci < crt_min)
                            {
                                maxAttackRange -= getMin(rrt_min - ri, crt_min - ci);
                                rrt_min = ri;
                                crt_min = ci;
                            }
                            if (rtFlag)
                            {
                                rtFlag = false;
                                blockingObstacles++;
                            }
                        }
                    }
                }
            }
            maxAttackRange -= blockingObstacles;
            return maxAttackRange;
        }

        static int getMin(int a, int b)
        {
            return a < b ? a : b;
        }


        public static void Main(string[] args)  
        {
            //MyObject myObj = null;
            //MyObject myObj1 = new MyObject()
            //{
            //    Prop1 = null
            //};
            //string val = myObj?.Prop1;
            //string val2 = myObj1?.Prop1;
            //string val1 = "val1";
            //string abc = myObj?.Prop1 ?? myObj1?.Prop1 ?? val1 ?? "abc";      


            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] grades = new int[n];
            //for (int grades_i = 0; grades_i < n; grades_i++)
            //{
            //    grades[grades_i] = Convert.ToInt32(Console.ReadLine());
            //}
            //int[] result = solve(grades);
            //Console.WriteLine(String.Join("\n", result));


            //string[] tokens_s = Console.ReadLine().Split(' ');
            //int s = Convert.ToInt32(tokens_s[0]);
            //int t = Convert.ToInt32(tokens_s[1]);
            //string[] tokens_a = Console.ReadLine().Split(' ');
            //int a = Convert.ToInt32(tokens_a[0]);
            //int b = Convert.ToInt32(tokens_a[1]);
            //string[] tokens_m = Console.ReadLine().Split(' ');
            //int m = Convert.ToInt32(tokens_m[0]);
            //int n = Convert.ToInt32(tokens_m[1]);
            //string[] apple_temp = Console.ReadLine().Split(' ');
            //int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
            //string[] orange_temp = Console.ReadLine().Split(' ');
            //int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);
            //countApplesAndOranges(s, t, a, b, apple, orange);


            //string[] tokens_x1 = Console.ReadLine().Split(' ');
            //int x1 = Convert.ToInt32(tokens_x1[0]);
            //int v1 = Convert.ToInt32(tokens_x1[1]);
            //int x2 = Convert.ToInt32(tokens_x1[2]);
            //int v2 = Convert.ToInt32(tokens_x1[3]);
            //string result = kangaroo(x1, v1, x2, v2);
            //Console.WriteLine(result);


            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] tokens_r_q = Console.ReadLine().Split(' ');
            int r_q = Convert.ToInt32(tokens_r_q[0]);
            int c_q = Convert.ToInt32(tokens_r_q[1]);
            int[][] obstacles = new int[k][];
            for (int obstacles_i = 0; obstacles_i < k; obstacles_i++)
            {
                string[] obstacles_temp = Console.ReadLine().Split(' ');
                obstacles[obstacles_i] = Array.ConvertAll(obstacles_temp, Int32.Parse);
            }
            int result = queensAttack(n, k, r_q, c_q, obstacles);
            Console.WriteLine(result);
        }
    }
}
