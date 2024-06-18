
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
            //���JWT�����֤����
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,//�Ƿ�Ч��Issuer 
                            ValidateAudience = true,//�Ƿ�Ч��Audience
                            ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                            ValidateIssuerSigningKey = true,//�Ƿ�Ч��SigningKey
                            ValidIssuer = TokenParameter.Issuer,//�䷢��
                            ValidAudience = TokenParameter.Audience,//������ 
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenParameter.Secret))
                        };
                    });

            //����Swagger�����֤���루��ѡ��
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "������token,��ʽΪ ��Bearer JWT�ַ�������ע���м�����пո�",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                //��Ӱ�ȫҪ��
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
            // ʹ����֤����Ȩ�м��
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            var configService = app.Services.GetRequiredService<ConfigService>();
            app.Run();


        }
    }
}
