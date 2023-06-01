using TAF_TMS_C1onl.Models.Enums;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace TAF_TMS_C1onl.Models
{
    public class Case
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("section_id")] public int SectionId { get; set; }
        [JsonPropertyName("template_id")] public int TemplateId { get; set; }
        [JsonPropertyName("type_id")] public int TypeId { get; set; }
        [JsonPropertyName("priority_id")] public int PriorityId { get; set; }
        [JsonPropertyName("milestone_id")] public string MilestoneId { get; set; }
        [JsonPropertyName("refs")] public string Refs { get; set; }
        [JsonPropertyName("created_by")] public int CreatedBy { get; set; }
        [JsonPropertyName("created_on")] public int CreatedOn { get; set; }
        [JsonPropertyName("updated_by")] public int UpdatedBy { get; set; }
        [JsonPropertyName("updated_on")] public int UpdatedOn { get; set; }
        [JsonPropertyName("estimate")] public string Estimate { get; set; }
        [JsonPropertyName("estimate_forecast")] public string EstimateForecast { get; set; }
        [JsonPropertyName("suite_id")] public int SuiteId { get; set; }

        [JsonPropertyName("custom_preconds")] public string CustomPreconds { get; set; }
        [JsonPropertyName("custom_steps")] public string CustomSteps { get; set; }
        [JsonPropertyName("custom_expected")] public string CustomExpected { get; set; }

        protected bool Equals(Case other)
        {
            return SectionId == other.SectionId && Title == other.Title && TemplateId == other.TemplateId && TypeId == other.TypeId && CustomPreconds == other.CustomPreconds && CustomSteps == other.CustomSteps && CustomExpected == other.CustomExpected;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Case)obj);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(SectionId)}: {SectionId}, {nameof(TemplateId)}: {TemplateId}, {nameof(TypeId)}: {TypeId}, {nameof(PriorityId)}: {PriorityId}, {nameof(Estimate)}: {Estimate}, {nameof(Refs)}: {Refs},";
        }
    }
}

