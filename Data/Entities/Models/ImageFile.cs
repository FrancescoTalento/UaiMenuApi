using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class ImageFile
    {
        public long Id { get; set; }

        public string FileName { get; set; } = null!;
        public string RelativePath { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public string? AltText { get; set; }

        public long? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public long? MenuId { get; set; }
        public Menu? Menu { get; set; }

        public long? MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
    }

}
