using System.Collections.Generic;

namespace Common.System.ObjectPool
{
    public class Manager
    {
        private List<Pool<object>> m_objectPools;

        /// <summary>
        /// Constructs
        /// </summary>
        public Manager()
        {
            m_objectPools = new List<Pool<object>>();
        }
    }
}
