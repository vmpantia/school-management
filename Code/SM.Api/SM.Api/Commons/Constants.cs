namespace SM.Api.Commons
{
    public class Constants
    {
        #region Commons
        public const char CHAR_ZERO = '0';
        #endregion

        #region FunctionIDs
        public const string FUNCTION_ID_ADD_STUDENT = "01A00";
        public const string FUNCTION_ID_CHANGE_STUDENT = "01C00";
        #endregion

        #region IDs
        public const string FORMAT_STUDENT_ID = "STD{0}{1}";
        public const string FORMAT_TEACHER_ID = "TCH{0}{1}";
        public const string FORMAT_REQUEST_ID = "REQ{0}{1}";

        public const string DEFAULT_UNQ_ID_SUFFIX = "00000001";
        public const string DEFAULT_REQ_ID_SUFFIX = "0001";

        public const int LENGTH_UNQ_ID_PREFIX = 7;
        public const int LENGTH_UNQ_ID_SUFFIX = 8;
                         
        public const int LENGTH_REQ_ID_PREFIX = 11;
        public const int LENGTH_REQ_ID_SUFFIX = 4;

        public const int LENGTH_ID = 15;
        #endregion

        #region Error Messages
        public const string ERROR_INSERT = "Error in inserting {0} record.";
        public const string ERROR_UPDATE = "Error in updating {0} record.";
        public const string ERROR_REQUEST_NULL = "{0} Request cannot be NULL.";
        public const string ERROR_MODEL_NULL = "{0} cannot be NULL.";
        public const string ERROR_MODEL_ID_NOT_FOUND = "{0} ID can't found in the System.";
        #endregion

        #region Models
        public const string MODEL_REQUEST = "Request";
        public const string MODEL_STUDENT = "Student";
        public const string MODEL_CONTACTS = "Contacts";
        public const string MODEL_ADDRESSES = "Addresses";
        #endregion
    }
}
