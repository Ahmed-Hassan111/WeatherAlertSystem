namespace WeatherAlertSystem.Domain.Entities
{ 
    public class WeatherData 
    { 
        public int Id { get; set; }
        public string City { get; set; } 
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public double Rainfall { get; set; } 
    } 
}