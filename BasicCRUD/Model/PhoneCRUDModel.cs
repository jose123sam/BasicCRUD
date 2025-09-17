namespace BasicCRUD.Model;

internal class PhoneCRUDModel
{
	private int ramSize;

	public int RamSize
	{
		get { return ramSize; }
		set { ramSize = value; }
	}

	private string manufacturer = string.Empty;

	public string Manufacturer
	{
		get { return manufacturer; }
		set { manufacturer = value; }
	}
}
