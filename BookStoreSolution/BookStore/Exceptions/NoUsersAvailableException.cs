namespace BookStore.Exceptions
{
    public class NoUsersAvailableException : Exception
    {
        string msg = "";
        public NoUsersAvailableException() {
            msg = "No Users Available";
        
        }
        public override string Message => base.Message;
    }
}
