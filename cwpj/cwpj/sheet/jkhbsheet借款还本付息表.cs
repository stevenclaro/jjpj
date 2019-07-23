using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwpj.sheet
{
  public  class jkhbsheet借款还本付息表
    {
        public List<cwpj.singleDomain.jklx借款还本利息> jklx借款利息List = new List<singleDomain.jklx借款还本利息>();
        public Dictionary<int, double> dic利息汇总 = new Dictionary<int, double>();//年的利息汇总值
        
        public void getlx所有的利息()
        {
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                cwpj.singleDomain.jklx借款还本利息 jk = new singleDomain.jklx借款还本利息();
                jk.year = i;
                jk.get利息汇总();
                dic利息汇总.Add(i, jk.get利息汇总());

            }
        }
    }
}
