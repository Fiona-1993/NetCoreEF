using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMigration.dbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace EFCoreMigration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<EmployeeDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("sqlconn")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            //��Swagger��������ӵ����񼯺�
            services.AddSwaggerGen(c =>
            {
                //����ӿ��ĵ��ı��⡢�汾��������Ϣ
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFCoreMigration��Ŀ�Ľӿ��ĵ�", Version = "v1.0", Description = "�ýӿ��ĵ��ᱣ������ͬ��������ֱ���ڴ����ӿڵ���" });
                //���Ƽ�ʹ��ApiKeyScheme���ڰ汾5���ϣ��Ƽ�ʹ��OpenApiSecurityScheme
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                        //��������������
                        //Array.Empty<string>()
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // �˷���������ʱ���á�ʹ�ô˷���������HTTP����ܵ���
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //�����м����ʹ�м���ܹ������ɵ�Swagger��ΪJSON URL�ṩ����
            app.UseSwagger();

            //ʹ�м���ܹ�������swagger ui��HTML��JS��CSS�ȣ�
            app.UseSwaggerUI(c =>
            {
                //ָ��Swagger JSON�ļ���URL
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //ָ��Swagger JSON�ļ���URL��Ҳ����˵������Ӷ���汾
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
