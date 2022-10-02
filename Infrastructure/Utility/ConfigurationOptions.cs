
namespace OBLIslamiPOApi.Infrastructure.Utility
{
    public class ConfigurationOptions
    {
        public string DbServerIpOrName { get; set; }
        public string DbName { get; set; }

        public string Provider { get; set; }
    

       
        public int TokenExpiration { get; set; }

       
    }
}