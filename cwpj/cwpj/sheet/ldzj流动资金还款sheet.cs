using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj
{
  public  class ldzj流动资金还款sheet
    {
        public List<jkldzj流动资金借款还本付息> ldlist;
        double ldzjdklx运营期流动资金贷款利息 = globalpara.ldzj流动资金借款利息;
        public  List<jkldzj流动资金借款还本付息> exec() 
        {
            // List<jk建设期借款还本付息> jklist = new List<jk建设期借款还本付息>();
            //运营期周期
            
            int count = 0;
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                jkldzj流动资金借款还本付息 jk;
                if (ldlist.Where(x => x.year == i).Count() > 0)
                {
                    jk = ldlist.Where(x => x.year == i).First();
                }
                else
                {
                    jk = new jkldzj流动资金借款还本付息();
                }
                
                jk.qcjkye期初借款余额 = ldlist.Where(x => x.year <= i).Sum(y => y.bqjk本期借款);
                jk.dqfx当期付息=jk.qcjkye期初借款余额* ldzjdklx运营期流动资金贷款利息;
                //最后一年进行还本
                count++;
                if (count == globalpara.yyq运营期)
                {
                    jk.dqhb当期还本 = ldlist.Sum(x => x.bqjk本期借款);
                }
                ldlist.Add(jk);
               // lrsheet利润表.lr利润list.Where(x => x.year == i).First().zcb总成本.jklx借款还本利息.jkldzj流动资金借款 = jk;
            }
            return ldlist;
        }
    }
}
