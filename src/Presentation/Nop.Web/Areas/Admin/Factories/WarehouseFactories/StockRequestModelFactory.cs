
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    /// Represents the stock request model factory implementation
    /// </summary>
    public class StockRequestModelFactory : IStockRequestModelFactory
    {

        #region Fields

        private readonly IStockRequestService _stockRequestService;
        private readonly IStockRequestItemService _stockRequestItemService;
        private readonly IVendorService _vendorService;

        #endregion

        #region Ctor

        public StockRequestModelFactory(IStockRequestService stockRequestService , 
            IStockRequestItemService stockRequestItemService,
            IVendorService vendorService)
        {
            _stockRequestService = stockRequestService;
            _stockRequestItemService = stockRequestItemService;
            _vendorService = vendorService;
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
            //get WarehouseCategoryMapping related to the warehouse
            var vendors = await _vendorService.GetAllVendorsAsync();

            foreach (var vendor in vendors)
            {
                items.Add(new SelectListItem()
                {
                    // warehouse category name
                    Text = vendor.Name,
                    Value = vendor.Id.ToString()
                });
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare stock request search model
        /// </summary>
        /// <param name="searchModel">stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request search model
        /// </returns>
        public StockRequestSearchModel PrepareStockRequestSearchModelAsync(StockRequestSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged stock request list model
        /// </summary>
        /// <param name="searchModel">stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request list model
        /// </returns>
        public async Task<StockRequestListModel> PrepareStockRequestListModelAsync(StockRequestSearchModel searchModel)
        {
            try
            {
                if (searchModel == null)
                    throw new ArgumentNullException(nameof(searchModel));

                IEnumerable<int> vendorIds = null;
                if (searchModel.VendorName != null)
                {
                    vendorIds = (await _vendorService.GetAllVendorsAsync(name: searchModel.VendorName)).Select(vendor =>
                    {
                        return vendor.Id;
                    });
                }

                //get categories
                var stockRequest = await _stockRequestService.GetAllStockRequestsAsync(
                    warehouseId: searchModel.WarehouseId,
                    typeOfProcess: searchModel.TypeOfProcess != null ? int.TryParse(searchModel.TypeOfProcess, out int result) ? result : 0 : 0,
                    stockRequestId: searchModel.StockRequestId != null ? int.TryParse(searchModel.StockRequestId, out int result2) ? result2 : 0 : 0,
                    vendorIds: vendorIds,
                    pageIndex: searchModel.Page - 1,
                    pageSize: searchModel.PageSize

                    );

                //prepare grid model
                var model = await new StockRequestListModel().PrepareToGridAsync(searchModel, stockRequest, () =>
                {
                    return stockRequest.SelectAwait(async stockRequest =>
                    {
                        //fill in model values from the entity
                        var stockRequestModel = stockRequest.ToModel<StockRequestModel>();
                        var vendor = await _vendorService.GetVendorByIdAsync(stockRequestModel.VendorId);
                        if(vendor != null)
                        {
                            stockRequestModel.Vendor = vendor.ToModel<VendorModel>();
                            stockRequestModel.VendorName = vendor.Name;
                        }
                        return stockRequestModel;
                    });
                });

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Prepare stock request model
        /// </summary>
        /// <param name="model">stock request model</param>
        /// <param name="stockRequest">StockRequest</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the stock request model
        /// </returns>
        public async Task<StockRequestModel> PrepareStockRequestModelAsync(StockRequestModel model, StockRequest stockRequest)
        {

            if (stockRequest != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = stockRequest.ToModel<StockRequestModel>();
                    var stockItemsRequests = await _stockRequestItemService.GetAllStockRequestItemsAsync(stockRequest.Id);
                    model.StockRequestItems = stockItemsRequests.Select(x => x.ToModel<StockRequestItemModel>()).ToList();
                }
            }


            //prepare model fields
            PrepareAvailablePriorities(model.AvailablePriorities);
            await PrepareAvailableVendorsAsync(model.AvailableVendors);

            return model;
        }

        #endregion

    }

}
