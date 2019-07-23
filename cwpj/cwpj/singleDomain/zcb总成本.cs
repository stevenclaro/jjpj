using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwpj.singleDomain
{
  public  class zcb总成本
    {
        public jycb经营成本 jycb经营成本;
        public qzjr期折旧额 zj折旧;
        public tx摊销 tx摊销;
         
        public jklx借款还本利息 jklx借款还本利息;
        //public jk还本付息表集合 jk还本付息表集合;
        public int year;
        public double zcb总成本含进项税汇总值;
        public double zcb总成本不含进项税汇总值;

        public zcb总成本 cal计算相关参数()
        {
            getzcb总成本含进项税汇总值();
            getzcb总成本不含含进项税汇总值();
            return this;
        }
        private zcb总成本 getzcb总成本含进项税汇总值()
        {
            zcb总成本含进项税汇总值 = jycb经营成本.jy含进项税经营成本值 + zj折旧.zje本期折旧额 + tx摊销.tx摊销金额;
            zcb总成本含进项税汇总值 = zcb总成本含进项税汇总值 + jklx借款还本利息.get利息汇总();

            return this;
        }
        private zcb总成本 getzcb总成本不含含进项税汇总值()
        {
            zcb总成本不含进项税汇总值 = jycb经营成本.jy不含进项税经营成本值 + zj折旧.zje本期折旧额 + tx摊销.tx摊销金额;
            zcb总成本不含进项税汇总值 = zcb总成本不含进项税汇总值 + jklx借款还本利息.get利息汇总();

            return this;
        }

    }
}
