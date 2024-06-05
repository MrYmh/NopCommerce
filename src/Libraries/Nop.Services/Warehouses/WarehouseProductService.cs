using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Warehouses;
using Nop.Data;
using Nop.Services.Catalog;
using Nop.Services.Localization;
using Nop.Services.Warehouses.Interface;
using Org.BouncyCastle.Asn1;

namespace Nop.Services.Warehouses
{
    public class WarehouseProductService : IWarehouseProductService
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IRepository<WarehouseProduct> _warehouseProductRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public WarehouseProductService(
            ILocalizationService localizationService,
            IRepository<WarehouseProduct> warehouseProductRepository,
            IStaticCacheManager staticCacheManager , IProductService productService)
        {
            _localizationService = localizationService;
            _warehouseProductRepository = warehouseProductRepository;
            _staticCacheManager = staticCacheManager;
            _productService = productService;
        }



        #endregion

        #region Methods

        /// <summary>
        /// Delete Warehouse Product
        /// </summary>
        /// <param name="warehouseProduct">warehouseProduct</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseProductAsync(WarehouseProduct warehouseProduct)
        {
            if (warehouseProduct is null)
                throw new ArgumentNullException(nameof(warehouseProduct));

            await _warehouseProductRepository.DeleteAsync(warehouseProduct);
        }

        /// <summary>
        /// Delete a list of Warehouse Products
        /// </summary>
        /// <param name="WarehouseProducts">WarehouseProducts</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteWarehouseProductAsync(IList<WarehouseProduct> warehouseProducts)
        {
            if (warehouseProducts is null)
                throw new ArgumentNullException(nameof(warehouseProducts));

            await _warehouseProductRepository.DeleteAsync(warehouseProducts);
        }

        /// <summary>
        /// Gets all Warehouse Products
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Products
        /// </returns>
        public async Task<IList<WarehouseProduct>> GetAllWarehouseProductsAsync()
        {
            return await _warehouseProductRepository.GetAllAsync(query => query.Where(x => !x.Deleted));
        }

        /// <summary>
        /// Gets all available Warehouse Products
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the available Warehouse Products
        /// </returns>
        public async Task<IList<WarehouseProduct>> GetAllAvailableWarehouseProductsAsync()
        {
            return await _warehouseProductRepository.GetAllAsync(query => query.Where(x => x.Available && !x.Deleted));
        }

        /// <summary>
        /// Gets Warehouse Product by identifier
        /// </summary>
        /// <param name="warehouseProductId">Warehouse Product identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Warehouse Product
        /// </returns>
        public async Task<WarehouseProduct> GetWarehouseProductByIdAsync(int warehouseProductId)
        {
            return await _warehouseProductRepository.GetByIdAsync(warehouseProductId);
        }


        public async Task<IEnumerable<int>> GetProductsIdsByWarehouseProductCategoryMappingIdsAsync(IEnumerable<int> warehouseProductCategoryMappingIds)
        {
            var warehouseProducts = await _warehouseProductRepository.GetAllAsync(query => query.Where(x => warehouseProductCategoryMappingIds.Contains(x.WarehouseProductCategoryMappingId) && !x.Deleted));
            
            return warehouseProducts.Select(x => x.ProductId);
        }

        /// <summary>
        /// Gets all warehouse products
        /// </summary>
        /// <param name="warehouseId">Warehouse identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse products
        /// </returns>
        public async Task<IPagedList<WarehouseProduct>> GetAllWarehouseProductsAsync(int warehouseId,string productName, string sku, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            try
            {
                var warehouseProducts = await _warehouseProductRepository.GetAllAsync(query =>
                {
                    query = query.Where(x => !x.Deleted && x.WarehouseId == warehouseId);

                    if (!string.IsNullOrWhiteSpace(productName))
                        query = query.Where(x => x.Name.Contains(productName));

                    if (!string.IsNullOrWhiteSpace(sku))
                        query = query.Where(x => x.Sku.Contains(sku));

                    return query.OrderBy(x => x.Id);
                });

                //paging
                return new PagedList<WarehouseProduct>(warehouseProducts, pageIndex, pageSize);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Get warehouse product by identifiers
        /// </summary>
        /// <param name="warehouseProductIds">warehouse product identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the warehouse product that retrieved by identifiers
        /// </returns>
        public async Task<IList<WarehouseProduct>> GetWarehouseProductByIdsAsync(int[] warehouseProductIds)
        {
            return await _warehouseProductRepository.GetByIdsAsync(warehouseProductIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts a Warehouse Product
        /// </summary>
        /// <param name="warehouseProduct">>warehouseProduct</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task InsertWarehouseProductAsync(WarehouseProduct warehouseProduct)
        {
            if (warehouseProduct is null)
                throw new ArgumentNullException(nameof(warehouseProduct));

            await _warehouseProductRepository.InsertAsync(warehouseProduct);
        }

        /// <summary>
        /// Updates the Warehouse Product 
        /// </summary>
        /// <param name="warehouseProduct">>warehouseProduct</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateWarehouseProductAsync(WarehouseProduct warehouseProduct)
        {
            if (warehouseProduct is null)
                throw new ArgumentNullException(nameof(warehouseProduct));

            await _warehouseProductRepository.UpdateAsync(warehouseProduct);
        }

        #endregion
    }
}
