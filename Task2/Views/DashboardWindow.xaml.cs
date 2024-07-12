using System.Data.SqlClient;
using System.Windows;
using Task2.Models;

namespace Task2.Views;

public partial class DashboardWindow : Window
{
	#region Fields

	public List<Car>? Cars { get; set; }

	SqlConnection? SqlConnection { get; set; }

	SqlDataReader? SqlDataReader { get; set; }

	SqlCommand? SqlCommand { get; set; }

	public string ConnectionString { get; set; }

	#endregion

	public DashboardWindow()
	{
		InitializeComponent();

		DataContext = this;

		//	ConnectionString = App.Configuration!.GetConnectionString("DefaultConnection");
		ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=AppCars;Integrated Security=SSPI;";
		
		SqlConnection = new(ConnectionString);

		Cars = new();

		ListOfCars.ItemsSource = Cars;
	}

	private void SearchButtonExecute(object sender, RoutedEventArgs e)
	{
		string searchedSpec =
					((RadioBtnMarka.IsChecked!.Value) ? RadioBtnMarka.Content.ToString()! : RadioBtnModel.Content.ToString()!);

		if (string.IsNullOrEmpty(searchedSpec)) return;

		using (SqlConnection)
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
