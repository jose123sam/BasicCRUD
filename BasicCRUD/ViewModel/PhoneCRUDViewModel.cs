using BasicCRUD.DataBaseFolder;
using BasicCRUD.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;

namespace BasicCRUD.ViewModel;

internal class PhoneCRUDViewModel : ViewModelBase
{
	PhoneCRUDModel model = new();
	PhoneRepository phoneRepository = new();

	public int RamSize
	{
		get => model.RamSize;
		set {
			model.RamSize = value;
			OnPropertyChanged(nameof(RamSize));
		}
	}

	public string Manufacturer
    {
		get => model.Manufacturer;
		set {
			model.Manufacturer = value;
			OnPropertyChanged(nameof(Manufacturer));
		}
	}

	private ObservableCollection<PhoneCRUDModel> savedPhoneDetails;

	public ObservableCollection<PhoneCRUDModel> SavedPhoneDetails
	{
		get { return savedPhoneDetails; }
		set {
			savedPhoneDetails = value;
			OnPropertyChanged(nameof(SavedPhoneDetails));
        }
    }

	public ICommand RegisterCommand { get; set; }
	public ICommand DeleteCommand { get; set; }

	private PhoneCRUDModel selectedEntry;

	public PhoneCRUDModel SelectedEntry
	{
		get { return selectedEntry; }
		set { 
			selectedEntry = value; 
		}
	}

	public PhoneCRUDViewModel()
    {
		RegisterCommand = new RelayCommand(Register, CanRegisterExecute);
        DeleteCommand = new RelayCommand(Delete, CanDeleteExecute);
		SavedPhoneDetails = new ObservableCollection<PhoneCRUDModel>();
    }

    private void Delete(object obj)
    {
		if(SelectedEntry is not null)
        {
            phoneRepository.DeleteEntry(SelectedEntry.Manufacturer, SelectedEntry.RamSize);
            DisplayData();
        }
    }

    private bool CanDeleteExecute(object obj)
    {
        return true;
    }

    private bool CanRegisterExecute(object obj)
    {
		return true;
    }

    private void Register(object obj)
    {
        phoneRepository.CreatePhone(Manufacturer, RamSize);
		DisplayData();
    }

    private void DisplayData()
    {
        var collection = new ObservableCollection<PhoneCRUDModel>();

        foreach (DataRow row in phoneRepository.GetAllData().Rows)
        {
            var item = new PhoneCRUDModel()
            {
                Manufacturer = row.IsNull("Manufacturer") ? string.Empty : row.Field<string>("Manufacturer"),
                RamSize = row.IsNull("RamSize") ? 0 : row.Field<int>("RamSize")
            };

            collection.Add(item);
        }

		SavedPhoneDetails = collection;
    }
}
