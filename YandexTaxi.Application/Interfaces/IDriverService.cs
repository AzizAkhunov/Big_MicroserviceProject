﻿using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface IDriverService
    {
        ValueTask<ICollection<Driver>> GetAllAsync();
        ValueTask<bool> CreateDriverAsync(DriverDTO driverDTO);
        ValueTask<bool> DeleteDriverAsync(int id);
        ValueTask<bool> UpdateDriverAsync(int id, DriverDTO driverDTO);
        ValueTask<Driver> GetDriverById(int id);
        ValueTask<bool> AskForIncrease(int driverId, decimal approximate_amount);
    }
}
