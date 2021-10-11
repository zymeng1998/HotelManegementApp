using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagementApp.Data.Model;
using Antra.HotelManagementApp.Data.Repository;
using System.Data;

namespace Antra.HotelManagementApp.Data.Repository
{
    public class RTRepo : IRepository<RoomType>
    {
        DbContext db;
        public RTRepo()
        {
            db = new DbContext();
        }
        int IRepository<RoomType>.Delete(int id)
        {
            string cmd = "Delete from RoomType where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);
        }

        IEnumerable<RoomType> IRepository<RoomType>.GetAll()
        {
            List<RoomType> lstCollection = new List<RoomType>();
            DataTable dt = db.Query("Select Id, Type, Price from RoomType", null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    RoomType rt = new RoomType();
                    rt.Id = Convert.ToInt32(dataRow["Id"]);
                    rt.Type = Convert.ToString(dataRow["Type"]);
                    rt.Price = Convert.ToDecimal(dataRow["Price"]);
                    
                    lstCollection.Add(rt);
                }
            }

            return lstCollection;
        }

        RoomType IRepository<RoomType>.GetById(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@id", id);
            DataTable dt = db.Query("Select Id, Type, Price, where Id=@id", param);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];
                RoomType rt = new RoomType();
                rt.Id = Convert.ToInt32(dataRow["Id"]);
                rt.Type = Convert.ToString(dataRow["Type"]);
                rt.Price = Convert.ToDecimal(dataRow["Price"]);
                return rt;
            }
            return null;
        }

        int IRepository<RoomType>.Insert(RoomType item)
        {
            string cmd = "Insert into RoomType values (@id, @type, @price)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", item.Id);
            parameters.Add("@type", item.Type);
            parameters.Add("@price", item.Price);

            return db.Execute(cmd, parameters);
        }

        int IRepository<RoomType>.Update(RoomType item)
        {
            string cmd = "Update RoomType set Id = @id, Type = @type, Price = @price)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", item.Id);
            parameters.Add("@type", item.Type);
            parameters.Add("@price", item.Price);

            return db.Execute(cmd, parameters);
        }
    }
}
