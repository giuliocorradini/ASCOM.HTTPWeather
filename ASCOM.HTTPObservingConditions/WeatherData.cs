namespace ASCOM.HTTPWeather
{
    class WeatherData
    {
        public double Date { get; set; }
        public double OutsideTemperature { get; set; }
        public double HeatIndex { get; set; }
        public double WindChill { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double Barometer { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }
        public double UVIndex { get; set; }
        public double ET { get; set; }
        public double Radiation { get; set; }
        public double RainRate { get; set; }
        public double WindGust { get; set; }
    }
}
