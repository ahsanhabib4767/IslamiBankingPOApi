using OBLIslamiPOApi.Repository;
using OBLIslamiPOApi.ViewModels;

using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using OBLIslamiPOApi.Model;


namespace OBLIslamiPOApi.UnitOfWorks
{
    public interface IUnitOfWork
    {
        
        IRepository<System36ViewModel> TblSystem36Repository { get; }
        
        IRepository<LoginModel> TblLoginModelRepository { get; }

        IRepository<POModel> TblPODataRepository { get; }
        

        Task<DbTransaction> SetDbTransaction();
        IDbCommand DbStoredProcedure(string strSpName);
        IDbCommand AddInParameter(IDbCommand dbCommand, string strParamName, DbType strDbType, int dbSize,dynamic strParamValue);
        IDbCommand AddOutParameter(IDbCommand dbCommand, string strParamName, DbType strDbType, int dbSize,dynamic strParamValue);
        Task<string> GetPassword(string pass);
        IEnumerable<System36ViewModel> GetAllExecuteText(string strText, string strCon);
    }
}