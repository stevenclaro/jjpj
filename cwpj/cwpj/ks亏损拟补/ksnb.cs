using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj.ks亏损拟补
{
  public  interface Iksnb
    {
        double exec(List<lr利润> lr利润list, int year);
        
    }
    public class ksnb亏损全部拟补:Iksnb
    {
        public double exec(List<lr利润> lr利润list, int year)
        {
            //这个拟补以前亏损的，未来需要进行调整，可能需要补几年
            double nbyqksben本年拟补以前年度亏损=0;
            if (year==1) nbyqksben本年拟补以前年度亏损 = 0;
            if (year != 1)
            {
                if (lr利润list.Where(x => x.year < year).Sum(y => y.jlr净利润) < 0)
                {
                    nbyqksben本年拟补以前年度亏损 = System.Math.Abs(lr利润list.Where(x => x.year == year - 1).First().jlr净利润);
                }
                else
                {
                    nbyqksben本年拟补以前年度亏损 = 0;
                }
            }
            
            return nbyqksben本年拟补以前年度亏损;
        }
    }
    

}
