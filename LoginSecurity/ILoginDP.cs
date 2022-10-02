using OBLIslamiPOApi.ViewModels;
using OBLIslamiPOApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBLIslamiPOApi.LoginSecurity
{
    public interface ILoginDP
    {
        Task<string> CheckCredential(string userCode, string password);
       
 
    }
}
