
using Basket.Service.Models;

internal interface IBasketStore
{
   CustomerBasket GetBasketByCustomerId(string customerId);

   void CreateCustomerBasket(CustomerBasket customerBasket);

   void UpdateCustomerBasket(CustomerBasket customerBasket);

   void DeleteCustomerBasket(string customerId);
}