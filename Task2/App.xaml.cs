using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;
using Task2.Views;

namespace Task2;

public partial class App : Application
{
	public static IConfigurationRoot? Configuration;
	public static DashboardWindow? DashboardWindow { get; set; }

	private void StartApp(object sender, StartupEventArgs e)
	{
		Configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		DashboardWindow = new DashboardWindow();

		DashboardWindow.ShowDialog();
	}
}
