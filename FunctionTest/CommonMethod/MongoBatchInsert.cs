using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module;
using Tc.Gny.Framework.MongoORM40;

namespace CommonMethod
{
    public class MongoBatchInsert
    {
        public void MongoBatchInsertTest(List<ProductDatePriceLog> listLogs)
        {
            List<ProductDatePriceLog> listLogsMatch = new List<ProductDatePriceLog>();
            int tempIndex = 0;
            for (int i = 0; i < listLogs.Count * 1000; i++)
            {
                listLogsMatch.Add(listLogs[tempIndex]);
                tempIndex++;
                if (i % listLogs.Count == 0)
                {
                    tempIndex = 0;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                int pageSize = 20000;
                List<ProductDatePriceLog> listLogsTemp = listLogsMatch.Skip(i * pageSize).Take(pageSize).ToList().DeepClone();
                if (listLogsTemp.Any())
                {
                    Task.Factory.StartNew(() =>
                    {
                        //var mongoContext = new MongoDbRepository<ProductDatePriceLog>("ProductDatePriceLog", "ProductMongoConnection", "TCGnyProduct");
                        //mongoContext.AddBatch(listLogsTemp);
                    });
                }
            }
        }
    }
}
