using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.singleDomain;

namespace cwpj.sheet
{
   public   class lrfp利润分配sheet
    {
        public  List<lrfp利润分配> lrfp利润分配List = new List<lrfp利润分配>();
        public lrfp利润分配sheet()
        {
            
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                lrfp利润分配 lr = new singleDomain.lrfp利润分配();
                lr.year = i;
                lr.fdyygjj法定盈余公积金 = 0.1;
                if (i == 1 || i == 2)
                {
                    lr.kgtzzfp可供投资者分配利润比例 = 0.1;
                }
                else
                {
                    lr.kgtzzfp可供投资者分配利润比例 = 0.3;
                }
                lrfp利润分配List.Add(lr);
            }
        }

    }
}
