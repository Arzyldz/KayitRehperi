using System;
using System.Collections.Generic;
using System.Text;
using KayitRehperi.Core.DTOs;
using KayitRehperi.Core.Models;
using KayitRehperi.Core.Configuration;

namespace KayitRehperi.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}