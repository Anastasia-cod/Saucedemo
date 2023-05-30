using TAF_TMS_C1onl.Models.Enums;
using Newtonsoft.Json;

namespace TAF_TMS_C1onl.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("suite_mode")]
        public int SuitMode { get; set; }

        protected bool Equals(Project other)
        {
            return Name == other.Name && SuitMode == other.SuitMode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, SuitMode);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Project)obj);

        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(SuitMode)}: {SuitMode}";
        }
    }
}