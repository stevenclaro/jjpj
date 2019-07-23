using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwpj.singleDomain
{
    public class zzs增值税
    {
        public double xxsdq当期销项税;
        public double jxsdq当期进项税;
        public double zzx当期增值税应纳税额;
        public double zzx当期增值税附加;
        public int year;
        public double qc当期增值税余额_销项税减去进项税;
        public double qc期初固定资产增值税可抵扣进行税额;
        

        public void cal计算zzx增值税净值()
        {
            zzx当期增值税应纳税额 = xxsdq当期销项税 - jxsdq当期进项税- qc期初固定资产增值税可抵扣进行税额;
            if (zzx当期增值税应纳税额 <= 0)
            {
                zzx当期增值税应纳税额 = 0;
                zzx当期增值税附加 = 0;
            }
            else
            {
                
                zzx当期增值税附加 = zzx当期增值税应纳税额 * globalpara.zzs增值税税率;
            }
        }

    }
}
