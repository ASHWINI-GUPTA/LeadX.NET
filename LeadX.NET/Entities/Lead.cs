using System;
using System.Collections.Generic;

namespace LeadX.NET.Entities
{
    /// <summary>
    /// Class represent the LeadX Lead result
    /// </summary>
    public class Lead
    {
        public long Id { get; set; }
        public long FormId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long StatusId { get; set; }
        public long SizeId { get; set; }
        public string DxId { get; set; }
        public IEnumerable<Field> Fields { get; set; }
    }

    /// <summary>
    /// Class represent the Field of Lead
    /// </summary>
    public class Field
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}