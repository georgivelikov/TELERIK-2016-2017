namespace BrainGames.Models.CustomExceptions
{
    using System;

    public class BlockCodeException : Exception
    {
        public BlockCodeException(string message) 
            : base(message)
        {
        }
    }
}
