using NUnit.Framework;

public class TestStorageModel 
{
	[Test]
	public void TestWhenCreatedUnitsZero()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		int expectedResult = 0;

		// Act
		int result = sm.GetUnits();

		// Assert
		Assert.AreEqual(expectedResult, result);
	}

	[Test]
	public void TestWhenCreatedCapacityOneHundred()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		int expectedResult = 100;

		// Act
		int result = sm.Capacity;

		// Assert
		Assert.AreEqual(expectedResult, result);
	}

	[Test]
	public void TestWhenCreatedMaxDeliveryTwenty()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		int expectedResult = 20;

		// Act
		int result = sm.MaxDelivery;

		// Assert
		Assert.AreEqual(expectedResult, result);
	}

	[Test]
	public void TestWhenCreatedNearlyFullSeventyFive()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		float expectedResult = 0.75F;

		// Act
		float result = sm.NearlyFullPercentage;

		// Assert
		Assert.AreEqual(expectedResult, result);
	}

	[Test]
	public void TestWhenCreatedIsNearlyFullFalse()
	{
		// Arrange
		StorageModel sm = new StorageModel();

		// Act
		bool result = sm.IsNearlyFull();

		// Assert
		Assert.False(result);
	}

	[Test]
	public void TestAfterValidDelveryUnitsCorrect()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		int deliveryQuantity = 10;
		int expectedResult = 10;

		// Act
		bool deliverySuccess = sm.Deliver(deliveryQuantity);
		int result = sm.GetUnits();

		// Assert
		Assert.True(deliverySuccess);
		Assert.AreEqual(expectedResult, result);
	}

	[Test]
	public void TestInvalidDeliveryReturnsFalseAndTotalUnchanged()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		int deliveryQuantity = 25;
		int expectedResult = sm.GetUnits(); // should be same at end of test

		// Act
		bool deliverySuccess = sm.Deliver(deliveryQuantity);
		int result = sm.GetUnits();

		// Assert
		Assert.False(deliverySuccess);
		Assert.AreEqual(expectedResult, result);
	}

	[Test]
	public void TestAfterMultipleValidDelveryUnitsCorrect()
	{
		// Arrange
		StorageModel sm = new StorageModel();
		int deliveryQuantity = 20;
		int expectedResult = 80;

		// Act
		bool deliverySuccess1 = sm.Deliver(deliveryQuantity);
		bool deliverySuccess2 = sm.Deliver(deliveryQuantity);
		bool deliverySuccess3 = sm.Deliver(deliveryQuantity);
		bool deliverySuccess4 = sm.Deliver(deliveryQuantity);
		bool nearlyFullStatus = sm.IsNearlyFull();
		int result = sm.GetUnits();

		// Assert
		Assert.True(nearlyFullStatus);
		Assert.AreEqual(expectedResult, result);
	}
}
