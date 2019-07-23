using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwpj
{
   public class jk还本付息表
    {
        public double jsqjk建设期借款=2060;
        public List<jk借款还本付息> jklist = new List<jk借款还本付息>();
        jk借款还本付息 jkFirst = new jk借款还本付息();
        
        public void exec等额还本利息照付()
        {
            compute计算所需参数类 com = new cwpj.compute计算所需参数类();
            com.hkzq还款周期 = 4;
            com.rate = 0.06;
            com.jsqjk建设期借款 = 2060;
            policy还款策略 pl = new Policy等额还本利息照付(com);
            pl.exec();


            int hkzq还款周期 = 4;
            double rate = 0.06;
            jkFirst.qmjkye期末借款余额 = jsqjk建设期借款;
            jkFirst.sxh顺序号 = 1;
            jklist.Add(jkFirst);

            for (int i = 1; i <= hkzq还款周期; i++)
            {
                jk借款还本付息 jk = new jk借款还本付息();
                //取集合中顺序号最大的，然后取它的期末借款金额，然后把它作为年初的金额
                jk.qcjkye期初借款余额 = jklist.OrderByDescending(x => x.sxh顺序号).First().qmjkye期末借款余额;
                jk.sxh顺序号 = jklist.OrderByDescending(x => x.sxh顺序号).First().sxh顺序号 + 1;
                jk.dqhb当期还本 = jsqjk建设期借款 / hkzq还款周期;
                jk.dqfx当期付息 = jk.qcjkye期初借款余额 * rate;
                jk.qmjkye期末借款余额 = jk.qcjkye期初借款余额 - jk.dqhb当期还本;
                jklist.Add(jk);
            }
        }

        public void exec等额还本付息()
        {
             jsqjk建设期借款 = 2205;
            int hkzq还款周期 = 4;
            double rate = 0.1;
            jkFirst.qmjkye期末借款余额 = jsqjk建设期借款;
            jkFirst.sxh顺序号 = 1;
            jklist.Add(jkFirst);
            double dehbfxzr等额还本付息总额 = 0;
            dehbfxzr等额还本付息总额 = cal等额还本付息总额(jsqjk建设期借款, rate, hkzq还款周期);

            for (int i = 1; i <= hkzq还款周期; i++)
            {
                jk借款还本付息 jk = new jk借款还本付息();
                //取集合中顺序号最大的，然后取它的期末借款金额，然后把它作为年初的金额
                jk.qcjkye期初借款余额 = jklist.OrderByDescending(x => x.sxh顺序号).First().qmjkye期末借款余额;
                jk.sxh顺序号 = jklist.OrderByDescending(x => x.sxh顺序号).First().sxh顺序号 + 1;


                jk.dqfx当期付息 = jk.qcjkye期初借款余额 * rate;
                //jk.dqhb当期还本 = jsqjk建设期借款 / hkzq还款周期;

                
                if (hkzq还款周期 != i)
                {
                    jk.dqhb当期还本 = dehbfxzr等额还本付息总额 - jk.dqfx当期付息;
                }
                if (hkzq还款周期 == i)
                {
                    //最后一年的，当期还本付息的总额就不在采用A的值。
                    //采用本年的期初借款余额，去掉息，就是本。把2个相加，就是本息和
                    jk.dqhb当期还本= jk.qcjkye期初借款余额;

                }
                    jk.qmjkye期末借款余额 = jk.qcjkye期初借款余额 - jk.dqhb当期还本;
                jklist.Add(jk);
            }
        }

        private double cal等额还本付息总额(double qcdker期初贷款金额,double rate,int hkzq还款周期)
        {
            double benjin本金 = 0;

            benjin本金 = qcdker期初贷款金额 *( Math.Pow(1 + rate, hkzq还款周期)*rate) / (Math.Pow(1 + rate, hkzq还款周期) - 1);
            return benjin本金;
            
        }
    }
}
