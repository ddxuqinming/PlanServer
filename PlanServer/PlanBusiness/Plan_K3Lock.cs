using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using sun.DataProvider;
using System.Xml.Linq ;
using Microsoft.VisualBasic;
namespace PlanServer 
{
    class Plan_K3Lock : PlanBase
    {
        public   Plan_K3Lock()
        {
            this._id = "Plan_K3Lock";
            this.Name = "K3材料锁库";
        }
        public override bool Execute()
        {

               LockStock();
               System.Threading.Thread.Sleep(5000);
               UnLockStock();
               return true;
        }

        private void LockStock()
        {

          
            string strConn = DataAccess.getNewSqlConnectionString(this.K3DBCfg.Server, this.K3DBCfg.User, this.K3DBCfg.Pwd, this.K3DBCfg.Db, "PlanServer", "");
            DataAccess k3db = new DataAccess(strConn, DataAccess.DbProviderFactoryTypeEnum.SqlClient);
            strConn = DataAccess.getNewSqlConnectionString(this.PTDBCfg.Server, this.PTDBCfg.User, this.PTDBCfg.Pwd, this.PTDBCfg.Db, "PlanServer", "");
            DataAccess ptdb = new DataAccess(strConn, DataAccess.DbProviderFactoryTypeEnum.SqlClient);
            try
            {


                k3db.Open();
                //1从投料单查询记录
                string sql = @"  select    t1.FInterID,t1.FBillNo  , t1.FDate , 
                 t2.FentryID, t2.FItemID,t3.FNumber  ,t3.FName  ,t3.FModel  ,t4.FName as FUnit,t2.FBatchNo  ,
                  t2.FAuxQtyMust as 计划投料数量,  getdate() as FLockDate
                  from PPBOM  t1 INNER JOIN   PPBOMEntry t2 ON t1.FInterID = t2.FInterID  
                  left join t_ICItem t3 ON   t2.FItemID = t3.FItemID and t3.FItemID <>0  
                  LEFT  JOIN t_MeasureUnit AS T4 ON T2.FUnitID = T4.FItemID  and T4.FItemID <>0
                  where  DateDiff( d,t1.FDate,getdate())<=60 and  t3.FBatchManager=0 --未启用批次
                  and t1.FCheckerID<>0
                   and exists(select 1 from  ICMO a join vw_ICMOStatus b on  a.FInterID = b.FInterID  --执行状态
                  where t1.FICMOInterID=a.FInterID and  b.FMoStatusName<>'完全入库'  and  b.FMoStatusName<>'结案')  ";
                DataTable dtbPPBOM = k3db.getDataTable(sql);
                k3db.Close();

                //2与信息平台比较

                ptdb.Open();
                sun.DataProvider.CommandBuilder cb = new sun.DataProvider.CommandBuilder("uSaleLockStock");
                cb.XuDb = ptdb;
                var count = 0;
                foreach (DataRow drw in dtbPPBOM.Rows)
                {
                    if (!ptdb.isExist("select 1 from uSaleLockStock where FType=2 and FInterID=" + drw["FInterID"] + " and FEntryID=" + drw["FEntryID"] + " and FBillNo='" + drw["FBillNo"] + "'"))
                    {
                        //插入
                        sun.Common.KeyValueList kv = new sun.Common.KeyValueList();
                        kv.Add("FType", 2);
                        //kv.Add("FSourceMainID", FSourceMainID);
                        //kv.Add("FSourceRequestID", FSourceRequestID);
                        //kv.Add("FSourceDetailID", _with1.Item("FAutoID"));
                        //kv.Add("FConnID", FConnID);
                        kv.Add("FInterID", drw["FInterID"]);
                        kv.Add("FBillNo", drw["FBillNo"]);
                        kv.Add("FDate", drw["FDate"]);
                        //

                        kv.Add("FEntryID", drw["FEntryID"]);
                        kv.Add("FItemID", drw["FItemID"]);
                        kv.Add("FNumber", drw["FNumber"]);
                        kv.Add("FName", drw["FName"]);
                        kv.Add("FModel", drw["FModel"]);
                        kv.Add("FUnit", drw["FUnit"]);
                        kv.Add("FBatchNo", drw["FBatchNo"]);
                        kv.Add("FLockStockQty", drw["计划投料数量"]);
                        kv.Add("FLockStock", 1); //'1-40287锁库,2-40288未锁库

                        kv.Add("FLockUser", "timer");
                        kv.Add("FLockDate", DateTime.Now);
                        System.Data.Common.DbCommand cmd = cb.CreateInsertCommand(kv, null, false);
                        ptdb.ExeSql(cmd);
                    }

                    //每100行暂停下
                    count += 1;
                    if (count % 100 == 0)
                        System.Threading.Thread.Sleep(200);


                }//foreach
               
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                ptdb.Close();
                k3db.Close();
            }
        }

        private void UnLockStock()
        {

            string  strConn = DataAccess.getNewSqlConnectionString(this.PTDBCfg.Server, this.PTDBCfg.User, this.PTDBCfg.Pwd, this.PTDBCfg.Db, "PlanServer", "");
            DataAccess ptdb = new DataAccess(strConn, DataAccess.DbProviderFactoryTypeEnum.SqlClient);
        
            strConn = DataAccess.getNewSqlConnectionString(this.K3DBCfg.Server, this.K3DBCfg.User, this.K3DBCfg.Pwd, this.K3DBCfg.Db, "PlanServer", "");
            DataAccess k3db = new DataAccess(strConn, DataAccess.DbProviderFactoryTypeEnum.SqlClient);
            try
            {


                ptdb.Open();
                k3db.Open();

                //从信息平台取锁库记录
                DataTable dtbLock = ptdb.getDataTable("select * from uSaleLockStock where FType=2 and  DateDiff( d, FLockDate,getdate())<=90");
                var count = 0;
                string sql;
                object FAuxStockQty;//已领数量
                foreach (DataRow drw in dtbLock.Rows)
                {
                    sql = @"  select FAuxStockQty
                  from PPBOM  t1 INNER JOIN   PPBOMEntry t2 ON t1.FInterID = t2.FInterID  
                  where t1.FInterID={0}   and t1.FCheckerID<>0 and t2.FEntryID={1} and t1.FBillNo='{2}'";
                    FAuxStockQty = k3db.ExecuteScalarBatch(String.Format(sql, drw["FInterID"], drw["FEntryID"], drw["FBillNo"]));

                    if (FAuxStockQty == null) //如果K3不存在(如删除、取消审核了)，则删除
                    {
                        ptdb.ExeSqlBatch("delete from  uSaleLockStock where FType=2 and FAutoID=" + drw["FAutoID"]);
                    }
                    else //更新解锁数量
                    {
                        if (Conversion.Val(FAuxStockQty.ToString())>=Conversion.Val ( drw["FLockStockQty"].ToString ())) //已领数量大于锁库数量
                            ptdb.ExeSqlBatch("update    uSaleLockStock set FLockStock=2,FUnLockStockQty=" + Conversion.Val(FAuxStockQty.ToString()) + " ,FUnLockDate=getdate() where FType=2 and FAutoID=" + drw["FAutoID"]);
                        else
                            ptdb.ExeSqlBatch("update    uSaleLockStock set FUnLockStockQty=" + Conversion.Val(FAuxStockQty.ToString()) + "   where FType=2 and FAutoID=" + drw["FAutoID"]);

                    }

                    //每100行暂停下
                    count += 1;
                    if (count % 100 == 0)
                        System.Threading.Thread.Sleep(200);


                }//foreach
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                ptdb.Close();
                k3db.Close();
            }
 
        }
    }//class
}
