using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Constants
{
    public static class Consts
    {
		public const string FullVehicle = "Vehicle is full!";
		public const string EmptyVehicle = "No products left in vehicle!";

		public const string InvalidGarageSlot = "Invalid garage slot!";
		public const string SlotEmpty = "No vehicle in this garage slot!";
		public const string NoRoom = "No room in garage!";
		public const string FullStorage = "Storage is full!";

		public const string AddedProduct = "Added {0} to pool";
		public const string InvalidProduct = "Invalid product type!";
		public const string NegativePrice = "Price cannot be negative!";

		public const string InvalidVehicle = "Invalid vehicle type!";

		public const string InvalidStorage = "Invalid storage type!";
		public const string RegisteredStorage = "Registered {0}";

		public const string SelectedVehicle = "Selected {0}";
		public const string OutOfStock = "{0} is out of stock!";
		public const string ProductsLoaded = "Loaded {0}/{1} products into {2}";

		public const string InvalidSource = "Invalid source storage!";
		public const string InvalidDest = "Invalid destination storage!";
		public const string SendVehicleTo = "Sent {0} to {1} (slot {2})";

		public const string Unloaded = "Unloaded {0}/{1} products at {2}";

		public const string Error = "Error: {0}";
	}
}
