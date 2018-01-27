namespace Common.Tools
{
    public static class UnitConversions
    {
        public static long KilobytesInBytes(int iKilobytes)
        {
            return iKilobytes * 1000;
        }

        public static long KibibytesInBytes(int iKibibytes)
        {
            return iKibibytes * 1024;
        }
    }
}
