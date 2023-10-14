namespace ASP_Db_4._10.Model
{
    public class MobilePhone
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Memory { get; set; }
        public string? BatteryVolume { get; set; }
        public string? ScreenSize { get; set; }
        public string? Camera { get; set; }

        public double Price { get; set; }

        public int BrandId { get; set; } = default!;
        public Brand? Brand { get; set; }
    }
}
