using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLogin.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MySqlConnector;

namespace ApiLogin
{
    public class Startup
    {
        string mySqlConnection;
        public static IConfiguration Configuration2;

        public static String GetStringMySqlConnection()
        {
            return Configuration2.GetConnectionString("MySqlDbConnection"); 
        }
        //public static IConfiguration Configuration2 { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration2 = configuration; //aldriano
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Definir "string de conexão", irar busca do arquivo appsettings.json a
            //propriedade (nome) DefaultConnection
            mySqlConnection = Configuration.GetConnectionString("MySqlDbConnection");

            //Definir ao serviço usando o servidor Pomelo (options.UseMySql)
            services.AddDbContextPool<AppDbContext>(options =>
            options.UseMySql(mySqlConnection,
            ServerVersion.AutoDetect(mySqlConnection)));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiLogin", Version = "v1" });
            });

            //Implementado Autenticação com token
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiLogin v1"));
            }

            // global cors policy
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
             //   .AllowAnyMethod()
             //   .AllowAnyHeader());

            app.UseRouting();
            app.UseAuthentication(); //para autenticação com token
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
