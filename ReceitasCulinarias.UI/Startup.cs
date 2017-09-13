using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization;
using ReceitasCulinarias.Entity;
using ReceitasCulinarias.Dal;

namespace ReceitasCulinarias.UI
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

			var context = new ReceitasCulinarias.Dal.MongoDBContext(
				Configuration.GetConnectionString("DefaultConnection"),
				Configuration.GetSection("DataBase").GetValue<string>("DbName"));

			services.AddSingleton<ReceitasCulinarias.Dal.MongoDBContext>(new ReceitasCulinarias.Dal.MongoDBContext(
				Configuration.GetConnectionString("DefaultConnection"),
				Configuration.GetSection("DataBase").GetValue<string>("DbName")));

			BsonClassMap.RegisterClassMap<TipoReceita>();
			BsonClassMap.RegisterClassMap<Receita>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
