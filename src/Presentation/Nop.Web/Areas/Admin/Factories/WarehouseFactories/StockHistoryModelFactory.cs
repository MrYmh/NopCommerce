
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Vendors;
using Nop.Services.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Vendors;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the stock history model factory implementation
    /// </summary>
    public class StockHistoryModelFactory : IStockHistoryModelFactory
    {

        #region Fields

        private readonly IStockHistoryService _stockHistoryService;
        private readonly IStockItemHistoryService _stockItemHistoryService;
        private readonly IVendorService _vendorService;

        #endregion

        #region Ctor

        public StockHistoryModelFactory(IStockHistoryService stockHistoryService,
            IVendorService vendorService,
            IStockItemHistoryService stockItemHistoryService)
        {
            _stockHistoryService = stockHistoryService;
            _vendorService = vendorService;
            _stockItemHistoryService = stockItemHistoryService;
        }

        #endregion

        #region Utilities

        private void PrepareAvailablePriorities(IList<SelectListItem> items)
        {
            items.Add(new SelectListItem()
            {
                Text = Priority.High.ToString(),
                Value = ((int)Priority.High).ToString(),
            });

            items.Add(new SelectListItem()
            {
                Text = Priority.Normal.ToString(),
                Value = ((int)Priority.Normal).ToString(),
            });
            items.Add(new SelectListItem()
            {
                Text = Priority.Low.ToString(),
                Value = ((int)Priority.Low).ToString(),
            });
        }

        private async Task PrepareAvailableVendorsAsync(IList<SelectListItem> items)
        {
            var vendors = await _vendorService.GetAllVendorsAsync();

            if(vendors != null)
            {
                foreach (var vendor in vendors)
                {
                    items.Add(new SelectListItem()
                    {
                        // vendors name
                        Text = vendor.Name,
                        Value = vendor.Id.ToString()
                    });
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare stock history search model
        /// </summary>
        /// <param name="searchModel">stock history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history search model
        /// </returns>
        public StockHistorySearchModel PrepareStockHistorySearchModelAsync(StockHistorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged stock history list model
        /// </summary>
        /// <param name="searchModel">stock history search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history list model
        /// </returns>
        public async Task<StockHistoryListModel> PrepareStockHistoryListModelAsync(StockHistorySearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare saerch model values
            IEnumerable<int> vendorIds = null; 

            if (searchModel.VendorName != null)
            {
                vendorIds = (await _vendorService.GetAllVendorsAsync(name: searchModel.VendorName)).Select(vendor =>
                {
                    return vendor.Id;
                });
            }
            
            //var typeOfProcess = searchModel.TypeOfProcess != null ? Convert.ToInt32(searchModel.TypeOfProcess) : 0;

            //get stock histories for the warehouse
            var stockHistory = await _stockHistoryService.GetAllStockHistoryAsync(
                warehouseId: searchModel.WarehouseId,
                typeOfProcess: searchModel.TypeOfProcess != null ? int.TryParse(searchModel.TypeOfProcess, out int result) ? result : 0 : 0,
                stockRequestId: searchModel.StockHistoryId != null ? int.TryParse(searchModel.StockHistoryId, out int result2)? result2 :0 : 0,
                vendorIds: vendorIds,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new StockHistoryListModel().PrepareToGridAsync(searchModel, stockHistory, () =>
            {
                return stockHistory.SelectAwait(async stockHistory =>
                {
                    
                    //fill in model values from the entity
                    var stockHistoryModel = stockHistory.ToModel<StockHistoryModel>();

                    //stockHistoryModel.VendorName
                    var vendor = await _vendorService.GetVendorByIdAsync(stockHistoryModel.VendorId);
                    if (vendor != null)
                    {
                        stockHistoryModel.Vendor = vendor.ToModel<VendorModel>();
                        stockHistoryModel.VendorName = vendor.Name;
                    }
                        

                    return stockHistoryModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare stock history model
        /// </summary>
        /// <param name="model">stock history model</param>
        /// <param name="stockHistory">StockHistory</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock history model
        /// </returns>
        public async Task<StockHistoryModel> PrepareStockHistoryModelAsync(StockHistoryModel model, StockHistory stockHistory)
        {

            if (stockHistory != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = stockHistory.ToModel<StockHistoryModel>();
                    var stockItemsHistory = await _stockItemHistoryService.GetAllStockItemsHistoryAsync(stockHistory.Id);
                    var stockItemHistoryModels = stockItemsHistory.Select(x => x.ToModel<StockItemHistoryModel>()).ToList();
                    //populate the stock items history.
                    model.StockItems = stockItemHistoryModels;


                }
            }

            //prepare model fields
            //PrepareAvailablePriorities(model.AvailablePriorities);
            PrepareAvailablePriorities(model.AvailablePriorities);
            await PrepareAvailableVendorsAsync(model.AvailableVendors);

            return model;
        }

        

        #endregion

    }

}
