namespace Nop.Services.Warehouses
{
    /// <summary>
    /// Stock Service
    /// </summary>
    //public class StockService : IStockService
    //{
    //    #region Fields

    //    private readonly IRepository<StockHistory> _StockHistory;
    //    private readonly IRepository<StockItemHistory> _stockItemHistoryRepository;
    //    private readonly IStaticCacheManager _staticCacheManager;
    //    private readonly IStoreMappingService _storeMappingService;

    //    #endregion

    //    #region Ctor

    //    public StockService(
    //        IRepository<StockHistory> StockHistory,
    //        IRepository<StockItemHistory> stockItemHistoryRepository,
    //        IStaticCacheManager staticCacheManager,
    //        IStoreMappingService storeMappingService)
    //    {
    //        _StockHistory = StockHistory;
    //        _stockItemHistoryRepository = stockItemHistoryRepository;
    //        _staticCacheManager = staticCacheManager;
    //        _storeMappingService = storeMappingService;
    //    }

    //    #endregion

    //    #region Methods

    //    #region StockHistory

    //    /// <summary>
    //    /// Deletes a blog post
    //    /// </summary>
    //    /// <param name="StockHistory">Blog post</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task DeleteStockHistoryAsync(StockHistory obj)
    //    {
    //        await _StockHistory.DeleteAsync(obj);
    //    }

    //    /// <summary>
    //    /// Gets a blog post
    //    /// </summary>
    //    /// <param name="StockHistoryId">Blog post identifier</param>
    //    /// <returns>
    //    /// A task that represents the asynchronous operation
    //    /// The task result contains the blog post
    //    /// </returns>
    //    public virtual async Task<StockHistory> GetStockHistoryByIdAsync(int id)
    //    {
    //        return await _StockHistory.GetByIdAsync(id, cache => default);
    //    }

    //    /// <summary>
    //    /// Gets all blog posts
    //    /// </summary>
    //    /// <param name="storeId">The store identifier; pass 0 to load all records</param>
    //    /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
    //    /// <param name="dateFrom">Filter by created date; null if you want to get all records</param>
    //    /// <param name="dateTo">Filter by created date; null if you want to get all records</param>
    //    /// <param name="pageIndex">Page index</param>
    //    /// <param name="pageSize">Page size</param>
    //    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    //    /// <param name="title">Filter by blog post title</param>
    //    /// <returns>
    //    /// A task that represents the asynchronous operation
    //    /// The task result contains the blog posts
    //    /// </returns>
    //    public virtual async Task<IPagedList<StockHistory>> GetAllStockHistorysAsync(int storeId = 0, int languageId = 0,
    //        DateTime? dateFrom = null, DateTime? dateTo = null,
    //        int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false, string title = null)
    //    {
    //        return await _StockHistory.GetAllPagedAsync(async query =>
    //        {
    //            if (dateFrom.HasValue)
    //                query = query.Where(b => dateFrom.Value <= b.CreatedOnUtc);

    //            if (dateTo.HasValue)
    //                query = query.Where(b => dateTo.Value >= b.CreatedOnUtc);

    //            //if (languageId > 0)
    //            //    query = query.Where(b => languageId == b.LanguageId);

    //            //if (!string.IsNullOrEmpty(title))
    //            //    query = query.Where(b => b.Title.Contains(title));

    //            //if (!showHidden || storeId > 0)
    //            //{
    //            //    //apply store mapping constraints
    //            //    query = await _storeMappingService.ApplyStoreMapping(query, storeId);
    //            //}

    //            //if (!showHidden)
    //            //{
    //            //    query = query.Where(b => !b.StartDateUtc.HasValue || b.StartDateUtc <= DateTime.UtcNow);
    //            //    query = query.Where(b => !b.EndDateUtc.HasValue || b.EndDateUtc >= DateTime.UtcNow);
    //            //}

    //            query = query.OrderByDescending(b => b.CreatedOnUtc);

    //            return query;
    //        }, pageIndex, pageSize);
    //    }






    //    /// <summary>
    //    /// Inserts a blog post
    //    /// </summary>
    //    /// <param name="StockHistory">Blog post</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task InsertStockHistoryAsync(StockHistory StockHistory)
    //    {
    //        await _StockHistory.InsertAsync(StockHistory);
    //    }

    //    /// <summary>
    //    /// Updates the blog post
    //    /// </summary>
    //    /// <param name="StockHistory">Blog post</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task UpdateStockHistoryAsync(StockHistory StockHistory)
    //    {
    //        await _StockHistory.UpdateAsync(StockHistory);
    //    }







