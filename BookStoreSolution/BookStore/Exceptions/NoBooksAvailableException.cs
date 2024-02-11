using Microsoft.VisualBasic;

namespace BookStore.Exceptions
{
    public class NoBooksAvailableException : Exception
    {
        string Msg = "";
        public NoBooksAvailableException() {
            Msg = "No Books are Available!! ";

        }
        public override string Message => base.Message;
    }
}
