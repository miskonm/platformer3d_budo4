namespace Services.Location
{
    public struct Coords
    {
        public float Latitude { get; }
        public float Longitude { get; }

        public Coords(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}