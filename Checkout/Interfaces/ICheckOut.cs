namespace CheckOutKata.Classes
{
    /// <summary>
    /// Represents the CheckOut object
    /// </summary>
    public interface ICheckOut
    {
        decimal GetTotal();
        void Scan(ScannedItem scannedItem);
    }
}