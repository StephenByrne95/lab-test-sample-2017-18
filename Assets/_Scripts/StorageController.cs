using UnityEngine.UI;

/// <summary>
/// Storage controller.
/// 
/// MVC-mediating controller
/// so controller will tell View to refresh after model change actions ...
/// </summary>
public class StorageController 
{
	private StorageModel model;
	private StorageView view;

	private InputField inputFieldDelivery;

	public void SetModel(StorageModel model)
	{
		this.model = model;
	}

	public void SetView(StorageView view)
	{
		this.view = view;
	}

	public void SetInputFieldDelivery(InputField inputFieldDelivery)
	{
		this.inputFieldDelivery = inputFieldDelivery;
	}

	private int GetQuantityFromInputField()
	{
		string quantityString = inputFieldDelivery.text;
		// ensure not empty - avoid exception
		if (quantityString.Length < 1)
		{
			quantityString = "0";
		}

		int quantity = int.Parse(quantityString);
		return quantity;

	}

	//-------- EVENTS ---------
	public void EVENT_Delivery()
	{
		int quantity = GetQuantityFromInputField();

		model.Deliver(quantity);
		view.Refresh();
	}



}
