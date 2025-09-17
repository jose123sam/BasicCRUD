using BasicCRUD.Model;
using System.Windows.Input;

namespace BasicCRUD.ViewModel;

internal class PhoneCRUDViewModel : ViewModelBase
{
	PhoneCRUDModel model = new();

	private int ramSize;

	public int RamSize
	{
		get => model.RamSize;
		set {
			model.RamSize = value;
			OnPropertyChanged(nameof(RamSize));
		}
	}

	private string manufacturer = string.Empty;

	public string Manufacturer
    {
		get => model.Manufacturer;
		set {
			model.Manufacturer = value;
			OnPropertyChanged(nameof(Manufacturer));
		}
	}

	public ICommand RegisterCommand { get; set; }

    public PhoneCRUDViewModel()
    {
		RegisterCommand = new RelayCommand(Register, CanRegisterExecute);
    }

    private bool CanRegisterExecute(object obj)
    {
		return true;
    }

    private void Register(object obj)
    {
        // Create.
    }
}
