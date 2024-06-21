using PartTwo.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTwo.Services.Interfaces;

public  interface IBasketService
{
    Task<CustomerBasket> GetBasket(string basketId);
    Task<CustomerBasket> UpdateBasket(CustomerBasket basket);
    Task<bool> DeleteBasket(string basketId);
}
