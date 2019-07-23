using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.singleDomain;
namespace cwpj.sheet
{
   public class zcbsheet总成本表
    {
        public List<zcb总成本> zcb总成本List;
        public zcbsheet总成本表()
            {
                zcb总成本List = new List<singleDomain.zcb总成本>();
            }
        public void get总成本表()
        {
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                zcb总成本 zcb = new zcb总成本();

                zcb总成本List.Add(zcb);
            }
        }
    }
}
