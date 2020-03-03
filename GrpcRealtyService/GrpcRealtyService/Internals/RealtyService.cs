using DowntownRealty;

namespace GrpcRealtyService.Internals
{

    public class RealtyService : IRealtyService
    {
        public RealtyAd GetRealtyById(int id)
        {
            return new RealtyAd
            {
                Id = id,
                Type = RealtyType.House,
                Topic = "Some interesting house"
            };
        }

        public RealtyAd[] GetRealtyList()
        {
            return new RealtyAd[]
                    {
                        new RealtyAd
                        {
                            Id = 1,
                            Topic = "house 1"
                        },
                        new RealtyAd
                        {
                            Id = 2,
                            Topic = "new house"
                        },
                        new RealtyAd
                        {
                            Id = 3,
                            Topic = "Appartments"
                        }
                    };
        }
    }

    public interface IRealtyService
    {
        RealtyAd GetRealtyById(int id);
        RealtyAd[] GetRealtyList();
    }
}
