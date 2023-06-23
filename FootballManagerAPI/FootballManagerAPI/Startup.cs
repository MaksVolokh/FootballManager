using FootballManagerAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using FootballManagerDAL.Interfaces;
using FootballManagerBLL.Interfaces;
using FootballManagerBLL.FootballManagerBLL;
using FootballManagerDAL.Repositories;
using Microsoft.AspNetCore.Identity;
using FootballManagerBLL.Dto;

namespace FootballManagerAPI
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FootballManagerAPI", Version = "v1" });

                c.UseInlineDefinitionsForEnums();
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayersRepository, PlayerRepository>();

            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<ICoachRepository, CoachRepository>();

            services.AddScoped<IFootballTeamService, FootballTeamService>();
            services.AddScoped<IFootballTeamRepository, FootballTeamRepository>();

            services.AddScoped<IStatisticsService, PlayerStatisticsService>();
            services.AddScoped<IFootballPlayerStatisticsRepository, FootballPlayerStatisticsRepository>();

            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IFootballMatchRepository, FootballMatchRepository>();

            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IMediaRepository,  MediaRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballManagerAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
