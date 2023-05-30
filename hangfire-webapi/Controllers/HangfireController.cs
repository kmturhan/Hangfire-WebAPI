using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;

namespace hangfire_webapi.Controllers
{
	public class HangfireController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return Ok("test");
		}

		//Fire and forget jobs
		[HttpPost]
		[Route("[action]")]
		public IActionResult Welcome()
		{
			var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
			return Ok($"Jod ID: {jobId} Welcome email sent to the user!");
		}

		//Delayed jobs
		[HttpPost]
		[Route("[action]")]
		public IActionResult Discount()
		{
			int timeInSeconds = 30;
			var jobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Welcome to our app"), TimeSpan.FromSeconds(timeInSeconds));
			return Ok($"Jod ID: {jobId} Discount email will be sent in {timeInSeconds} seconds!");
		}

		//Recurring jobs
		[HttpPost]
		[Route("[action]")]
		public IActionResult DatabaseUpdate()
		{
			RecurringJob.AddOrUpdate(() => Console.WriteLine("Database updated"), Cron.Minutely);
			return Ok("Database check job initiated!");
		}

		//Continious jobs
		[HttpPost]
		[Route("[action]")]
		public IActionResult Confirm()
		{
			int timeInSeconds = 30;
			var parentJobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Unsubscribe"), TimeSpan.FromSeconds(timeInSeconds));
			BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("You were unsbscribed!"));

			return Ok($"Confirmation job created.");
		}
		[HttpPost]
		[Route("[action]")]
		public void SendWelcomeEmail(string text)
		{
			Console.WriteLine(text);
		}
	}
}
