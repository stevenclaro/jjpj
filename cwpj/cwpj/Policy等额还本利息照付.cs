using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj
{
  public  class Policy等额还本利息照付:policy还款策略
    {
        public Policy等额还本利息照付(lrsheet利润表 lrsheet利润表, jk还本付息表汇总Sheet jk还本付息表集合l) : base(lrsheet利润表, jk还本付息表集合l)
        {
            policyName = "等额还本利息照付";
        }
        
       
        protected override jk建设期借款还本付息 cal本期还本金额(int i, jk建设期借款还本付息 jk)
        {
            double hkzq还款周期 = globalpara.hkzq还款周期;
            jk.dqhb当期还本 = globalpara.jsqjk建设期借款利息 / hkzq还款周期;

            jk.dqhbfx当期还本付息 = jk.dqhb当期还本 + jk.dqfx当期付息;
            return jk;
        }

    }
}