    //    #endregion

    //    #region Blog comments

    //    /// <summary>
    //    /// Gets all comments
    //    /// </summary>
    //    /// <param name="customerId">Customer identifier; 0 to load all records</param>
    //    /// <param name="storeId">Store identifier; pass 0 to load all records</param>
    //    /// <param name="StockHistoryId">Blog post ID; 0 or null to load all records</param>
    //    /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
    //    /// <param name="fromUtc">Item creation from; null to load all records</param>
    //    /// <param name="toUtc">Item creation to; null to load all records</param>
    //    /// <param name="commentText">Search comment text; null to load all records</param>
    //    /// <returns>
    //    /// A task that represents the asynchronous operation
    //    /// The task result contains the comments
    //    /// </returns>
    //    public virtual async Task<IList<StockItemHistory>> GetAllAsync(int customerId = 0, int storeId = 0, int? StockHistoryId = null,
    //        bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
    //    {
    //        return _stockItemHistoryRepository.GetAll();
    //    }

    //    /// <summary>
    //    /// Gets a blog comment
    //    /// </summary>
    //    /// <param name="StockItemHistoryId">Blog comment identifier</param>
    //    /// <returns>
    //    /// A task that represents the asynchronous operation
    //    /// The task result contains the blog comment
    //    /// </returns>
    //    public virtual async Task<StockItemHistory> GetStockItemHistoryByIdAsync(int StockItemHistoryId)
    //    {
    //        return await _stockItemHistoryRepository.GetByIdAsync(StockItemHistoryId, cache => default);
    //    }

    //    /// <summary>
    //    /// Get blog comments by identifiers
    //    /// </summary>
    //    /// <param name="commentIds">Blog comment identifiers</param>
    //    /// <returns>
    //    /// A task that represents the asynchronous operation
    //    /// The task result contains the blog comments
    //    /// </returns>
    //    public virtual async Task<IList<StockItemHistory>> GetStockItemHistorysByIdsAsync(int[] commentIds)
    //    {
    //        return await _stockItemHistoryRepository.GetByIdsAsync(commentIds);
    //    }

    //    /// <summary>
    //    /// Get the count of blog comments
    //    /// </summary>
    //    /// <param name="StockHistory">Blog post</param>
    //    /// <param name="storeId">Store identifier; pass 0 to load all records</param>
    //    /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
    //    /// <returns>
    //    /// A task that represents the asynchronous operation
    //    /// The task result contains the number of blog comments
    //    /// </returns>
    //    public virtual async Task<int> GetStockItemHistorysCountAsync(StockHistory StockHistory, int storeId = 0, bool? isApproved = null)
    //    {
    //        var query = _stockItemHistoryRepository.Table.Where(comment => comment.StockHistoryId == StockHistory.Id);



    //        return await query.CountAsync();
    //    }

    //    /// <summary>
    //    /// Deletes a blog comment
    //    /// </summary>
    //    /// <param name="StockItemHistory">Blog comment</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task DeleteStockItemHistoryAsync(StockItemHistory StockItemHistory)
    //    {
    //        await _stockItemHistoryRepository.DeleteAsync(StockItemHistory);
    //    }

    //    /// <summary>
    //    /// Deletes blog comments
    //    /// </summary>
    //    /// <param name="StockItemHistorys">Blog comments</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task DeleteStockItemHistorysAsync(IList<StockItemHistory> StockItemHistorys)
    //    {
    //        await _stockItemHistoryRepository.DeleteAsync(StockItemHistorys);
    //    }

    //    /// <summary>
    //    /// Inserts a blog comment
    //    /// </summary>
    //    /// <param name="StockItemHistory">Blog comment</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task InsertStockItemHistoryAsync(StockItemHistory StockItemHistory)
    //    {
    //        await _stockItemHistoryRepository.InsertAsync(StockItemHistory);
    //    }

    //    /// <summary>
    //    /// Update a blog comment
    //    /// </summary>
    //    /// <param name="StockItemHistory">Blog comment</param>
    //    /// <returns>A task that represents the asynchronous operation</returns>
    //    public virtual async Task UpdateStockItemHistoryAsync(StockItemHistory StockItemHistory)
    //    {
    //        await _stockItemHistoryRepository.UpdateAsync(StockItemHistory);
    //    }

    //    #endregion

    //    #endregion
    //}
}