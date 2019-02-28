using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Basket.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase {
        private static List<CustomerBasket> _customerBaskets;

        static BasketController () {
            _customerBaskets = new List<CustomerBasket> () {
                new CustomerBasket (1) {
                Items = new List<BasketItem> () {
                new BasketItem (1, 1, 2555)
                }
                },
                new CustomerBasket (2) {
                Items = new List<BasketItem> () {
                new BasketItem (2, 1, 3555),
                new BasketItem (3, 1, 4555)
                }
                },
                new CustomerBasket (3) {
                Items = new List<BasketItem> () {
                new BasketItem (2, 2, 3555),
                new BasketItem (3, 1, 4555)
                }
                },
                new CustomerBasket (4) {
                Items = new List<BasketItem> () {
                new BasketItem (2, 2, 3555),
                new BasketItem (3, 1, 4555),
                new BasketItem (4, 1, 5555)
                }
                },
            };
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<CustomerBasket>> Index(){
            return _customerBaskets;
        }

        // GET api/basket/5
        [HttpGet ("{id}")]
        public ActionResult<CustomerBasket> Get (int id) {
            return _customerBaskets.FirstOrDefault (cb => cb.BuyerId == id);
        }

        // DELETE api/basket/{buyerId}/{productId}
        [HttpDelete ("{buyerId}/{productId}")]
        public void Delete (int buyerId, int productId) {
            var basket = _customerBaskets.FirstOrDefault (cb => cb.BuyerId == buyerId);
            if (basket != null) {
                var basketItem = basket.Items.FirstOrDefault (it => it.ProductId == productId);
                if (basketItem != null)
                    basket.Items.Remove (basketItem);
            }
        }

        // DELETE api/clear/basket
        [HttpDelete ("clear/{id}")]
        public void Clear (int id) {
            var basket = _customerBaskets.FirstOrDefault (cb => cb.BuyerId == id);
            if (basket != null)
                _customerBaskets.Remove (basket);
        }
    }
}