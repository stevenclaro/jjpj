using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwpj
{
  public  class jkldzj流动资金借款还本付息
    {
        public int year;
        public double value;

        public double qcjkye期初借款余额;
        public double qmjkye期末借款余额;
        public double dqhb当期还本;
        public double dqfx当期付息;
        public double dqhbfx当期还本付息;
        public double bqjk本期借款;


        public int sxh顺序号;
        public int fx方向;
        public string unit;//元，万元
        public string unitxx;//year，month，季度
        public int xsd小数点位数;
        public string jsq建设期还是运营期;
        //public double value值;
        
    }
}
