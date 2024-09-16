namespace MyWebAPI.Service
{
    public class EntitiesConn
    {
        /// <summary>
        /// 讀取資料庫連接設定
        /// </summary>
        /// <returns></returns>
        private string? connString()
        {
            string? connectionString = "";
            try
            {
                var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");
                var config = builder.Build();
                connectionString = config.GetConnectionString("DefaultConnection");
            }
            catch
            {
                connectionString = "";
            }
            return connectionString;
        }
    }
}
