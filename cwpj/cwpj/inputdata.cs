using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cwpj.sheet;
using cwpj.singleDomain;
namespace cwpj
{
  public  class inputdata
    {
        public asset固定资产 ass = new asset固定资产();//是一个多年的集合
        public List<qzjr期折旧额> qzlist = new List<qzjr期折旧额>();
        public List<tx摊销> txlist = new List<tx摊销>();
        public ldzj流动资金还款sheet ldzj流动资金还款sheet = new ldzj流动资金还款sheet();

        public List<cwpj.singleDomain.revenue收入> revenue收入List = new List<singleDomain.revenue收入>();
        public List<butie补贴收入> butie补贴收入List = new List<butie补贴收入>();
        public List<jycb经营成本> jycb经营成本List = new List<jycb经营成本>();
        public List<zcb总成本> zcb总成本List = new List<zcb总成本>();
        public List<zzs增值税> zzs增值税List = new List<zzs增值税>();
        public zcbsheet总成本表 zcbsheet总成本表 = new zcbsheet总成本表();
        public jk还本付息表汇总Sheet jk还本付息表集合 = new jk还本付息表汇总Sheet();

        //案例五，P23
        public void init固定资产()
        {
            //采用数组的输入方法，然后采用循环的方式来输入，简化初始化的工作量
            //因为要输入很多值，不太处理。所以放弃采用数组的输入方式。
            //输入之后进行转换的值
            
            List<jsq固定资产投资> jsq固定资产投资List = ass.jsq固定资产投资List;
            jsq固定资产投资 jsq固定资产投资1 = new jsq固定资产投资();
            jsq固定资产投资1.year = 1;
            jsq固定资产投资1.jkbj借款本金 = 0;
            //jsq固定资产投资1.jsq建设投资 = 1200;
            jsq固定资产投资1.zbj资本金 = 1200;
            ass.jsq固定资产投资List.Add(jsq固定资产投资1);

            jsq固定资产投资 jsq固定资产投资2 = new jsq固定资产投资();
            jsq固定资产投资2.year = 2;
            jsq固定资产投资2.jkbj借款本金 = 2000;

            jsq固定资产投资2.zbj资本金 = 340;
            ass.jsq固定资产投资List.Add(jsq固定资产投资2);
            ass.zjnx折旧期限 = 10;
            ass.gdzcczl固定资产残值率 = 0.04;
            ass.wxzc无形资产原值 = 540;
            ass.pl = new policy折旧年平均法();

            ass.cal计算固定资产相关参数();//计算得到固定资产原值

            qzlist = ass.qzlist;

            

        }
        public inputdata init无形资产()
        {
            wxzc无形资产sheet wxsheet = new wxzc无形资产sheet(ass.wxzc无形资产原值);
            txlist=wxsheet.gettx摊销();
            return this;
        }
        public void init流动资金()
        {
            List<jkldzj流动资金借款还本付息> jklist = new List<cwpj.jkldzj流动资金借款还本付息>();
            int period运营期周期 = globalpara.yyq运营期;
            
            List<jkldzj流动资金借款还本付息> ldlist = new List<cwpj.jkldzj流动资金借款还本付息>();
            jkldzj流动资金借款还本付息 ld = new cwpj.jkldzj流动资金借款还本付息();
            ld.year = 1;
            ld.bqjk本期借款 = 100;
            ldlist.Add(ld);
            jkldzj流动资金借款还本付息 ld2 = new cwpj.jkldzj流动资金借款还本付息();
            ld2.year = 2;
            ld2.bqjk本期借款 = 400;
            ldlist.Add(ld2);

            ldzj流动资金还款sheet.ldlist = ldlist;
            ldlist=ldzj流动资金还款sheet.exec();

        }
        public void init营业收入()
        {
            cwpj.singleDomain.revenue收入 re1 = new singleDomain.revenue收入();
            re1.year = 1;
            re1.revenue含税收入值 = 2527.20;
            revenue收入List.Add(re1);
            cwpj.singleDomain.revenue收入 re2 = new singleDomain.revenue收入();
            re2.year = 2;
            re2.revenue含税收入值 = 5054.40;
            revenue收入List.Add(re2);
            revenue收入 re3 = new singleDomain.revenue收入();
            re3.year = 3;
            re3.revenue含税收入值 = 5054.40;
            revenue收入List.Add(re3);
            revenue收入 re4 = new singleDomain.revenue收入();
            re4.year = 4;
            re4.revenue含税收入值 = 5054.40;
            revenue收入List.Add(re4);
            revenue收入 re5 = new singleDomain.revenue收入();
            re5.year = 5;
            re5.revenue含税收入值 = 5054.40;
            revenue收入List.Add(re5);
            revenue收入 re6 = new singleDomain.revenue收入();
            re6.year = 6;
            re6.revenue含税收入值 = 5054.40;
            revenue收入List.Add(re6);
        }
        public void init补贴收入()
        {
            for(int i=1;i<=globalpara.yyq运营期;i++)
            { 
                butie补贴收入 bt = new butie补贴收入();
                bt.year = i;
                bt.bt补贴收入 = 0;
                butie补贴收入List.Add(bt);
            }

        }
        public void initjy经营成本()
        {
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                jycb经营成本 jy = new jycb经营成本();
                if (i == 1)
                {
                    jy.jy含进项税经营成本值 = 1900;
                }
                else
                {
                    jy.jy含进项税经营成本值 = 3648;
                }

                jy.year = i;
                
                jycb经营成本List.Add(jy);
            }

        }
        //public void initzcb总成本()
        //{
        //    for (int i = 1; i <= globalpara.yyq运营期; i++)
        //    { 
        //        zcb总成本 zcb = new zcb总成本();
        //        zcb.year = i;
        //        zcb.jycb经营成本 = jycb经营成本List.Where(x => x.year == i).First();
        //        zcb.tx摊销=txlist.Where(x => x.year == i).First();
        //        zcb.zj折旧=qzlist.Where(x => x.period == i).First();
        //        //zcb.jklx借款还本利息.jkldzj流动资金借款 = jk还本付息表集合.jkldzj流动资金借款List.Where(x => x.year == i).First();
        //        //zcb.jklx借款还本利息.jk建设期借款还本付息= jk还本付息表集合.get等额还本付息().Where(x => x.year == i).First();
        //        //zcb.jklx借款还本利息.jk短期借款=jk还本付息表集合.jk短期借款List.Where(x => x.year == i).First();
        //        zcb总成本List.Add(zcb);
        //    }
        //    zcbsheet总成本表.zcb总成本List = zcb总成本List;
        //}
        public void init借款还本付息singleModel(List<lr利润> lr利润list)
        {
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                jklx借款还本利息 jk = new jklx借款还本利息();
                jk.year = i;
                lr利润list.Where(x => x.year == i).First().zcb总成本.jklx借款还本利息 = jk;
            }
        }
        public lrsheet利润表 initlr利润表(lrsheet利润表 lrsheet)
        {
            
            for (int i = 1; i <= globalpara.yyq运营期; i++)
            {
                lr利润 lr = new lr利润();
                lr.year = i;
                lr.revenue收入 = revenue收入List.Where(x => x.year == i).First();
                lr.butie补贴收入=butie补贴收入List.Where(x => x.year == i).First();
                //总成本初始化
                zcb总成本 zcb = new zcb总成本();
                zcb.year = i;
                zcb.jycb经营成本=jycb经营成本List.Where(x => x.year == i).First();
                zcb.tx摊销=txlist.Where(x => x.year == i).First();
                zcb.zj折旧= qzlist.Where(x => x.period == i).First();
                jklx借款还本利息 jk = new jklx借款还本利息();
                jk.year = i;
                zcb.jklx借款还本利息 = jk;

                zcb.cal计算相关参数();
                lr.zcb总成本 = zcb;
                zcb总成本List.Add(zcb);
                //增值税初始化

                zzs增值税 zzs增值税 = new zzs增值税();
                if (i == 1)
                {
                    zzs增值税.qc期初固定资产增值税可抵扣进行税额 = ass.kdk可抵扣固定资产进项税额;

                }
                zzs增值税.xxsdq当期销项税 = lr.revenue收入.revenue含税收入值 * globalpara.zzs增值税税率;
                zzs增值税.jxsdq当期进项税=lr.zcb总成本.jycb经营成本.jy含进项税经营成本值* globalpara.zzs增值税税率;
                zzs增值税.qc当期增值税余额_销项税减去进项税 = zzs增值税.xxsdq当期销项税 - zzs增值税.jxsdq当期进项税;
                zzs增值税List.Add(zzs增值税);
                if (zzs增值税.qc当期增值税余额_销项税减去进项税 <= 0)
                {
                    zzs增值税.zzx当期增值税应纳税额 = 0;
                    
                }
                if (zzs增值税.qc当期增值税余额_销项税减去进项税 > 0)
                {//已经考虑到本年累计进去，如果累计到本年值含本年，与本年进行比较，如果大于0，那么就
                    double value = zzs增值税List.Where(x => x.year <= i).Sum(y => y.qc当期增值税余额_销项税减去进项税);
                    if (value > 0)
                    {
                        if (zzs增值税.qc当期增值税余额_销项税减去进项税 >= value)
                        {
                            //说明历史上已经补完负值，并且也不是今年补的，目前暂时不考虑每年的销项税小于进项税的情况,
                            zzs增值税.zzx当期增值税应纳税额 = zzs增值税.qc当期增值税余额_销项税减去进项税;
                        }
                        else
                        {//说明历史上的负值，是今年补的
                            zzs增值税.zzx当期增值税应纳税额 = zzs增值税.qc当期增值税余额_销项税减去进项税 - value;
                        }

                     }
                    else
                      {
                          zzs增值税.zzx当期增值税应纳税额 = 0;

                      }
                    
                }
                
                zzs增值税.zzx当期增值税附加 = zzs增值税.zzx当期增值税应纳税额 * globalpara.zzs增值税附加综合税率;
                zzs增值税List.Add(zzs增值税);
                lr.zzs增值税 = zzs增值税;

                lr.lr利润list = lrsheet.lr利润list;
                //下面增加借款的内容

                // lr.zcb总成本.jklx借款还本利息.jkldzj流动资金借款 = zcb总成本List.Where(x => x.year == i).First().jklx借款还本利息.jkldzj流动资金借款;
                //lr.zcb总成本.jklx借款还本利息.jk建设期借款还本付息 = zcb总成本List.Where(x => x.year == i).First().jklx借款还本利息.jk建设期借款还本付息;
                //lr.zcb总成本.jklx借款还本利息.jk短期借款 = zcb总成本List.Where(x => x.year == i).First().jklx借款还本利息.jk短期借款;
                lrsheet.lr利润list.Add(lr);

            }
            return lrsheet;
        }
    }
}
