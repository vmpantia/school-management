namespace SM.Api.Commons
{
    public class Globals
    {
        public static DateTime EXEC_DATETIME = DateTime.Now;
        public static DateTime EXEC_DATE = DateTime.Parse(EXEC_DATETIME.ToString("yyyy/MM/dd"));
        public static string EXEC_REQ_DATE = EXEC_DATETIME.ToString("yyyMMdd");
        public static int EXEC_YEAR = EXEC_DATE.Year;
    }
}
