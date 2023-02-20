namespace SM.Api.Commons
{
    public class Constants
    {
        #region Commons
        public const char CHAR_ZERO = '0';
        #endregion

        #region IDs
        public const string FORMAT_STUDENT_ID = "STD{0}";
        public const string FORMAT_TEACHER_ID = "TCH{0}";
        public const string DEFAULT_ID_SUFFIX = "0000001";
        public const int LENGTH_ID = 10;
        public const int LENGTH_ID_PREFIX = 3;
        public const int LENGTH_ID_SUFFIX = 7;
        #endregion

        #region Error Messages
        public const string ERROR_INSERT = "Error in inserting {0} record.";
        public const string ERROR_UPDATE = "Error in updating {0} record.";
        public const string ERROR_REQUEST_NULL = "{0} Request cannot be NULL.";
        public const string ERROR_MODEL_NULL = "{0} cannot be NULL.";
        public const string ERROR_MODEL_ID_NOT_FOUND = "{0} ID can't found in the System.";
        #endregion

        #region Models
        public const string MODEL_STUDENT = "Student";
        public const string MODEL_CONTACTS = "Contacts";
        public const string MODEL_ADDRESSES = "Addresses";
        #endregion
    }
}
