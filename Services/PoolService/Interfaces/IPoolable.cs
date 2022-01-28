namespace Services.PoolService
{
    public interface IPoolable
    {
        /// <summary>
        /// Parent pool instance
        /// </summary>
        /// <param name="parent"></param>
        void Parent(IPool parent);
        /// <summary>
        /// Called automaticly
        /// </summary>
        void Reset();
    }
}