using System.Collections.Generic;

namespace LeadX.NET.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VendorId { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<Label> Labels { get; set; }
        public IEnumerable<string> UserPermissions { get; set; }
    }
}
