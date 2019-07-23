using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwpj.singleDomain
{
 public   class jklx借款还本利息
    {
        public int year;
        public jk建设期借款还本付息 jk建设期借款还本付息;
        public jkldzj流动资金借款还本付息 jkldzj流动资金借款;
        public jk短期借款还本付息 jk短期借款;
        public double year利息汇总;
        public double year本金汇总;
        public double get利息汇总()
        {
            year利息汇总=jkldzj流动资金借款.dqfx当期付息 + jkldzj流动资金借款.dqfx当期付息 + jk短期借款.dqfx当期付息;
            return year利息汇总;
        }
        public double get本金汇总()
        {
            year本金汇总= jk建设期借款还本付息.dqhb当期还本 + jkldzj流动资金借款.dqhb当期还本 + jk短期借款.dqhb当期还本;
            return year本金汇总;
        }
    }
}
