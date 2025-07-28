using System.ComponentModel;
using System.Windows;
using OddifenceCore.World;

namespace OddifenceMapEditor;

public partial class NewFile : Window
{
	public bool CreateNewFile {get; private set; }
	public NewFileViewModel Model;
	public Map Map { get; private set; }

	public NewFile()
	{
		InitializeComponent();
		DataContext = Model = new NewFileViewModel { ErrorInfo = "" };
	}

	private void ClickOk(object sender, RoutedEventArgs e)
	{
		ClearErrorInfo();
		var error = false;
		if (MapName.Text == "")
		{
			error = true;
			AddErrorInfo("Invalid map name");
		}

		// ReSharper disable CompareOfFloatsByEqualityOperator
		if ((int)SizeX.Value != SizeX.Value || (int)SizeY.Value != SizeY.Value)
			// ReSharper restore CompareOfFloatsByEqualityOperator
		{
			error = true;
			AddErrorInfo("Map size must be a integer");
		}
		if (error) return;
		CreateNewFile = true;
		Map = new Map((int)SizeX.Value,(int)SizeY.Value)
		{
			Name = MapName.Text
		};
		Close();
	}

	private void ClearErrorInfo()
	{
		Model.ErrorInfo = "";
	}

	private void AddErrorInfo(string info)
	{
		Model.ErrorInfo += info + Environment.NewLine;
	}

	private void ClickCancel(object sender, RoutedEventArgs e) => Close();
}

public class NewFileViewModel : INotifyPropertyChanged
{
	
	public event PropertyChangedEventHandler? PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	
	public required string ErrorInfo
	{
		get;
		set
		{
			field = value;
			OnPropertyChanged(nameof(ErrorInfo));
		}
	}
}