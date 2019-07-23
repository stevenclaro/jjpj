using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj
{
    class Program
    {
        static void Main(string[] args)
        {
            //例题5，P23
            globalpara.jk短期借款利率 = 0;
            globalpara.sds所得税税率 = 0.25;
            globalpara.yyq运营期 = 6;
            globalpara.jsqjk建设期借款利息 = 0.06;
            globalpara.hkzq还款周期 = 4;
            globalpara.rate = globalpara.jsqjk建设期借款利息;
            globalpara.ldzj流动资金借款利息 = 0.04;

            //固定资产，无形资产，借款利息的输入后进行计算
            inputdata ind = new inputdata();

            ind.init固定资产();
            List<qzjr期折旧额> qzlist = ind.qzlist;
            List<tx摊销>txlist= ind.init无形资产().txlist;
            
            globalpara.jsqjk建设期借款金额 = ind.ass.jsqjk建设期借款含利息金额;
            ind.init流动资金();

            //把数据放入到利润表的模型中，然后准备进行计算
            jk还本付息表汇总Sheet jkcollection = new cwpj.jk还本付息表汇总Sheet();
            lrsheet利润表 lrsheet = new lrsheet利润表();
            

            //设置关系
            jkcollection.lrsheet利润表 = lrsheet;
            lrsheet.jk还本付息表汇总Sheet = jkcollection;

            List<jk建设期借款还本付息> jk建设期借款还本付息List = jkcollection.jk建设期借款还本付息list;


            //直接输入的值，收入

            ind.init营业收入();
            ind.init补贴收入();
           // List<revenue收入> rlist = ind.revenue收入List;
            //List<butie补贴收入> blist = ind.butie补贴收入List;

            //成本
            ind.initjy经营成本();
            //List<jycb经营成本> jycblist = ind.jycb经营成本List;

           // ind.initzcb总成本();

            //先计算利润表,得到利润表的部分值
            ind.initlr利润表(lrsheet);
            //计算贷款的值
            ind.init借款还本付息singleModel(lrsheet.lr利润list);


            string policyname = "等额还本付息";
            //只会执行一个
            if (policyname == "等额还本付息")
            { 
                jkcollection.get等额还本付息();
            }
            else
            { 
                jkcollection.get等额还本付息照付();
            }



            List<cwpj.singleDomain.revenue收入> revenue收入List = new List<singleDomain.revenue收入>();

          

            jkcollection.get流动资金还本付息();
            jkcollection.get等额还本付息();

            //在计算贷款的过程中，更新lrsheet利润表的值
            //这2个步骤结束之后，利润表及贷款表，各年的值就完成了。
            //这个是程序计算的核心所在。
            List<lr利润> lrlist = lrsheet.lr利润list;
        }
    }
}
