namespace Task2.Models;
public class Car
{
	#region Private Fields

	private int? _id;
	private string? _marka;
	private string? _model;

	#endregion

	#region Properties

	public int? Id { get => _id; set => _id = value; }
	public string? Marka { get => _marka; set => _marka = value; }
	public string? Model { get => _model; set => _model = value; }

	#endregion

	public Car() { }

	public Car(int id, string? marka, string? model)
	{
		Id = id;
		Marka = marka;
		Model = model;
	}

	public override string ToString() => $"{Marka} {Model}";

}