namespace BookStore.Exceptions
{
    public class NoSuchBookAvailableException : Exception
    {
        string msg = "";
        public NoSuchBookAvailableException() {
            msg = "No Such Book Available!!";
        }
        public override string Message => base.Message;
    }
}
