﻿using Nagarro.BookReading.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nagarro.BookReading.Application.Models
{
    public class CommentModel: BaseModel
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please write a comment before posting")]
        public string comment { get; set; }

        public DateTime timeStamp { get; set; }

        public EventModel _Event { get; set; }

        public CommentModel()
        {
            timeStamp = DateTime.Now;
        }
    }
}
