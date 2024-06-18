
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace JWTTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ConfigService>();
            //添加JWT身份验证服务
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,//是否效验Issuer 
                            ValidateAudience = true,//是否效验Audience
                            ValidateLifetime = true,//是否验证失效时间
                            ValidateIssuerSigningKey = true,//是否效验SigningKey
                            ValidIssuer = TokenParameter.Issuer,//颁发者
                            ValidAudience = TokenParameter.Audience,//接收者 
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenParameter.Secret))
                        };
                    });

            //配置Swagger身份验证输入（可选）
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "请输入token,格式为 【Bearer JWT字符串】（注意中间必须有空格）",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                //添加安全要求
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme{
                Reference =new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id ="Bearer"
                }
            },new string[]{ }
        }
    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // 使用认证和授权中间件
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            var configService = app.Services.GetRequiredService<ConfigService>();
            app.Run();


        }
    }
}
