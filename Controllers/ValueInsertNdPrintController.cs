using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OBLIslamiPOApi.DataOperations;
using OBLIslamiPOApi.Infrastructure.Utility;
using OBLIslamiPOApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBLIslamiPOApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ValueInsertNdPrintController : BaseController
    {
        public ValueInsertNdPrintController(ITransActionDP tDp, IOptions<ConfigurationOptions> options)
        {
            TDp = tDp;
            Options = options;
        }
        [Authorize]
        [Route("DataInsertPO")]
        [HttpPost]
        
        //Ahsan_2021
        //Mudaraba_Super_saving_Scheme_Cheque
        public async Task<dynamic> DataInsertPO([FromBody] POModel data)
        {
            try
            {
              var message =  await TDp.POData(data);
             return retJsonMsg(message[1].ToString(), message[0].ToString(),Convert.ToInt32(message[2].ToString()));

            }
            catch (FormatException fx)
            {
                var rslt = new
                {
                    MsgCode = "-1",
                    Msg = "Invalid Operations",
                    
                };
                return rslt;
            }
            catch (Exception ex)
            {
                var rslt = new
                {
                    MsgCode = "Err",
                    Msg = "Invalid transaction",
                    
                };
                //var reqData = JsonConvert.SerializeObject(postParam);

                return rslt;
            }
        }
        //MTDR_Cheque
        [Authorize]
        [Route("DataInsertPaymentOdr")]
        [HttpPost]

        //Ahsan_2021
        public async Task<dynamic> DataInsertPaymentOdr([FromBody] POModel data)
        {
            try
            {
                var message = await TDp.PODataPayOdr(data);
                return retJsonMsg(message[1].ToString(), message[0].ToString(), Convert.ToInt32(message[2].ToString()));

            }
            catch (FormatException fx)
            {
                var rslt = new
                {
                    MsgCode = "-1",
                    Msg = "Invalid Operations",

                };
                return rslt;
            }
            catch (Exception ex)
            {
                var rslt = new
                {
                    MsgCode = "Err",
                    Msg = "Invalid transaction",

                };
                //var reqData = JsonConvert.SerializeObject(postParam);

                return rslt;
            }
        }

        //Mudaraba_Super_saving_Scheme_Cheque(MSSM)
        [Authorize]
        [Route("DataInsertMSSM")]
        [HttpPost]
        public async Task<dynamic> DataInsertMSSM([FromBody] POModel data)
        {
            try
            {
                var message = await TDp.PODataMSSM(data);
                return retJsonMsg(message[1].ToString(), message[0].ToString(), Convert.ToInt32(message[2].ToString()));

            }
            catch (FormatException fx)
            {
                var rslt = new
                {
                    MsgCode = "-1",
                    Msg = "Invalid Operations",

                };
                return rslt;
            }
            catch (Exception ex)
            {
                var rslt = new
                {
                    MsgCode = "Err",
                    Msg = "Invalid transaction",

                };
                //var reqData = JsonConvert.SerializeObject(postParam);

                return rslt;
            }
        }
        //Mudaraba_Monthly_Income_Deposit_Scheme(MMIDS)
        [Authorize]
        [Route("DataInsertMMIDS")]
        [HttpPost]
        public async Task<dynamic> DataInsertMMIDS([FromBody] POModel data)
        {
            try
            {
                var message = await TDp.PODataMMIDS(data);
                return retJsonMsg(message[1].ToString(), message[0].ToString(), Convert.ToInt32(message[2].ToString()));

            }
            catch (FormatException fx)
            {
                var rslt = new
                {
                    MsgCode = "-1",
                    Msg = "Invalid Operations",

                };
                return rslt;
            }
            catch (Exception ex)
            {
                var rslt = new
                {
                    MsgCode = "Err",
                    Msg = "Invalid transaction",

                };
                //var reqData = JsonConvert.SerializeObject(postParam);

                return rslt;
            }
        }
        [Route("GetDataPO")]
        [HttpGet]
        //Ahsan_2021
        public async Task<List<POModel>> GetData()
        {
            try
            {
                return await TDp.GetData();


            }
           
            catch (Exception ex)
            {
                return await TDp.GetData();
            }
        }


        //[Route("DataUpdatePO")]
        //[HttpPost]
        ////Ahsan_2021
        //public async Task<dynamic> DataUpdatePO([FromBody] POModel data)
        //{
        //    try
        //    {
        //        var message =  await TDp.PODataUpdate(data);
        //        return retJsonMsg(message[1].ToString(), message[0].ToString());

        //    }
        //    catch (FormatException fx)
        //    {
        //        var rslt = new
        //        {
        //            MsgCode = "-1",
        //            Msg = "Invalid Operations",

        //        };
        //        return rslt;
        //    }
        //    catch (Exception ex)
        //    {
        //        var rslt = new
        //        {
        //            MsgCode = "Err",
        //            Msg = "Invalid transaction",

        //        };
        //        //var reqData = JsonConvert.SerializeObject(postParam);

        //        return rslt;
        //    }
        //}

        [Route("GetDataMSSM")]
        [HttpGet]
        //Ahsan_2021
        public async Task<List<POModel>> GetDataMSSM()
        {
            try
            {
                return await TDp.GetDataMSSM();


            }

            catch (Exception ex)
            {
                return await TDp.GetDataMSSM();
            }
        }

        [Route("GetDataPayOrder")]
        [HttpGet]
        //Ahsan_2021
        public async Task<List<POModel>> GetDataPayOrder()
        {
            try
            {
                return await TDp.GetDataPayOdr();


            }

            catch (Exception ex)
            {
                return await TDp.GetDataMSSM();
            }
        }

        [Route("GetDataMMIDS")]
        [HttpGet]
        //Ahsan_2021
        public async Task<List<POModel>> GetDataMMIDS()
        {
            try
            {
                return await TDp.GetDataMMIDS();


            }

            catch (Exception ex)
            {
                return await TDp.GetDataMMIDS();
            }
        }
        private dynamic retJsonMsg(string msgCode, string msg,int id)
        {
            return new
            {
                Msg_Code = msgCode,
                Msg = msg,
                ID= id
            };
        }

    }
}
