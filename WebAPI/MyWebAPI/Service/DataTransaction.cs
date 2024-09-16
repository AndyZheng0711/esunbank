using System.Data;
using System.Reflection;

namespace MyWebAPI.Service
{
    public class DataTransaction
    {
        public List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            List<T> list = new List<T>();
            T t = new T();
            PropertyInfo[] prop = t.GetType().GetProperties();
            //遍歷所有DataTable的行 
            foreach (DataRow dr in dt.Rows)
            {
                t = new T();
                //通過反射獲取T類型的所有成員
                foreach (PropertyInfo pi in prop)
                {
                    //DataTable列名=屬性名
                    if (dt.Columns.Contains(pi.Name))
                    {
                        //屬性值不為空
                        if (dr[pi.Name] != DBNull.Value)
                        {
                            object value = Convert.ChangeType(dr[pi.Name], pi.PropertyType);
                            //給T類型字段賦值
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //將T類型添加到集合list
                list.Add(t);
            }
            return list;

        }
    }
}
