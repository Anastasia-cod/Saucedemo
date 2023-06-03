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

        //[JsonPropertyName("custom_preconds")] public string CustomPreconds { get; set; }
        //[JsonPropertyName("custom_steps")] public string CustomSteps { get; set; }
        //[JsonPropertyName("custom_expected")] public string CustomExpected { get; set; }

        protected bool Equals(Case other)
        {
            return Title == other.Title && SectionId == other.SectionId && TemplateId == other.TemplateId && CreatedBy == other.CreatedBy && CreatedOn == other.CreatedOn && UpdatedBy == other.UpdatedBy && UpdatedOn == other.UpdatedOn && Estimate == other.Estimate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, SectionId, TemplateId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, Estimate);
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
            return $"\n {nameof(Id)}: {Id},\n {nameof(Title)}: {Title},\n {nameof(SectionId)}: {SectionId},\n {nameof(TemplateId)}: {TemplateId},\n {nameof(TypeId)}: {TypeId}, \n {nameof(PriorityId)}: {PriorityId},\n {nameof(Estimate)}: {Estimate},\n {nameof(CreatedBy)}: {CreatedBy},\n {nameof(CreatedOn)}: {CreatedOn},\n {nameof(UpdatedBy)}: {UpdatedBy},\n {nameof(UpdatedOn)}: {UpdatedOn}";
        }
    }
}