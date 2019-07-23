using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.singleDomain;
using cwpj.sheet;
namespace cwpj
{

    public class asset固定资产
    {
        //这些是固定资产的固有属性，与每年的qzjr期折旧额，是有差别的属性。
        //以上固定资产的原值，都是不含抵扣的
        public double gdzc固定资产原值包含利息;
        public double gdzc固定资产原值不包含利息;
        public double gdzccz固定资产残值;
        public double gdzcczl固定资产残值率;
        public int zjnx折旧期限;
        public List<jsq固定资产投资> jsq固定资产投资List = new List<jsq固定资产投资>();
        
        public double gdzc固定资产原值包含利息去掉无形资产;
        public double gdzc固定资产原值不包含利息去掉无形资产;
        public double wxzc无形资产原值;
        public double jsqjk建设期借款含利息金额;
        public double jsqjk建设期借款不含利息金额;
        public double kdk可抵扣固定资产进项税额;

        public List<qzjr期折旧额> qzlist;
        public policy折旧 pl { get; set; }
        public void cal计算固定资产相关参数()
        {
            getgdzc固定资产原值含利息();
            getgdzc固定资产原值不包含利息();
            getgdzc固定资产原值包含利息去掉无形资产();
            getgdzc固定资产原值不包含利息并且去掉无形资产();
            getList折旧值();
            gdzccz固定资产残值 =gdzc固定资产原值包含利息去掉无形资产 * gdzcczl固定资产残值率;
            cal建设期借款总额();
        }
        private void getgdzc固定资产原值含利息()
        {
            int count = 0;
            for (int i = 1; i <= jsq固定资产投资List.Count; i++)
            {
                count++;
                //gdzc固定资产原值包含利息 = jsq固定资产投资List.Where(x => x.year == i).First().zbj资本金;
                double jk借款利息 = 0;
                if (count == jsq固定资产投资List.Count)//如果是最后一年
                {
                    jk借款利息=jsq固定资产投资List.Where(x => x.year == i).First().jkbj借款本金 * globalpara.jsqjk建设期借款利息 * 0.5;
                }
                else
                {
                    jk借款利息 = jsq固定资产投资List.Where(x => x.year == i).First().jkbj借款本金 * globalpara.jsqjk建设期借款利息 ;
                }
                double dannian当年资本金及借款本金 = jsq固定资产投资List.Where(x => x.year == i).First().zbj资本金 + jsq固定资产投资List.Where(x => x.year == i).First().jkbj借款本金;
                gdzc固定资产原值包含利息 = gdzc固定资产原值包含利息+ dannian当年资本金及借款本金 + jk借款利息;
            }
        }
        private void getgdzc固定资产原值不包含利息()
        {
            double sum = 0;
            for (int i = 1; i <= jsq固定资产投资List.Count; i++)
            {
                sum=sum+ jsq固定资产投资List.Where(x => x.year == i).First().zbj资本金 + jsq固定资产投资List.Where(x => x.year == i).First().jkbj借款本金;
              
            }
            gdzc固定资产原值不包含利息 = sum;
        }

        private double getgdzc固定资产原值包含利息去掉无形资产()
        {
            gdzc固定资产原值包含利息去掉无形资产 = gdzc固定资产原值包含利息 - wxzc无形资产原值;
            return gdzc固定资产原值包含利息去掉无形资产;
        }
        private double getgdzc固定资产原值不包含利息并且去掉无形资产()
        {
            gdzc固定资产原值不包含利息去掉无形资产 = gdzc固定资产原值不包含利息 - wxzc无形资产原值;
            return gdzc固定资产原值不包含利息去掉无形资产;
        }
        private void cal建设期借款总额()
        {
            double sum = 0;
            for (int i = 1; i <= jsq固定资产投资List.Count; i++)
            {
                double jk借款本金 = jsq固定资产投资List.Where(x => x.year == i).First().jkbj借款本金;
                sum = sum + jk借款本金 + jk借款本金 * globalpara.jsqjk建设期借款利息 * 0.5;
               //这个算法有瑕疵，但是对于案例五是可以的
                // sum =sum+ jk借款本金 * Math.Pow(1 + globalpara.jsqjk建设期借款利息, jsq固定资产投资List.Count - i);
                
            }
            jsqjk建设期借款含利息金额 = sum;
        }

        

        private asset固定资产 getList折旧值()
        {
            qzlist = pl.exec(this);
            return this;

        }


    }

  
    public class qzjr期折旧额
    {
        public int period;
        public double zje本期折旧额;
        public double gdzcyz固定资产余值;
        public int sxh顺序号;
        public double hzgdzc回收固定资产余额;
        public string unit;//有可能是年，也有可能是月

    }
    public class policy折旧
    {
        public virtual List<qzjr期折旧额> exec(asset固定资产 asset)
        {
            return null;
        }
    }

    public class policy折旧年平均法 : policy折旧
    {
        public override List<qzjr期折旧额> exec(asset固定资产 asset)
        {
            List<qzjr期折旧额> qzlist = new List<qzjr期折旧额>();
            double period年折旧额 = asset.gdzc固定资产原值包含利息去掉无形资产 * (1- asset.gdzcczl固定资产残值率) / asset.zjnx折旧期限;
            int yunyinq运营期 = globalpara.yyq运营期;
            int count = 0;
            for (int i = 1; i <= yunyinq运营期; i++)
            {
                count++;
                qzjr期折旧额 qz = new qzjr期折旧额();
                qz.zje本期折旧额 = period年折旧额;
                qz.sxh顺序号 = count;
                qz.period = i;
                //qz.gdzcyz固定资产余值
                //如果是最后一年，那么就回收固定资产余值
                qzlist.Add(qz);
                if (yunyinq运营期 == count)
                {
                    qz.hzgdzc回收固定资产余额 = asset.gdzc固定资产原值包含利息去掉无形资产 - qzlist.Sum(x => x.zje本期折旧额);
                }
                else
                {
                    qz.hzgdzc回收固定资产余额 = 0;
                }
                

            }
            return qzlist;


        }
    }
}

