using System;

namespace ScratchPad
{
    public class MyObject
    {
        public string Prop1 { get; set; }
    }

    public class Program
    {
        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
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
