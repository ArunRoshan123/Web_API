﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.RequestModels
{
    public class CreationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }
        public string colour { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       // public int UserId { get; set; }
    }
}
