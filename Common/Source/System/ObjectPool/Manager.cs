using System.Collections.Generic;

namespace Common.System.ObjectPool
{
    internal class Manager
    {
        private List<Pool<object>> m_objectPools;
        
        public Manager()
        {
            m_objectPools = new List<Pool<object>>();
        }

        public Manager(ManagerConfig config)
        {
            m_objectPools = new List<Pool<object>>();
        }
    }
}
