using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OddifenceCore.IO.World;
using OddifenceCore.World;

namespace OddifenceMapEditor;

public partial class MainWindow : Window
{
	public bool IsFileOpened
	{
		get;
		set
		{
			if (value)
				FileOpen();
			field = value;
		}
	}

	private void FileOpen()
	{
		Save.IsEnabled = true;
		SaveAs.IsEnabled = true;
	}

	private Map? _map;
	private string? _file;

	public MainWindow()
	{
		InitializeComponent();
	}

	private void OpenFile(object sender, RoutedEventArgs e)
	{
		var dlg = new Microsoft.Win32.OpenFileDialog
		{
			Filter = "Map file (.toml)|*.toml"
		};
		dlg.ShowDialog();
		if(!dlg.CheckFileExists) return;
		_file = dlg.FileName;
		_map = MapIO.LoadMap(_file);
	}

	public void NewFile(object sender, RoutedEventArgs e)
	{
		var dlg = new NewFile();
		dlg.ShowDialog();
		if (!dlg.CreateNewFile) return;
		IsFileOpened = true;
		_map = dlg.Map;
	}
}