namespace MusicShopManager.Engine.Factories
{
    using System;

    using MusicShop.Models;

    using MusicShopManager.Interfaces;
    using MusicShopManager.Interfaces.Engine;
    using MusicShopManager.Models;

    public class MusicShopFactory : IMusicShopFactory
    {
        public IMusicShop CreateMusicShop(string name)
        {
            return new MusicShop(name);
        }
    }
}
