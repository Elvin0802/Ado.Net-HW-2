using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Windows;
using Task2.Models;

namespace Task2.Views;

public partial class DashboardWindow : Window
{
	#region Fields

	public List<Car>? Cars { get; set; }

	public SqlConnection? SqlConnection { get; set; }

	public SqlDataReader? SqlDataReader { get; set; }

	public SqlCommand? SqlCommand { get; set; }

	public string ConnectionString { get; set; }

	#endregion

	public DashboardWindow()
	{
		InitializeComponent();

		DataContext = this;

		ConnectionString = App.Configuration!.GetConnectionString("DefaultConnection")!;

		Cars = new();

		ListOfCars.ItemsSource = Cars;
	}

	private void SearchButtonExecute(object sender, RoutedEventArgs e)
	{
		string searchedSpec =
					((RadioBtnMarka.IsChecked!.Value) ? RadioBtnMarka.Content.ToString()! : RadioBtnModel.Content.ToString()!);

		if (string.IsNullOrEmpty(searchedSpec))
		{
			MessageBox.Show("Please, enter a text.", "Message.");
			return;
		}

		using (SqlConnection = new(ConnectionString))
		{
			SqlConnection!.Open();

			string query = $@"
								USE [AppCars];

								SELECT *
								FROM [MainCars]
								WHERE [{searchedSpec}] LIKE ('%' + @searchText + '%')
							";

			SqlCommand = new(query, SqlConnection);

			SqlCommand.Parameters.Add("@searchText", System.Data.SqlDbType.NVarChar).Value = SearchText.Text;

			SqlDataReader = SqlCommand.ExecuteReader();

			Cars!.Clear();

			do
			{
				while (SqlDataReader.Read())
				{
					Cars!.Add(new Car(
									Convert.ToInt32(SqlDataReader["Id"].ToString()),
									SqlDataReader["Marka"].ToString(),
									SqlDataReader["Model"].ToString()));
				}
			}
			while (SqlDataReader.NextResult());
		}

		ListOfCars.Items.Refresh();
	}
}
