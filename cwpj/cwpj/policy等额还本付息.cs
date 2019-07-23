using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj
{
  public  class policy等额还本付息:policy还款策略
    {
        double dehbfxzr等额还本付息总额 = 0;
        public policy等额还本付息(lrsheet利润表 lrsheet利润表, jk还本付息表汇总Sheet jk还本付息表集合l) : base(lrsheet利润表, jk还本付息表集合l)
        {
            dehbfxzr等额还本付息总额=cal等额还本付息总额();//在构造函数中，计算一次
            policyName = "等额还本付息";
        }
        

        private   double cal等额还本付息总额()
        {//根据P，I来求A
            double qcdker期初贷款金额 = globalpara.jsqjk建设期借款金额;
            double rate = globalpara.jsqjk建设期借款利息;
            int hkzq还款周期 = globalpara.hkzq还款周期;
            double benjin本金 = 0;

            benjin本金 = qcdker期初贷款金额 * (Math.Pow(1 + rate, hkzq还款周期) * rate) / (Math.Pow(1 + rate, hkzq还款周期) - 1);
            return benjin本金;

        }
        protected override jk建设期借款还本付息 cal本期还本金额(int i, jk建设期借款还本付息 jk)
        {

            int hkzq还款周期 = globalpara.hkzq还款周期;
           // double dehbfxzr等额还本付息总额 = 0;

            //dehbfxzr等额还本付息总额 = cal等额还本付息总额();

            if (hkzq还款周期 != i)
            {
                jk.dqhb当期还本 = dehbfxzr等额还本付息总额 - jk.dqfx当期付息;
            }
            if (hkzq还款周期 == i)
            {
                //最后一年的，当期还本付息的总额就不在采用A的值。
                //采用本年的期初借款余额，去掉息，就是本。把2个相加，就是本息和
                jk.dqhb当期还本 = jk.qcjkye期初借款余额;

            }
            jk.dqhbfx当期还本付息 = dehbfxzr等额还本付息总额;
            return jk;
        }


    }
}
