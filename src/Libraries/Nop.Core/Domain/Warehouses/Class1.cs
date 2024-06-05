namespace Nop.Core.Domain.Warehouses
{
    public enum StockProcess
    {
        Receiving = 1,
        ReturnedToVendor = 2,
        ReturnedFromCustomer = 3,
        Damaged = 4,
        Ordered = 5
    }
}
