using System.Collections.Generic;

namespace Common.System.ObjectPool
{
    public class Pool<T> where T : class, new()
    {
        private List<T> m_objects = new List<T>();

        /// <summary>
        /// Constructs a default configured object pool.
        /// </summary>
        public Pool()
        {
            m_objects = new List<T>();
        }

        /// <summary>
        /// Constructs a object pool with the given configuration.
        /// </summary>
        /// <param name="config">The desired configuration</param>
        public Pool(PoolConfig config)
        {
            m_objects = new List<T>();
        }
    }
}
