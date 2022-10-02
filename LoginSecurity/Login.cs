using OBLIslamiPOApi.Controllers;
using OBLIslamiPOApi.Infrastructure.Utility;
using OBLIslamiPOApi.UnitOfWorks;
using Microsoft.Extensions.Options;
using OBLIslamiPOApi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OBLIslamiPOApi.ViewModels;

namespace OBLIslamiPOApi.LoginSecurity
{
    public class Login : BaseController, ILoginDP
    {
        public Login(IUnitOfWork uow, IOptions<ConfigurationOptions> options)
        {
           
            Uow = uow;
            
            Options = options;
        }
        //Ahsan_2020
        public async Task<string> CheckCredential(string userCode, string password)
        {
            string selectQuery = "select UserName,Password from Parameter_Cridential  where UserName='" + userCode + "' and Password='" + password + "' ";
            try
            {
                var res =  await Uow.TblLoginModelRepository.GetResultByExecuteText(selectQuery);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

    }
}
