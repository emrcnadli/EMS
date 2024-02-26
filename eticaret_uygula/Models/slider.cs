﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eticaret_uygula.Models
{
    public class slider
    {
        public int SliderId { get; set; }
        public string SliderName { get; set; } = string.Empty;
        public string Header1 { get; set; } = string.Empty;
        public string Header2 { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
        public string SliderImage { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile ImageUpload { get; set; }

    }
}