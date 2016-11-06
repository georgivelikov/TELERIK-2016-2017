namespace IntergalacticTravel.Tests.TeleportStationTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using IntergalacticTravel.Contracts;

    using TeleportStation = IntergalacticTravel.TeleportStation;

    public class MockedTeleportStation : TeleportStation
    {
        public MockedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return base.owner;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return base.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return base.location;
            }
        }

        public IResources Resources
        {
            get
            {
                return base.resources;
            }
        }
    }
}
