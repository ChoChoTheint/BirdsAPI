﻿namespace BirdsAPI.Models
{
    public class BirdDataModel
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }  
        public string Description { get; set; }
        public string ImagePath { get; set; }

    }

    public class BirdViewModel
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
