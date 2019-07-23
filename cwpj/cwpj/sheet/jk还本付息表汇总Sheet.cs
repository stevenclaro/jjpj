using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj
{
   public class jk还本付息表汇总Sheet
    {
        public lrsheet利润表 lrsheet利润表;
        public List<jk建设期借款还本付息> jk建设期借款还本付息list = new List<jk建设期借款还本付息>();
        public List<jk短期借款还本付息> jk短期借款List = new List<jk短期借款还本付息>();
        public List<jkldzj流动资金借款还本付息> jkldzj流动资金借款List = new List<jkldzj流动资金借款还本付息>();

       
        public List<jk建设期借款还本付息> get等额还本付息()
        {
            policy还款策略 p2 = new policy等额还本付息(lrsheet利润表,this);
            jk建设期借款还本付息list = p2.exec();
            return jk建设期借款还本付息list;
        }
        public List<jk建设期借款还本付息> get等额还本付息照付()
        {
            //compute计算所需参数类 com = new cwpj.compute计算所需参数类();
            globalpara.hkzq还款周期 = 4;
            globalpara.jsqjk建设期借款利息 = 0.06;
            globalpara.jsqjk建设期借款金额 = 2060;
            policy还款策略 pl = new Policy等额还本利息照付(lrsheet利润表, this);
            jk建设期借款还本付息list= pl.exec();
            return jk建设期借款还本付息list;
        }

        public List<jkldzj流动资金借款还本付息> get流动资金还本付息()
        {
            jkldzj流动资金借款List= new ldzj流动资金还款sheet().exec();
            return jkldzj流动资金借款List;

        }

    }
}
