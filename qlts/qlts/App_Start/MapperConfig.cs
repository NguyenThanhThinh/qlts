using AutoMapper;
using System;


namespace qlts
{
    public class MapperConfig
    {
        public static IMapper Factory { get; private set; }

        public static void Register()
        {
            var op = new MapperConfiguration(config =>
            {
                
            });

            Factory = op.CreateMapper();
        }
    }
}