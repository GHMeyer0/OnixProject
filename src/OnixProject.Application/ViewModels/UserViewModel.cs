using System;
using System.Text.Json.Serialization;

namespace OnixProject.Application.ViewModels
{
    public class UserViewModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}