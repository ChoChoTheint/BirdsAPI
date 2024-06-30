using BirdsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirdsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : Controller
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(json)!;

                List<BirdViewModel> lst = birds.Select(bird => Change(bird)).ToList();
                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAs(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(json)!;
                var item = Change(bird);
                
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        private BirdViewModel Change(BirdDataModel bird)
        {
            var item = new BirdViewModel
            {
                Id = bird.Id,
                BirdMyanmarName = bird.BirdMyanmarName,
                Description = bird.Description,
                ImagePath = $"https://burma-project-ideas.vercel.app/birds/{bird.ImagePath}"
            };
            return item;
        }
    }
}

