using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.singleDomain;
namespace cwpj.sheet
{
   public class lrsheet利润表
    {
        public List<cwpj.singleDomain.lr利润> lr利润list = new List<singleDomain.lr利润>();

        public List<revenue收入> revenue收入List;

        public List<butie补贴收入> butie补贴收入List;

        public jk还本付息表汇总Sheet jk还本付息表汇总Sheet;
        public void init利润表()
        {
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                lr利润 lr利润 = new singleDomain.lr利润();
                lr利润.year = i;
                //把其他的数据放入进来
                //补贴收入，收入，
                lr利润.revenue收入 = revenue收入List.Where(x => x.year == i).First();

                lr利润.lr利润总额 = -1;
                lr利润list.Add(lr利润);
            }
        }

    }
}
