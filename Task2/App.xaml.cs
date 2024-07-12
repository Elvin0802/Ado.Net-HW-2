using Microsoft.Extensions.Configuration;
using System.Windows;
using Task2.Views;

namespace Task2;

public partial class App : Application
{
	public static IConfigurationRoot? Configuration;
	public static DashboardWindow? DashboardWindow { get; set; }

	private void StartApp(object sender, StartupEventArgs e)
	{
		DashboardWindow = new DashboardWindow();

		Configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

		DashboardWindow.ShowDialog();
	}
}
