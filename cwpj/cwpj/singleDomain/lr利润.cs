using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.ks亏损拟补;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj.singleDomain
{
  public  class lr利润
    {
        public List<lr利润> lr利润list;
        public revenue收入 revenue收入;
        public zcb总成本 zcb总成本;
        public double lr利润总额;
        public butie补贴收入 butie补贴收入;
        
        public int year;
        public zzs增值税 zzs增值税;
        public double lrze利润总额;
        public double nbyqksben本年拟补以前年度亏损=0;
        public double ynssde应纳税所得额;
        public double sds所得税;
        public double jlr净利润;
        public double qcwfplr期初未分配利润;
        public double kgfplr可供分配利润;
        public double fdyygjj法定盈余公积金;
        public double kgtzzfplr可供投资者分配利润;
        public double yftzzgfgl应付投资者各方股利;
        public double wfplr未分配利润;
        public double yyhkwfplr用于还款未分配利润;
        public double sylr剩余利润_转下一年度期初未分配利润;
        public double EBIT息税前利润;
        public lr利润 cal计算相关值()
        {
            lrze利润总额 = revenue收入.revenue不含税收入值;
            lrze利润总额 = lrze利润总额 - zcb总成本.zcb总成本不含进项税汇总值;
            lrze利润总额 = lrze利润总额 - zzs增值税.zzx当期增值税附加;
            lrze利润总额 = lrze利润总额 + butie补贴收入.bt补贴收入;
                
            Iksnb iks = new ksnb亏损全部拟补();
            nbyqksben本年拟补以前年度亏损 = iks.exec(lr利润list, year);
            
            ynssde应纳税所得额 = lrze利润总额 - nbyqksben本年拟补以前年度亏损;
            sds所得税 = ynssde应纳税所得额 * globalpara.sds所得税税率;
            jlr净利润 = lrze利润总额 - sds所得税;
            if (year == 1) qcwfplr期初未分配利润 = 0;//?
            kgfplr可供分配利润 = (jlr净利润 + qcwfplr期初未分配利润) > 0 ? (jlr净利润 + qcwfplr期初未分配利润) : 0;
            fdyygjj法定盈余公积金 = kgfplr可供分配利润 * globalpara.fdyygjybl法定盈余公积金比例;
            kgtzzfplr可供投资者分配利润 = kgfplr可供分配利润 - fdyygjj法定盈余公积金;
            yftzzgfgl应付投资者各方股利 = kgtzzfplr可供投资者分配利润 * new lrfp利润分配sheet().lrfp利润分配List.Where(x => x.year == year).First().kgtzzfp可供投资者分配利润比例;
            wfplr未分配利润 = kgtzzfplr可供投资者分配利润 - yftzzgfgl应付投资者各方股利;
            //yyhkwfplr用于还款未分配利润
            //sylr剩余利润_转下一年度期初未分配利润
            //EBIT息税前利润=
            return this;
    }

   

    }
}
