
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Vendors;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the accept stock request model factory implementation
    /// </summary>
    public class AcceptStockRequestModelFactory : IAcceptStockRequestModelFactory
    {

        #region Fields

        private readonly IAcceptStockRequestService _acceptStockRequestService;
        private readonly IStockRequestService _stockRequestService;
        private readonly IStockRequestItemService _stockRequestItemService;
        private readonly IVendorService _vendorService;
        #endregion

        #region Ctor

        public AcceptStockRequestModelFactory(IAcceptStockRequestService acceptStockRequestService, 
            IStockRequestService stockRequestService, IStockRequestItemService stockRequestItemService , IVendorService vendorService)
        {
            _acceptStockRequestService = acceptStockRequestService;
            _stockRequestService = stockRequestService;
            _stockRequestItemService = stockRequestItemService;
            _vendorService = vendorService;
        }

        #endregion

        #region Utilities

        private async Task PrepareStockRequest(AcceptStockRequestModel model, int stockRequestId)
        {
            var request = await _stockRequestService.GetStockRequestByIdAsync(stockRequestId);
            if(request != null)
            {
                model.StockRequest = request.ToModel<StockRequestModel>();
            }
        }

        private async Task PrepareStockRequestItems(IList<StockRequestItemModel> items, int stockRequestId)
        {
            var requestItems = await _stockRequestItemService.GetAllStockRequestItemsAsync(stockRequestId);
            if (requestItems.Any())
            {
                //var addedItems = new List<StockRequestItemModel>();
                foreach (var item in requestItems)
                {
                    items.Add(item.ToModel<StockRequestItemModel>());
                }
                //items = addedItems;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare accept stock request search model
        /// </summary>
        /// <param name="searchModel">accept stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request search model
        /// </returns>
        public AcceptStockRequestSearchModel PrepareAcceptStockRequestSearchModelAsync(AcceptStockRequestSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged accept stock request list model
        /// </summary>
        /// <param name="searchModel">accept stock request search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request list model
        /// </returns>
        public async Task<AcceptStockRequestListModel> PrepareAcceptStockRequestListModelAsync(AcceptStockRequestSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get accept stock requests
            var acceptStockRequest = await _acceptStockRequestService.GetAllAcceptStockRequestAsync(
                warehouseId: searchModel.WarehouseId,
                processType: searchModel.RequestType != null ? searchModel.RequestType : null,
                accepted: searchModel.Approved != null ? searchModel.Approved : null,
                requestId: searchModel.StockRequestId != null ? searchModel.StockRequestId : null,
                //warehouseId: searchModel.WarehouseId,

                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize
                );

            //prepare grid model
            var model = await new AcceptStockRequestListModel().PrepareToGridAsync(searchModel, acceptStockRequest, () =>
            {
                return acceptStockRequest.SelectAwait(async acceptStockRequest =>
                {
                    //fill in model values from the entity
                    var acceptStockRequestModel = acceptStockRequest.ToModel<AcceptStockRequestModel>();

                    return acceptStockRequestModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare accept stock request model
        /// </summary>
        /// <param name="model">accept stock request model</param>
        /// <param name="acceptStockRequest">AcceptStockRequest</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the accept stock request model
        /// </returns>
        public async Task<AcceptStockRequestModel> PrepareAcceptStockRequestModelAsync(AcceptStockRequestModel model, AcceptStockRequest acceptStockRequest)
        {

            if (acceptStockRequest != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = acceptStockRequest.ToModel<AcceptStockRequestModel>();
                }
            }


            //prepare model fields
            await PrepareStockRequest(model, model.StockRequestId);

            //model.RequestorId = model.StockRequest.VendorId;
            model.StockRequest.VendorName = (await _vendorService.GetVendorByIdAsync(model.StockRequest.VendorId)).Name;
            await PrepareStockRequestItems(model.StockRequestItems, model.StockRequestId);
            return model;
        }

        #endregion

    }

}
