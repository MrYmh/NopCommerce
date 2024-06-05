
using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Warehouses;
using Nop.Services.Warehouses.Interface;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Warehouses;
using Nop.Web.Framework.Models.Extensions;
using ZXing;

namespace Nop.Web.Areas.Admin.Factories.WarehouseFactories
{
    /// <summary>
    /// Represents the shelf model factory implementation
    /// </summary>
    public class ShelfModelFactory : IShelfModelFactory
    {

        #region Fields

        private readonly IShelfService _shelfService;

        #endregion

        #region Ctor

        public ShelfModelFactory(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare shelf search model
        /// </summary>
        /// <param name="searchModel">shelf search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf search model
        /// </returns>
        public ShelfSearchModel PrepareShelfSearchModelAsync(ShelfSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged shelf list model
        /// </summary>
        /// <param name="searchModel">shelf search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf list model
        /// </returns>
        public async Task<ShelfListModel> PrepareShelfListModelAsync(ShelfSearchModel searchModel)
        {
            try
            {
                if (searchModel == null)
                    throw new ArgumentNullException(nameof(searchModel));

                var shelf = await _shelfService.GetAllShelvesAsync(
                    warehouseId: searchModel.WarehouseId,
                    standId: searchModel.StandId,
                    barcode: searchModel.Barcode,
                    pageIndex: searchModel.Page - 1,
                    pageSize: searchModel.PageSize
                    );

                //prepare grid model
                var model = await new ShelfListModel().PrepareToGridAsync(searchModel, shelf, () =>
                {
                    return shelf.SelectAwait(async shelf =>
                    {
                        //fill in model values from the entity
                        var shelfModel = shelf.ToModel<ShelfModel>();

                        return shelfModel;
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
        /// Prepare shelf model
        /// </summary>
        /// <param name="model">shelf model</param>
        /// <param name="shelf">Shelf</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the shelf model
        /// </returns>
        //Task<ShelfModel> PrepareShelfModelAsync(ShelfModel model, Shelf shelf)
        //{

        //    if (shelf != null)
        //    {
        //        //fill in model values from the entity
        //        if (model == null)
        //        {
        //            model = shelf.ToModel<ShelfModel>();
        //        }
        //    }


        //    //prepare model fields

        //    return Task.FromResult(model);
        //}

        Task<ShelfModel> IShelfModelFactory.PrepareShelfModelAsync(ShelfModel model, Shelf shelf)
        {
            if (shelf != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = shelf.ToModel<ShelfModel>();
                }
            }


            //prepare model fields

            return Task.FromResult(model);
        }

        #endregion

    }

}
