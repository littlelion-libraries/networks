namespace Networks
{
    public static class NetworkUtility
    {
        public static bool IsSuccess(int responseCode)
        {
            return responseCode / 100 == 2;
        }
    }
}