﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption;

public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string SecurityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
    }
}