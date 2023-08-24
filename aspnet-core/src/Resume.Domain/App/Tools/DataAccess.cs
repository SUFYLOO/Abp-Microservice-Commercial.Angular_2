using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Tools
{
    public static class DataAccess
    {
        /// <summary>
        /// 填入所有預設資料
        /// </summary>
        /// <param name="row">Row</param>
        public static void SetRowDefaultValue(DataRow row)
        {
            Type t;
            foreach (DataColumn dc in row.Table.Columns)
            {
                t = dc.DataType;
                if (t == typeof(string)) row[dc] = "";
                if (t == typeof(bool)) row[dc] = false;
                if (t == typeof(int)) row[dc] = 0;
                if (t == typeof(decimal)) row[dc] = 0;
                if (t == typeof(double)) row[dc] = 0;
                if (t == typeof(DateTime)) row[dc] = DateTime.Now;
            }
        }

        /// <summary>
        /// 填入所有預設資料
        /// </summary>
        /// <param name="LinqObj">object</param>
        public static void SetRowDefaultValue(object LinqObj)
        {
            // get the properties of the LINQ Object        
            PropertyInfo[] props = LinqObj.GetType().GetProperties();

            // iterate through each property of the class
            foreach (PropertyInfo prop in props)
            {
                // attempt to discover any metadata relating to underlying data columns
                try
                {
                    // get any column attributes created by the linq designer
                    object[] customAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);

                    // if the property has an attribute letting us know that the underlying column data cannot be null
                    //if (((System.Data.Linq.Mapping.ColumnAttribute)(customAttributes[0])).DbType.ToLower().IndexOf("not null") != -1)
                    if (true)
                    {
                        // if the current property is null or Linq has set a date time to its default '01/01/0001 00:00:00'
                        //if (prop.GetValue(LinqObj, null) == null || prop.GetValue(LinqObj, null).ToString() == (new DateTime(1, 1, 1, 0, 0, 0)).ToString())
                        if (true)
                        {
                            // set the default values here : could re-query the database, but would be expensive so just use defaults coded here
                            switch (prop.PropertyType.ToString())
                            {
                                // System.String / NVarchar
                                case "System.String":
                                    prop.SetValue(LinqObj, string.Empty, null);
                                    break;
                                case "System.Boolean":
                                    prop.SetValue(LinqObj, false, null);
                                    break;
                                case "System.Nullable`1[System.Decimal]":
                                case "System.Decimal":
                                    prop.SetValue(LinqObj, 0M, null);
                                    break;
                                case "System.Nullable`1[System.Int32]":
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Int16":
                                    prop.SetValue(LinqObj, 0, null);
                                    break;
                                case "System.DateTime":
                                    prop.SetValue(LinqObj, DateTime.Now, null);
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    // could do something here ...
                }
            }
        }

        /// <summary>
        /// 資料複制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public static void CloneProperties<T>(this T origin, T destination)
        {
            // Instantiate if necessary
            if (destination == null) throw new ArgumentNullException("destination", "Destination object must first be instantiated.");
            // Loop through each property in the destination
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                // find and set val if we can find a matching property name and matching type in the origin with the origin's value
                if (origin != null && destinationProperty.CanWrite)
                {
                    origin.GetType().GetProperties().Where(x => x.CanRead && (x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType))
                        .ToList()
                        .ForEach(x => destinationProperty.SetValue(destination, x.GetValue(origin, null), null));
                }
            }
        }

        /// <summary>
        /// 資料複制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public static void CloneProperties<T>(this T origin, T destination ,List<string> ListIgnorePropertyName )
        {
            // Instantiate if necessary
            if (destination == null) throw new ArgumentNullException("destination", "Destination object must first be instantiated.");
            // Loop through each property in the destination
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                // find and set val if we can find a matching property name and matching type in the origin with the origin's value
                if (origin != null && destinationProperty.CanWrite)
                {
                    origin.GetType().GetProperties().Where(x => x.CanRead && (x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType))
                        .ToList()
                        .ForEach(x => destinationProperty.SetValue(destination, x.GetValue(origin, null), null));
                }
            }
        }

        /// <summary>
        /// 複制資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listToClone"></param>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// 設定物件某欄位的值
        /// </summary>
        /// <typeparam name="T">自訂型別</typeparam>
        /// <param name="o">物件來源</param>
        /// <param name="propertyName">屬性名稱</param>
        /// <param name="Value">值</param>
        /// <returns>自訂型別</returns>
        public static bool SetProperty(object o, string propertyName, string Value)
        {
            var Vdb = false;

            try
            {
                var theProperty = o.GetType().GetProperties().FirstOrDefault(p => p.Name == propertyName);
                if (theProperty != null)
                {

                    theProperty.SetValue(o, Convert.ChangeType(Value, theProperty.PropertyType), null);
                    Vdb = true;
                }
            }
            catch (Exception ex)
            {

            }

            return Vdb;
        }

        /// <summary>
        /// 取得物件某欄位的值
        /// </summary>
        /// <typeparam name="T">自訂型別</typeparam>
        /// <param name="o">物件來源</param>
        /// <param name="propertyName">屬性名稱</param>
        /// <returns>自訂型別</returns>
        public static T GetProperty<T>(object o, string propertyName)
        {
            var theProperty = o.GetType().GetProperties().FirstOrDefault(p => p.Name == propertyName);

            if (theProperty == null)
                return default(T);

            //if (theProperty.PropertyType.FullName != typeof(T).FullName)
            //    throw new ArgumentException("object has an Id property, but it is not of type " + typeof(T).FullName, "o");

            return (T)theProperty.GetValue(o, new object[] { });
        }

        public static string GetPropValue(object src, string propName)
        {
            var Value = "";

            try
            {
                Value = src.GetType().GetProperty(propName).GetValue(src, null).ToString();
            }
            catch { }

            return Value;
        }

        /// <summary>
        /// 轉成List
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static List<object> GetColumns(object row)
        {
            List<object> results = new List<object>();
            List<PropertyInfo> properties = (from x in row.GetType().GetProperties()
                                             where x.GetCustomAttributes(typeof(ColumnAttribute), false).Count() > 0
                                             where x.CanRead
                                             select x).ToList();
            foreach (PropertyInfo property in properties)
            {
                object val = property.GetGetMethod().Invoke(row, null);
                results.Add(val);
            }
            return results;
        }

        /// <summary>
        /// 複制資料
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void CopyPropertyValues(this object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();
            var sourceProperties = source.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destProperty in destProperties)
                {
                    object[] customAttributes = destProperty.GetCustomAttributes(typeof(ColumnAttribute), false);
                    if (customAttributes.Count() == 0) continue;

                    if (destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(source, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        public enum SortDirection
        {
            /// <summary>
            /// 正向
            /// </summary>
            Ascending,
            /// <summary>
            /// 反向
            /// </summary>
            Descending
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="descending"></param>
        /// <param name="anotherLevel"></param>
        /// <returns></returns>
        private static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string propertyName, SortDirection descending, bool anotherLevel = false)
        {
            var param = Expression.Parameter(typeof(T), string.Empty);
            var property = Expression.PropertyOrField(param, propertyName);
            var sort = Expression.Lambda(property, param);

            var call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") +
                (descending == SortDirection.Descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TSource"></typeparam>
        ///// <typeparam name="TValue"></typeparam>
        ///// <param name="source"></param>
        ///// <param name="selector"></param>
        ///// <param name="asc"></param>
        ///// <returns></returns>
        //public static IOrderedQueryable<TSource> OrderBy<TSource, TValue>(this IQueryable<TSource> source, Expression<Func<TSource, TValue>> selector, bool asc)
        //{
        //    return asc ? source.OrderBy(selector) : source.OrderByDescending(selector);
        //}
    }
}
