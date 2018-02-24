using System.Collections.Generic;

namespace Common.Source.Tools
{
    class Register<NameType> where NameType : class
    {
        private int m_iNextUid;
        private SortedDictionary<NameType, int> m_ids;
        private SortedDictionary<int, NameType> m_names;

        public Register()
        {
            m_iNextUid = 0;
            m_ids = new SortedDictionary<NameType, int>();
            m_names = new SortedDictionary<int, NameType>();
        }
        
        public int Add(NameType name)
        {
            if (name == null)
            {
                return -1;
            }

            if (GetUid(name) != -1)
            {
                return -1;
            }

            int iUid = m_iNextUid;
            m_ids.Add(name, iUid);
            m_names.Add(iUid, name);
            ++m_iNextUid;
            return iUid;
        }

        public NameType GetName(int iUid)
        {
            NameType name;
            if (m_names.TryGetValue(iUid, out name))
            {
                return name;
            }

            return null;
        }

        public int GetUid(NameType name)
        {
            int iUid;
            if (m_ids.TryGetValue(name, out iUid))
            {
                return iUid;
            }

            return -1;
        }

        public bool IsRegistered(int iUid)
        {
            return m_names.ContainsKey(iUid);
        }

        public bool IsRegistered(NameType name)
        {
            return m_ids.ContainsKey(name);
        }

        public void Remove(int iUid)
        {
            NameType name = GetName(iUid);
            if (name != null)
            {
                m_ids.Remove(name);
                m_names.Remove(iUid);
            }
        }

        public void Remove(NameType name)
        {
            int iUid = GetUid(name);
            if (iUid != -1)
            {
                m_ids.Remove(name);
                m_names.Remove(iUid);
            }
        }
    }
}
