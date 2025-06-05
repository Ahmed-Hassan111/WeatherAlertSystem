using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAlertSystem.Domain.Entities

{ 
    public class WeatherLog 
    {
        [Key] // Primary key annotation
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int Id { get; set; }
        public string City { get; set; } 
        public double Temperature { get; set; } 
        public double Rainfall { get; set; }
        public double WindSpeed { get; set; }
        public DateTime RecordedAt { get; set; }
        
    } 
} 
