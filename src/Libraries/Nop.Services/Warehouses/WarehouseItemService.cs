using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Data;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Warehouses.Interface;

namespace Nop.Services.Warehouses
{
    public class Base36Converter
    {
        private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string DecimalToBase36(int decimalValue)
        {
            if (decimalValue == 0)
                return "0";

            StringBuilder result = new StringBuilder();
            while (decimalValue > 0)
            {
                result.Insert(0, Alphabet[(int)(decimalValue % 36)]);
                decimalValue /= 36;
            }

            return result.ToString();
        }

        public static int Base36ToDecimal(string base36Value)
        {
            int result = 0;
            for (int i = 0; i < base36Value.Length; i++)
            {
                result = 36 * result + Alphabet.IndexOf(base36Value[i]);
            }
            return result;
        }
    }
    public class WarehouseItemService : IWarehouseItemService
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<WarehouseItem> _warehouseItemRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;
        private readonly IStockItemHistoryMappingService _stockItemHistoryMappingService;

        #endregion

        #region Ctor

        public WarehouseItemService(
            IAclService aclService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<WarehouseItem> warehouseItemRepository,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext,
            IStockItemHistoryMappingService stockItemHistoryMappingService)
        {
            _aclService = aclService;
            _customerService = customerService;
            _localizationService = localizationService;
            _warehouseItemRepository = warehouseItemRepository;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _stockItemHistoryMappingService = stockItemHistoryMappingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Item
        /// </summary>
        /// <param name="warehouseItem">WarehouseItem</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseItemAsync(WarehouseItem warehouseItem)
        {
            if (warehouseItem is null)
                throw new ArgumentNullException(nameof(warehouseItem));

            await _warehouseItemRepository.DeleteAsync(warehouseItem);
        }

        /// <summary>
        /// Delete a list of Warehouse Items
        /// </summary>
        /// <param name="warehouseItems">Warehouse Items</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<bool> DeleteWarehouseItemAsync(IList<WarehouseItem> warehouseItems)
        {
            try
            {
                if (warehouseItems is null)
                {
                    return false;
                }
                else
                {
                    await _warehouseItemRepository.DeleteAsync(warehouseItems);
                    return true;
                }
                    

                
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Gets all Warehouse Items
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Items
        /// </returns>
        public async Task<IList<WarehouseItem>> GetAllWarehouseItemsAsync(int warehouseId)
        {
            return await _warehouseItemRepository.GetAllAsync(
                query => query.Where(item => item.WarehouseId == warehouseId && !item.Deleted)
                );
        }

        /// <summary>
        /// Gets Available Warehouse Items Count
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <param name="WarehouseProductCombinationId">WarehouseProductCombinationId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains Available Warehouse Items Count for specific Combination
        /// </returns>
        public async Task<int> GetAvailableWarehouseItemsCountAsync(int warehouseId, int warehouseProductCombinationId)
        {
            var records = await _warehouseItemRepository.GetAllAsync(
                query => query.Where(i => i.WarehouseId == warehouseId && !i.Deleted && i.WarehouseProductCombinationId == warehouseProductCombinationId && i.ItemStatus == (int)ItemStatus.Scanned)
                );

            return records.Count;
        }

        /// <summary>
        /// Gets Available Warehouse Items Count
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <param name="sku">sku</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains Available Warehouse Items Count for all Combinations together
        /// </returns>
        public async Task<int> GetAvailableWarehouseItemsCountAsync(int warehouseId, string sku)
        {
            var records = await _warehouseItemRepository.GetAllAsync(
                query => query.Where(i => i.WarehouseId == warehouseId && !i.Deleted && i.Sku.Equals(sku) && i.ItemStatus == (int)ItemStatus.Scanned)
                );

            return records.Count;
        }

        /// <summary>
        /// Get Printed Warehouse Items Barcodes
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Printed Warehouse Items Barcodes
        /// </returns>
        public async Task<IList<string>> GetPrintedWarehouseItemsBarcodesAsync(int warehouseId)
        {
            var printedWarehouseItems = await _warehouseItemRepository.GetAllAsync(
                query => query.Where(i => i.WarehouseId == warehouseId && !i.Deleted && i.ItemStatus == (int)ItemStatus.Printed)
                );

            return printedWarehouseItems.Select(i => i.Barcode).ToList();
        }

        /// <summary>
        /// Get unprinted warehouse Items
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <param name="sku">sku</param>
        /// <param name="quantity">quantity</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Unprinted Warehouse Items
        /// </returns>
        public async Task<IList<WarehouseItem>> GetUnPrintedWarehouseItemsBarcodesAsync(int warehouseId, string sku, int quantity = 0)
        {
            return await _warehouseItemRepository.GetAllAsync(
                query =>
                {
                    query = query.Where(i => i.WarehouseId == warehouseId && i.Sku.Equals(sku) && !i.Deleted && i.ItemStatus == (int)ItemStatus.Received);
                    if (quantity <= 0)
                        return query.Take(0);

                    return query.Take(quantity);
                });
        }

        /// <summary>
        /// Get Unscanned Warehouse Items Barcodes
        /// </summary>
        /// <param name="warehouseId">warehouseId</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Unscanned Warehouse Items Barcodes
        /// </returns>
        public async Task<IList<string>> GetUnscannedWarehouseItemsBarcodesAsync(int warehouseId)
        {
            var unscannedWarehouseItems = await _warehouseItemRepository.GetAllAsync(
                query => query.Where(i => i.WarehouseId == warehouseId && !i.Deleted && i.ItemStatus == (int)ItemStatus.Printed)
                );

            return unscannedWarehouseItems.Select(i => i.Barcode).ToList();
        }

        /// <summary>
        /// Gets Warehouse Item by Barcode
        /// </summary>
        /// <param name="barcode">barcode</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Item
        /// </returns>
        public async Task<WarehouseItem> GetWarehouseItemByBarcodeAsync(string barcode)
        {
            var itemId = Base36Converter.Base36ToDecimal(barcode.Split('-')[1]);

            return await _warehouseItemRepository.GetByIdAsync(itemId, null, false);
        }

        /// <summary>
        /// Gets Warehouse Item by identifier
        /// </summary>
        /// <param name="warehouseItemId">Warehouse Item identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Item
        /// </returns>
        public async Task<WarehouseItem> GetWarehouseItemByIdAsync(int warehouseItemId)
        {
            return await _warehouseItemRepository.GetByIdAsync(warehouseItemId);
        }

        /// <summary>
        /// Get warehouse items by barcodes
        /// </summary>
        /// <param name="warehouseId">warehouse identifier</param>
        /// <param name="itemsBarcodes">itemsBarcodes</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contain the Warehouse Items
        /// </returns>
        public async Task<IList<WarehouseItem>> GetWarehouseItemsByBarcodesAsync(IList<string> itemsBarcodes)
        {
            var itemsIds = itemsBarcodes.Select(x => x.Split('-')[1]).Select(x => Base36Converter.Base36ToDecimal(x)).ToList();
            
            if (itemsIds.Any())
                return await _warehouseItemRepository.GetByIdsAsync(itemsIds, null,false);

            return null;
        }

        /// <summary>
        /// Gets received warehouse items using stock item history identifier
        /// </summary>
        /// <param name="warehouseId">warehouse identifier</param>
        /// <param name="stockItemHistoryId">stock item history identifier</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contain the warehouse items
        /// </returns>
        public async Task<IList<WarehouseItem>> GetReceivedWarehouseItemsByStockItemHistoryIdAsync(int warehouseId, int stockItemHistoryId)
        {
            var mappedStockItemHistories = await _stockItemHistoryMappingService.GetStockItemHistoryMappingByStockItemHistoryIdAsync(stockItemHistoryId);
            if (mappedStockItemHistories is null || !mappedStockItemHistories.Any())
                return null;

            var warehouseItemsIds = mappedStockItemHistories.Select(x => x.WarehouseItemId);

            return await _warehouseItemRepository.GetAllAsync(
                query => query.Where(i => i.WarehouseId == warehouseId && warehouseItemsIds.Contains(i.Id) && !i.Deleted && i.ItemStatus == (int)ItemStatus.Received));

        }

        /// <summary>
        /// Gets all warehouse items
        /// </summary>
        /// <param name="warehouseId">warehouse id</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse items
        /// </returns>
        public async Task<IPagedList<WarehouseItem>> GetAllWarehouseItemsAsync(int warehouseId, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var warehouseItems = await _warehouseItemRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.WarehouseId == warehouseId && !x.Deleted);


                return query.OrderBy(c => c.Id);
            });

            //paging
            return new PagedList<WarehouseItem>(warehouseItems, pageIndex, pageSize);
        }

