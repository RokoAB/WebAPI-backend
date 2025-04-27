namespace test.Exceptions
{
    public class ShoeAppException : Exception
    {
        public ShoeAppException(string? message) : base(message)
        {
        }
    }

    public class ShoeAppException_UserError : ShoeAppException
    {
        public ShoeAppException_UserError(string message)
             : base(message) 
        {
           
        }
    }

    public class ShoeAppException_InternalError : ShoeAppException
    {
        public ShoeAppException_InternalError(string message)
           : base(message) { }
    }

}
