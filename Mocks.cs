namespace FrancoHotel.Application.Test
{
    public static class Mocks
    {
        public static HotelContext GetContextInMemory()
        {
            var options = new DbContextOptionsBuilder<HotelContext>()
                .UseInMemoryDatabase(databaseName: "DBHotelYoelmi")
                .Options;
            return new HotelContext(options);
        }
    }
}