        /// <summary>
        /// Get warehouse item by identifiers
        /// </summary>
        /// <param name="warehouseItemIds">warehouse item identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse item that retrieved by identifiers
        /// </returns>
        public async Task<IList<WarehouseItem>> GetWarehouseItemByIdsAsync(int[] warehouseItemIds)
        {
            return await _warehouseItemRepository.GetByIdsAsync(warehouseItemIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Warehouse Item
        /// </summary>
        /// <param name="warehouseItem">>Warehouse Item</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseItemAsync(WarehouseItem warehouseItem)
        {
            if (warehouseItem is null)
                throw new ArgumentNullException(nameof(warehouseItem));

            await _warehouseItemRepository.InsertAsync(warehouseItem);
        }

        /// <summary>
        /// Insert Warehouse Items
        /// </summary>
        /// <param name="warehouseItems">>Warehouse Items</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseItemAsync(IList<WarehouseItem> warehouseItems)
        {
            if (warehouseItems is null)
                throw new ArgumentNullException(nameof(warehouseItems));

            await _warehouseItemRepository.InsertAsync(warehouseItems);
        }

        /// <summary>
        /// Updates the Warehouse Item 
        /// </summary>
        /// <param name="warehouseItem">>Warehouse Item</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseItemAsync(WarehouseItem warehouseItem)
        {
            if (warehouseItem is null)
                throw new ArgumentNullException(nameof(warehouseItem));

            await _warehouseItemRepository.UpdateAsync(warehouseItem);
        }

        /// <summary>
        /// Update Warehouse Items
        /// </summary>
        /// <param name="warehouseItems">>Warehouse Items</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseItemAsync(IList<WarehouseItem> warehouseItems)
        {
            if (warehouseItems is null)
                throw new ArgumentNullException(nameof(warehouseItems));

            await _warehouseItemRepository.UpdateAsync(warehouseItems);
        }

        #endregion
    }
}
