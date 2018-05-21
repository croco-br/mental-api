﻿using Croco.Mental.Business;
using Croco.Mental.Business.Interfaces;
using Croco.Mental.Domain.Models;
using Croco.Mental.Repository;
using Croco.Mental.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Croco.Mental.API
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
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Mental API", Version = "v1" });
            });

            //business
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IQuestionnaireBusiness, QuestionnaireBusiness>();
            services.AddTransient<IManagementBusiness, ManagementBusiness>();

            //repositories
            services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IManagementRepository, ManagementRepository>();

            //Engines
            services.AddTransient<IRecommendationEngine, RecommendationEngine>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mental API V1");
            });

            app.UseMvc();
        }


    }
}
