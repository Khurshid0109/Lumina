﻿using Lumina.Domain.Enums;

namespace Lumina.Service.DTOs.Users;
public record UserViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsVerified { get; set; } = false;
    public Role Role { get; set; }
    public string Image { get; set; }
}
