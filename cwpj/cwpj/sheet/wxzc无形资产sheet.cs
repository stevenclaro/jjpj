using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.singleDomain;
namespace cwpj.sheet
{
   public class wxzc无形资产sheet
    {
        private double wxzcinternal;
        public wxzc无形资产sheet(double wxzc)
        {
            wxzcinternal = wxzc;
        }
        public List<tx摊销> gettx摊销()
        {
            List<tx摊销> txlist = new List<tx摊销>();
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                tx摊销 t = new tx摊销();
                t.year = i;
                t.tx摊销金额 = wxzcinternal / globalpara.yyq运营期;
                txlist.Add(t);
            }
            return txlist;
        }
    }
}
