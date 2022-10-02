using OBLIslamiPOApi.Model;
using OBLIslamiPOApi.ViewModels;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace OBLIslamiPOApi.Repository
{
    public class PopulateRecord : IPopulateRecord
    {
        #region PopulateRecord

        /// <summary>
        ///     Populate Record
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="entity"></param>
        /// <returns>result</returns>
        public virtual dynamic Populate(DbDataReader reader, string entity)
        {

            if (entity == "System36ViewModel")
            {
                return GetSystem36(reader);

            }
            if (entity == "POModel")
            {
                return GetPOData(reader);

            }


            return null;
        }

        public System36ViewModel GetSystem36(DbDataReader reader)
        {
            return new System36ViewModel
            {
                System36 = ColumnExists(reader, "system36") ? reader["system36"].ToString() : "",
                System36Net = ColumnExists(reader, "system36_net") ? reader["system36_net"].ToString() : "",
                App36Net = ColumnExists(reader, "app36_net") ? reader["app36_net"].ToString() : "",
                ReadWriteUser = ColumnExists(reader, "readWrite_User") ? reader["readWrite_User"].ToString() : "",
                DbType = ColumnExists(reader, "DBType") ? reader["DBType"].ToString() : ""
            };
        }

        public POModel GetPOData(DbDataReader reader)
        {
            return new POModel
            {
                PONumber = ColumnExists(reader, "PONumber") ? reader["PONumber"].ToString() : "",
                InFavorOf = ColumnExists(reader, "InFavorOf") ? reader["InFavorOf"].ToString() : "",
                Amount = ColumnExists(reader, "Amount") ? reader["Amount"].ToString() : "",
                Rate = ColumnExists(reader, "Rate") ? reader["Rate"].ToString() : "",
                Duration = ColumnExists(reader, "Duration") ? reader["Duration"].ToString() : "",
                OnAccountOf = ColumnExists(reader, "onAccountOf") ? reader["onAccountOf"].ToString() : "",
                Date = ColumnExists(reader, "Date") ? reader["Date"].ToString() : "",
                id = ColumnExists(reader, "id") ? ((reader["id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["id"])) : 0,
                MonthorYear = ColumnExists(reader, "MonthorYear") ? reader["MonthorYear"].ToString() : "",
            };
        }
        #endregion

        #region Column Exists

        /// <summary>
        ///     ColumnExists
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns>boolean value</returns>
        public bool ColumnExists(DbDataReader reader, string columnName)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public dynamic Populate(SqlDataReader reader, string entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}