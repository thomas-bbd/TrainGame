using TrainGame.Controllers.Config;
using TrainGame.Domain.Services;
using TrainGame.Domain.Repository;
using TrainGame.Services;
using TrainGame.Persistence.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrainGame
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                // Adds a custom error response factory when ModelState is invalid
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
            });
            services.AddCognitoIdentity();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options => 
                {
                    options.Authority = Configuration["AWSCognito:Authority"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["AWSCognito:Authority"],
                        ValidateAudience = false
                    };
                }
            );
            
            services.AddSingleton<ITrainRepository, TrainRepository>();

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IObjectRepository, ObjectRepository>();
            services.AddSingleton<ITrainService, TrainService>();
            services.AddSingleton<IObjectService, ObjectService>();
            services.AddSingleton<IOptionRepository, OptionRepository>();
            services.AddSingleton<IRandomGeneratorService, RandomGeneratorService>();
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<IQuestionService, QuestionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
