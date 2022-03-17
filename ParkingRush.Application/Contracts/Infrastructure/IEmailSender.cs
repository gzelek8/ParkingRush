using ParkingRush.Application.Models;

namespace ParkingRush.Application.Contracts.Infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}