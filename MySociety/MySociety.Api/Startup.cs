namespace MySociety.Api
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MySociety.Bussines.Contribute;
    using MySociety.Bussines.Contribute.Interface;
    using MySociety.Bussines.Reason;
    using MySociety.Bussines.Report;
    using MySociety.Bussines.Society;
    using MySociety.Bussines.Society.Interface;
    using MySociety.Bussines.User;
    using MySociety.Bussines.User.Interface;
    using MySociety.Repository;
    using MySociety.Utilities;
    using MySociety.Utilities.Storage;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationSection dataBaseconfiguration = this.Configuration.GetSection("DatabaseConfiguration");
            IConfigurationSection storageConfiguration = this.Configuration.GetSection("StorageConfiguration");

            services.Configure<DatabaseConfiguration>(dataBaseconfiguration);
            services.Configure<StorageConfiguration>(storageConfiguration);

            services.AddSingleton<IRepositoryService>(InitializeCosmosClientInstance(dataBaseconfiguration));

            services.AddSingleton<IStorageUtilities>(InitializeStorageUtilities(storageConfiguration));
            services.AddSingleton<IContributeBussines, ContributeBussines>();
            services.AddSingleton<IScoreBussines, ScoreBussines>();
            services.AddSingleton<ISocietyBussines, SocietyBussines>();
            services.AddSingleton<IUserBussines, UserBussines>();
            services.AddSingleton<ICommentBussines, CommentBussines>();
            services.AddSingleton<IReasonBussines, ReasonBussines>();
            services.AddSingleton<IReportBussines, ReportBussines>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddApplicationInsightsTelemetry();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static StorageUtilities InitializeStorageUtilities(IConfiguration configurationSection)
        {
            StorageConfiguration storageConfiguration = configurationSection.Get<StorageConfiguration>();
            return new StorageUtilities(storageConfiguration);
        }

        private static MongoDbRepositoryService InitializeCosmosClientInstance(IConfiguration configurationSection)
        {
            DatabaseConfiguration dataBaseConfiguration = configurationSection.Get<DatabaseConfiguration>();

            DocumentClient dataBaseContext = new DocumentClient(new Uri(dataBaseConfiguration.EndPointUrl), dataBaseConfiguration.Key);

            return new MongoDbRepositoryService(dataBaseContext, dataBaseConfiguration);
        }
    }
}
