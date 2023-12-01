// ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;




namespace Supermarket_UseAPI.Controllers

{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7000");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = client.GetAsync("/api/Products").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return Ok(responseMessage.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return BadRequest("some thing went wrong in the request");
                }
            }
             catch (Exception ex) { return Ok(ex.Message); }
            finally { }




            }
        }
       /* private readonly HttpClient _httpClient;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("https://localhost:7000"); // Update with your actual API URL
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Products");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    // Process or return the data as needed
                    return Ok(responseData);
                }
                else
                {
                    // Handle non-success status codes
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle connection errors
                return BadRequest("Failed to connect to the external API: " + ex.Message);
            }
        }*/
    }
