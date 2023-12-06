﻿using System.ComponentModel.DataAnnotations.Schema;

namespace YandexTaxi.Domain.Entities
{
    [Table("Orders")]
    public class Order : BaseClassForModels
    {
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
