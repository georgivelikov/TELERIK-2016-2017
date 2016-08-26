namespace BrainGames.Utilities.CustomExceptions
{
    using System;

    public class HiddenBoardException : Exception
    {
        public HiddenBoardException(string message) : base(message)
        {
        }
    }
}
