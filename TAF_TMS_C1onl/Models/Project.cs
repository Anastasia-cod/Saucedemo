using TAF_TMS_C1onl.Models.Enums;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace TAF_TMS_C1onl.Models
{
    public class Project
    {

        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("announcement")] public string Announcement { get; set; }

        [JsonPropertyName("show_announcement")]
        public bool ShowAnnouncement { get; set; }

        [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
        [JsonPropertyName("completed_on")] public string CompletedOn { get; set; }
        [JsonPropertyName("suite_mode")] public int SuiteMode { get; set; }
        [JsonPropertyName("default_role_id")] public string DefaultRoleId { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("users")] public List<User> Users { get; set; }
        [JsonPropertyName("groups")] public List<Group> Groups { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}