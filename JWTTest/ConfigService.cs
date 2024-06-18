namespace JWTTest
{
    public class ConfigService
    {
        private readonly IConfiguration _configuration;
        private static JwtSettings _jwtSettings;

        public ConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
            LoadAppSettings();
        }

        private void LoadAppSettings()
        {
            // 绑定配置节到AppSettings类的实例
            _jwtSettings = new JwtSettings();
            _configuration.GetSection("JwtSettings").Bind(_jwtSettings);
        }

       public static JwtSettings JwtSettings=>_jwtSettings;

        // 可以添加更多获取配置的方法
    }
}
