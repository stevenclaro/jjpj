using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;

namespace cwpj
{
  public  class policy还款策略
    {
        protected string policyName;
        //protected compute计算所需参数类 com计算所需参数protected;
        //public List<cwpj.sheet.lrsheet利润表> lrsheet利润表;
        //public cwpj.singleDomain.lr利润 lr利润;
        //public List<jk短期借款> jk短期借款List=new List<jk短期借款>();
        public lrsheet利润表 lrsheet利润表;
        public jk还本付息表汇总Sheet jk还本付息表集合;
        //把外部的集合也传入进来，方便对短期借款的控制
        public policy还款策略(lrsheet利润表 lrsheet利润表O,jk还本付息表汇总Sheet jk还本付息表集合l)
        {
            //this.com计算所需参数protected = com计算所需参数;
            this.lrsheet利润表 = lrsheet利润表O;
            this.jk还本付息表集合 = jk还本付息表集合l;
        }
        public virtual List<jk建设期借款还本付息> exec()
        {
            List<jk建设期借款还本付息> jklist = new List<jk建设期借款还本付息>();
            jk建设期借款还本付息 jkFirst = new jk建设期借款还本付息();
            //第一年先进行设置，后面就是每一年的值
            double jsqjk建设期借款 = globalpara.jsqjk建设期借款金额; 
            int hkzq还款周期 = globalpara.hkzq还款周期;
            double rate = globalpara.jsqjk建设期借款利息;
            jkFirst.qmjkye期末借款余额 = globalpara.jsqjk建设期借款金额;
            jkFirst.sxh顺序号 = 1;
            jkFirst.year = 0;//实际上是建设期；
            jklist.Add(jkFirst);
            lrsheet利润表.jk还本付息表汇总Sheet.jk建设期借款还本付息list.Add(jkFirst);
            

            //后面在运营期间各年进行循环

            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                jk建设期借款还本付息 jk = new jk建设期借款还本付息();
                if (i <= hkzq还款周期)
                {
                    
                    //取集合中顺序号最大的，然后取它的期末借款金额，然后把它作为年初的金额
                    jk.qcjkye期初借款余额 = jklist.OrderByDescending(x => x.sxh顺序号).First().qmjkye期末借款余额;
                    jk.sxh顺序号 = jklist.OrderByDescending(x => x.sxh顺序号).First().sxh顺序号 + 1;


                    jk.dqfx当期付息 = jk.qcjkye期初借款余额 * rate;
                    //2个方法的差异，计算本金的时候有差异。把jk传入，是作为地址的方式传入，不是一个Copy值。
                    //只有int，string等基本类型的参数，是作为值传递，其他的是作为引用传递
                    //https://www.cnblogs.com/yhc99/p/9193973.html 
                    cal本期还本金额(i, jk);//计算得到jk的本金

                    jk.qmjkye期末借款余额 = jk.qcjkye期初借款余额 - jk.dqhb当期还本;
                    lr利润 lr利润 = lrsheet利润表.lr利润list.Where(x => x.year == i).First();
                    lr利润.zcb总成本.jklx借款还本利息.jk建设期借款还本付息 = jk;


                    //在这个插入，判断是否需要短期借款
                    create短期借款(i, jk);
                }
                else
                {
                    //插入空值，但是年需要，便于后面进行统一的运算
                    //jk.year = i;

                }
                jklist.Add(jk);
            }
            
            return jklist;
        }
        public virtual void create短期借款(int period, jk建设期借款还本付息 jk)
        {
            jk短期借款还本付息 j = new jk短期借款还本付息();
            j.year = jk.sxh顺序号;
            j.year = period;
            lr利润 lr利润 = lrsheet利润表.lr利润list.Where(x => x.year == period).First();
            lr利润.zcb总成本.jklx借款还本利息.jk短期借款 = j;
            lr利润.cal计算相关值();
            //lrsheet利润表.lr利润list.Add(lr);
            if (lr利润.jlr净利润 < 0)//未来要调整这个判断，先写一个框架结构
            {
                //j.qcjkye期初借款余额
                //计算借款金额
                if (period == 1)//如果是第一年
                {
                    j.qcjkye期初借款余额 = 0;
                    j.qmjkye期末借款余额= lr利润.zcb总成本.jklx借款还本利息.get本金汇总() - (lr利润.zcb总成本.tx摊销.tx摊销金额 + lr利润.zcb总成本.zj折旧.zje本期折旧额 + lr利润.jlr净利润);
                }
                else
                {
                    lr利润 syn上一年利润 = lrsheet利润表.lr利润list.Where(x => x.year == period - 1).First();
                    jk短期借款还本付息 syn上一年短期借款= syn上一年利润.zcb总成本.jklx借款还本利息.jk短期借款;
                    j.qcjkye期初借款余额 = syn上一年短期借款.qmjkye期末借款余额;

                    j.qcjkye期初借款余额 = lr利润.zcb总成本.jklx借款还本利息.jk短期借款.qcjkye期初借款余额;
                }

                j.dqfx当期付息 = j.qcjkye期初借款余额 * globalpara.jk短期借款利率;
                
                lr利润.cal计算相关值();
                
            }

        }
    
        protected virtual jk建设期借款还本付息 cal本期还本金额(int i,jk建设期借款还本付息 jk)
        { 

            
            return null;
        }
      
    }


}
