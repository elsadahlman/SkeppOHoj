﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkeppOHoj.Models.DTOs
{
    public class InsuranceCreationDto
    {

        public int InsuranceTypeId { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Range(0, Double.MaxValue)]
        public double Premium { get; set; }
    }
}
