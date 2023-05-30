using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hangfire_webapi
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
			string connectionString = Configuration.GetSection("ConnectionString").Value;
			services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
			services.AddHangfireServer();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			var supportedCultures = new string[] { "en-GB", "en-US"};
			app.UseRequestLocalization(options =>
						options
						.AddSupportedCultures(supportedCultures)
						.AddSupportedUICultures(supportedCultures)
						.SetDefaultCulture("en-US")
						.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
						{
							return Task.FromResult(new ProviderCultureResult("en-US"));
						}))
				);
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseHangfireDashboard();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
