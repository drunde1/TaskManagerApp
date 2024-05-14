using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Cleaning", "Chiling", "Meeting", "HangingOut", "Film", "Work", "Homework"
        };

        private static readonly string[] Descriptions = new[]
       {
            "MustBeDone", "By16.05", "CanBeForgoten", "SomeForFun", "NotMine"
        };

        private readonly ILogger<Task> _logger;

        public TaskController(ILogger<Task> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Task> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Task
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Description = Descriptions[Random.Shared.Next(Descriptions.Length)],
                IsCompleted = false
            })
            .ToArray();
        }
    }
}
