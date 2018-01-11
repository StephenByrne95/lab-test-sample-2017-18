using UnityEngine.UI;

public class StorageView
{
	private StorageModel model;
	private Text textUnits;
	private Text textNearlyFull;

	public void SetModel(StorageModel model)
	{
		this.model = model;
	}

	public void SetUITexts(Text textUnits, Text textNearlyFull)
	{
		this.textUnits = textUnits;
		this.textNearlyFull = textNearlyFull;
	}

	public void Refresh()
	{
		this.textUnits.text = model.GetUnits().ToString();
		this.textNearlyFull.text = model.IsNearlyFull().ToString();
	}
}
