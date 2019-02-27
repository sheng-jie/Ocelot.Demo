using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Catalog.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogController : ControllerBase {
        private static List<CatalogItem> _catalogItems;
        static CatalogController () {
            _catalogItems = new List<CatalogItem> () {
                new CatalogItem (1, "iphone 5", 2555),
                new CatalogItem (2, "iphone 6", 3555),
                new CatalogItem (3, "iphone 7", 4555),
                new CatalogItem (4, "iphone 8", 5555)
            };
        }
        public List<CatalogItem> CatalogItems { get; set; }
        // GET api/catalog
        [HttpGet]
        public ActionResult<IEnumerable<CatalogItem>> GetAll () {
            return _catalogItems;
        }

        // GET api/catalog/5
        [HttpGet ("{id}")]
        public ActionResult<CatalogItem> Get (int id) {
            var item = _catalogItems.FirstOrDefault (it => it.Id == id);
            if (item == null) {
                return BadRequest ($"There is no catalog item {id}");
            }

            return item;
        }

        // POST api/catalog
        [HttpPost]
        public void Post ([FromBody] CatalogItem newItem) {
            _catalogItems.Add(newItem);
         }

        // PUT api/catalog/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/catalog/5
        [HttpDelete ("{id}")]
        public void Delete (int id) {
            var item = _catalogItems.FirstOrDefault (it => it.Id == id);
            if (item != null) {
                _catalogItems.Remove (item);
            }
        }
    }
}