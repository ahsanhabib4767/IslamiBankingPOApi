using OBLIslamiPOApi.Controllers;
using OBLIslamiPOApi.Infrastructure.Utility;
using OBLIslamiPOApi.UnitOfWorks;
using OBLIslamiPOApi.ViewModels;
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

using OBLIslamiPOApi.DataOperations;

namespace OBLIslamiPOApi.DataOperations
{   
    public class TransAction : BaseController, ITransActionDP
    {
        public TransAction(IUnitOfWork uow,IOptions<ConfigurationOptions> options)
        {
           
            Uow = uow;
           
            Options = options;
        }


        //public async Task<dynamic> POData(POModel entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            return retJsonMsg("-1", "Invalid Request Data", "0", "0");


        //        }
        //        return retJsonMsg("-1", "Invalid Account No", "0", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        return retJsonMsg("-1", ex.Message, "0", "0");
        //    }
        //}

        public static object CheckWhiteSpaceAndSpecilChar(object obj)
        {
            try
            {
                Regex rgq = new Regex(@"[~`!@#$%^&*()+=|\{}':;.,<>/?[\]""_-]");
                // var specialCharVal =ConfigurationSettings.AppSettings["SpecialCharactersNotAllowed"].ToString();

                if (obj == null) return null;
                var objValue = obj.ToString().Trim();
                //if (rgq.IsMatch(objValue))
                // {
                //    throw new Exception("Special Chareacters () are not allowed in RTGS");
                //    // return false;
                // }
                // else
                // {
                //     return true;
                // }
                return string.IsNullOrEmpty(objValue) ? null : objValue;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public async Task<dynamic> ApiRequestLog(string postParam, string channelId, string uniqueId, string error_code, string reqMethod)
        //{
        //    string[] messages = new string[2];
        //    var mgs = "";
        //    var dbCmd = Uow.DbStoredProcedure("sp_ins_api_log");
        //    try
        //    {

        //        Uow.AddInParameter(dbCmd, "@ReqMsg", DbType.String, 5000, postParam);
        //        Uow.AddInParameter(dbCmd, "@ChannelId", DbType.String, 5, channelId);
        //        Uow.AddInParameter(dbCmd, "@UniqueId", DbType.String, 30, uniqueId);
        //        Uow.AddInParameter(dbCmd, "@reqMethod", DbType.String, 40, reqMethod);
        //        Uow.AddInParameter(dbCmd, "@Error_code", DbType.String, 10, error_code);
        //        Uow.AddOutParameter(dbCmd, "@msg", DbType.String, 200, "");
        //        Uow.AddOutParameter(dbCmd, "@msg_code", DbType.String, 5, "");
        //        var result = await Uow.TblATypeCodeEntityRepository.ExecuteStoredProc(dbCmd);
        //        var cmd = (DbCommand)dbCmd;
        //        messages[0] = cmd.Parameters["@msg_code"].Value.ToString();
        //        messages[1] = cmd.Parameters["@msg"].Value.ToString();
        //        if (messages[0] == "01")
        //        {
        //            mgs = messages[1];
        //        }
        //        else if (messages[0] == "02")
        //        {
        //            mgs = messages[1];
        //        }
        //        else if (messages[0] == "03")
        //        {
        //            mgs = messages[1];
        //        }
        //        return mgs;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private dynamic retJsonMsg(string msgCode, string msg, string rtgsRefNo, string trnNo)
        {
            return new
            {
                Msg_Code = msgCode,
                Msg = msg,
                RTGS_Ref_No = rtgsRefNo,
                Transaction_No = trnNo
            };
        }
        //MTDR_Cheque
        public async Task<string[]> POData(POModel objInstr)
        {
            string[] messages = new string[3];
           
            try
            {

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataINsert");

                try
                {
                    //In
                    Uow.AddInParameter(dbCommand, "PONumber", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.PONumber));
                    Uow.AddInParameter(dbCommand, "InFavorOf", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.InFavorOf));
                    Uow.AddInParameter(dbCommand, "onAmmount", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.OnAccountOf));
                    Uow.AddInParameter(dbCommand, "Date", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Date));
                    Uow.AddInParameter(dbCommand, "Amount", DbType.String, 30, CheckWhiteSpaceAndSpecilChar(objInstr.Amount));
                    // Uow.AddInParameter(dbCommand, "Month", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Month));
                    Uow.AddInParameter(dbCommand, "MatureDate", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.MatureDate));
                    Uow.AddInParameter(dbCommand, "MonthorYear", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.MonthorYear));


