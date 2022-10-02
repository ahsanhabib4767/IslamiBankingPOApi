using OBLIslamiPOApi.ViewModels;
using OBLIslamiPOApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBLIslamiPOApi.DataOperations
{
    public interface ITransActionDP
    {
        Task<string[]> POData(POModel entity);
        Task<string[]> PODataPayOdr(POModel entity);
        Task<string[]> PODataMSSM(POModel objInstr);
        Task<string[]> PODataMMIDS(POModel objInstr);

        Task<List<POModel>> GetData();
        Task<List<POModel>> GetDataPayOdr();
        Task<List<POModel>> GetDataMSSM();

        Task<List<POModel>> GetDataMMIDS();

    }
}
