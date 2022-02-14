using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Data;
using SchoolApi.Helpers;
using SchoolApi.Services;
using System.Text;

namespace SchoolApi.Models
{
    public class StartupServiceConfiguration
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; set; }

        public void ConfigureServices()
        {
            Services.AddControllers();
            Services.AddTransient<UserService>();
            Services.AddTransient<ParentService>();
            Services.AddTransient<ChildService>();
            Services.AddTransient<SchoolService>();

            Services.AddDbContext<SchoolApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SchoolApiContext")));

            var AppSettingsSection = Configuration.GetSection("AppSettings");
            var AppSettings = AppSettingsSection.Get<AppSettings>();
            var Key = Encoding.ASCII.GetBytes(AppSettings.Secret);

            Services.AddAuthentication(x =>
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
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