                    Uow.AddInParameter(dbCommand, "Rate", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Rate));
                    Uow.AddInParameter(dbCommand, "Duration", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Duration));


                    ////////Out/////////
                    Uow.AddOutParameter(dbCommand, "Vmsg_code", DbType.String, 5, "");
                    Uow.AddOutParameter(dbCommand, "VMSG", DbType.String, 200, "");
                    Uow.AddOutParameter(dbCommand, "ID", DbType.Int32, 100, "");

                    await Uow.TblPODataRepository.ExecuteStoredProc(dbCommand);
                    var cmd = (DbCommand)dbCommand;

                    messages[0] = cmd.Parameters["VMSG"].Value.ToString();
                    messages[1] = cmd.Parameters["Vmsg_code"].Value.ToString();
                    messages[2] = cmd.Parameters["ID"].Value.ToString();

                    return messages;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Payment_Order_Cheque
        public async Task<string[]> PODataPayOdr(POModel objInstr)
        {
            string[] messages = new string[3];

            try
            {

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataINsertPayOdr");

                try
                {
                    //In
                    Uow.AddInParameter(dbCommand, "PONumber", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.PONumber));
                    Uow.AddInParameter(dbCommand, "InFavorOf", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.InFavorOf));
                    Uow.AddInParameter(dbCommand, "onAmmount", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.OnAccountOf));
                    Uow.AddInParameter(dbCommand, "Date", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Date));
                    Uow.AddInParameter(dbCommand, "Amount", DbType.String, 30, CheckWhiteSpaceAndSpecilChar(objInstr.Amount)); 
                    ////////Out/////////
                    Uow.AddOutParameter(dbCommand, "Vmsg_code", DbType.String, 5, "");
                    Uow.AddOutParameter(dbCommand, "VMSG", DbType.String, 200, "");
                    Uow.AddOutParameter(dbCommand, "ID", DbType.Int32, 100, "");

                    await Uow.TblPODataRepository.ExecuteStoredProc(dbCommand);
                    var cmd = (DbCommand)dbCommand;

                    messages[0] = cmd.Parameters["VMSG"].Value.ToString();
                    messages[1] = cmd.Parameters["Vmsg_code"].Value.ToString();
                    messages[2] = cmd.Parameters["ID"].Value.ToString();

                    return messages;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //MSSM_Cheque
        public async Task<string[]> PODataMSSM(POModel objInstr)
        {
            string[] messages = new string[3];

            try
            {

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataINsertMSSM");

                try
                {
                    //In
                    Uow.AddInParameter(dbCommand, "PONumber", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.PONumber));
                    //Uow.AddInParameter(dbCommand, "InFavorOf", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.InFavorOf));
                    Uow.AddInParameter(dbCommand, "onAmmount", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.OnAccountOf));
                    Uow.AddInParameter(dbCommand, "Date", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Date));
                    Uow.AddInParameter(dbCommand, "Amount", DbType.String, 30, CheckWhiteSpaceAndSpecilChar(objInstr.Amount));
                   
                    Uow.AddInParameter(dbCommand, "Rate", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Rate));
                    Uow.AddInParameter(dbCommand, "Duration", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Duration));
                    Uow.AddInParameter(dbCommand, "MatureDate", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.MatureDate));


                    ////////Out/////////
                    Uow.AddOutParameter(dbCommand, "Vmsg_code", DbType.String, 5, "");
                    Uow.AddOutParameter(dbCommand, "VMSG", DbType.String, 200, "");
                    Uow.AddOutParameter(dbCommand, "ID", DbType.Int32, 100, "");

                    await Uow.TblPODataRepository.ExecuteStoredProc(dbCommand);
                    var cmd = (DbCommand)dbCommand;

                    messages[0] = cmd.Parameters["VMSG"].Value.ToString();
                    messages[1] = cmd.Parameters["Vmsg_code"].Value.ToString();
                    messages[2] = cmd.Parameters["ID"].Value.ToString();

                    return messages;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //MMIDS_Cheque
        public async Task<string[]> PODataMMIDS(POModel objInstr)
        {
            string[] messages = new string[3];

            try
            {

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataINsertMMIDS");

                try
                {
                    //In
                    Uow.AddInParameter(dbCommand, "PONumber", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.PONumber));
                    Uow.AddInParameter(dbCommand, "InFavorOf", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.InFavorOf));
                    Uow.AddInParameter(dbCommand, "onAmmount", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.OnAccountOf));
                    Uow.AddInParameter(dbCommand, "Date", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Date));
                    Uow.AddInParameter(dbCommand, "Amount", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Amount));

                    Uow.AddInParameter(dbCommand, "Rate", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Rate));
                    Uow.AddInParameter(dbCommand, "Duration", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Duration));
                    Uow.AddInParameter(dbCommand, "MatureDate", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.MatureDate));


                    ////////Out/////////
                    Uow.AddOutParameter(dbCommand, "Vmsg_code", DbType.String, 5, "");
                    Uow.AddOutParameter(dbCommand, "VMSG", DbType.String, 200, "");
                    Uow.AddOutParameter(dbCommand, "ID", DbType.Int32, 100, "");

                    await Uow.TblPODataRepository.ExecuteStoredProc(dbCommand);
                    var cmd = (DbCommand)dbCommand;

                    messages[0] = cmd.Parameters["VMSG"].Value.ToString();
                    messages[1] = cmd.Parameters["Vmsg_code"].Value.ToString();
                    messages[2] = cmd.Parameters["ID"].Value.ToString();

                    return messages;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string[]> PODataUpdate(POModel objInstr)
        {
            string[] messages = new string[2];

            try
            {

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataINsert");

                try
                {
                    //In

                    Uow.AddInParameter(dbCommand, "id", DbType.Int32, 25, CheckWhiteSpaceAndSpecilChar(objInstr.id));
                    Uow.AddInParameter(dbCommand, "PONumber", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.PONumber));
                    Uow.AddInParameter(dbCommand, "InFavorOf", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.InFavorOf));
                    Uow.AddInParameter(dbCommand, "onAmmount", DbType.String, 50, CheckWhiteSpaceAndSpecilChar(objInstr.OnAccountOf));
                    Uow.AddInParameter(dbCommand, "Date", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Date));
                    Uow.AddInParameter(dbCommand, "Amount", DbType.String, 25, CheckWhiteSpaceAndSpecilChar(objInstr.Amount));



                    ////////Out/////////
                    Uow.AddOutParameter(dbCommand, "Vmsg_code", DbType.String, 5, "");
                    Uow.AddOutParameter(dbCommand, "VMSG", DbType.String, 200, "");

                    await Uow.TblPODataRepository.ExecuteStoredProc(dbCommand);
                    var cmd = (DbCommand)dbCommand;

                    messages[0] = cmd.Parameters["VMSG"].Value.ToString();
                    messages[1] = cmd.Parameters["Vmsg_code"].Value.ToString();

                    return messages;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<POModel>> GetData()
        {
            try
            {
                //var dt = _dbContext.GenerateDataTable("exec sp_GetRTGS_AtypeCode");
                
                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataGet");
                var res = (List<POModel>)await Uow.TblPODataRepository.GetAllExecuteStoredProc(dbCommand);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<POModel>> GetDataMSSM()
        {
            try
            {
                //var dt = _dbContext.GenerateDataTable("exec sp_GetRTGS_AtypeCode");

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataGetMSSM");
                var res = (List<POModel>)await Uow.TblPODataRepository.GetAllExecuteStoredProc(dbCommand);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<POModel>> GetDataMMIDS()
        {
            try
            {
                //var dt = _dbContext.GenerateDataTable("exec sp_GetRTGS_AtypeCode");

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataGetMMIDS");
                var res = (List<POModel>)await Uow.TblPODataRepository.GetAllExecuteStoredProc(dbCommand);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<POModel>> GetDataPayOdr()
        {
            try
            {
                //var dt = _dbContext.GenerateDataTable("exec sp_GetRTGS_AtypeCode");

                var dbCommand = Uow.DbStoredProcedure("spPOElementsDataGetPaymentOdr");
                var res = (List<POModel>)await Uow.TblPODataRepository.GetAllExecuteStoredProc(dbCommand);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
