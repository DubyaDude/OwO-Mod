namespace OwO_Mod
{
    public static class PatchUtils
    {
        public static void OwOifyGetObj<T>(ref string __result)
        {
            try
            {
                __result = Utils.OwOify(__result);
            }
            catch
            {
                // ignored
            }
        }

        public static void OwOifySetObj<T>(ref string __0)
        {
            try
            {
                __0 = Utils.OwOify(__0);
            }
            catch
            {
                // ignored
            }
        }
    }
}
