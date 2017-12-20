using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TX.DB.Interface;
using TX.Factory;
using TX.Model;
using TX.SqlDBHelper;

namespace 腾讯课程作业
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // UserModel user = SqlServerDBHeler.GetT<UserModel>(1);
                //CompanyModel company = SqlServerDBHeler.GetT<CompanyModel>(1); 

                // List<UserModel> userList = SqlServerDBHeler.GetListModel<UserModel>();
                // List<CompanyModel> companyList = SqlServerDBHeler.GetListModel<CompanyModel>();

                // CompanyModel companyModel = SqlServerDBHeler.InsertT<CompanyModel>(new CompanyModel() { Name = "张沐杨", CreatorId = 14, CreateTime = DateTime.Now });
                //companyModel.LastModifyTime = DateTime.Now;
                //bool isOk = SqlServerDBHeler.UpdateT<CompanyModel>(companyModel);

                // SqlServerDBHeler.DeleteT<CompanyModel>(1004);


                #region 简单配置+反射+工厂
                var tuple = SimpleFactory.GetDBHeler();
                if (tuple.Item1 == false)
                    return;
                IDBHelper dbHelper = tuple.Item2;
                UserModel user = dbHelper.GetT<UserModel>(1);

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
