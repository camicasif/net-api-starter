
namespace dotnet_api_template.Data { 

    public abstract class AuditableEntity
    {
        public bool Deleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}