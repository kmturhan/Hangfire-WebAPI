using System;

namespace hangfire_webapi
{
	public class WeatherForecast
	{
		public DateTime Date { get; set; }
		private int _TemperatureC;
		public int TemperatureC
		{
			get
			{
				return _TemperatureC;
			}
			set
			{
				_TemperatureC = value;
			}
		}

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}
}
