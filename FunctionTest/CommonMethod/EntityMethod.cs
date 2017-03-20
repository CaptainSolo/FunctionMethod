using System;
using System.Collections.Generic;
using System.Linq;
using Module;

namespace CommonMethod
{
    public class EntityMethod
    {
        public static void GetComplaintInfo()
        {
            int total;
            var houseList = new List<TourismOriginFeedbackOrder>();
            using (var context = new TCTourismEbookingEntities())
            {
                int page = 1;
                int pagesize = 10;
                var query = context.TourismOriginFeedbackOrders.AsQueryable();
                total = query.Count();
                houseList = query.OrderBy(t => t.TOFId).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            }
            Console.WriteLine("日志行数:" + total);
            Console.WriteLine("日志内容:" + houseList.ToJson());
            Console.Read();
        }
    }
}
