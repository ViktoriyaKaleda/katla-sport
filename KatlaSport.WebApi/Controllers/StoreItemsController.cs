﻿using KatlaSport.Services.StoreItemManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/storeItems")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class StoreItemsController : ApiController
    {
        private readonly IStoreItemService _storeItemService;

        public StoreItemsController(IStoreItemService storeItemService)
        {
            _storeItemService = storeItemService ?? throw new ArgumentNullException(nameof(storeItemService));
        }

        [HttpGet]
        [Route("sections/{hiveSectionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns store items.", Type = typeof(StoreItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSectionStoreItemsAsync(int hiveSectionId)
        {
            var hive = await _storeItemService.GetHiveSectionStoreItemsAsync(hiveSectionId);
            return Ok(hive);
        }

        [HttpGet]
        [Route("{storeItemId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a store item.", Type = typeof(StoreItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveAsync(int storeItemId)
        {
            var storeItem = await _storeItemService.GetStoreItemAsync(storeItemId);
            return Ok(storeItem);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new hive section store item.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddStoreItemAsync([FromBody] UpdateStoreItemRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storeItem = await _storeItemService.CreateStoreItemAsync(createRequest);
            var location = string.Format("/api/storeItems/{0}", storeItem.Id);
            return Created<StoreItem>(location, storeItem);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed store item.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateProduct([FromUri] int id, [FromBody] UpdateStoreItemRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _storeItemService.UpdateStoreItemAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}