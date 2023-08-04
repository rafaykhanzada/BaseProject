﻿using Core.Data.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using Dapper.Contrib.Extensions;


namespace Core.Data.Entities
{
    public class Product : HasIdDate
    {
        public Product()
        {
            Variants = new HashSet<Variant>();
        }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }

        public int? PlantId { get; set; }
        public string? PlantName { get; set; }

        [ForeignKey("PlantId")]
        public virtual Plant? Plant { get; set; }

        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Variant> Variants { get; set; }

    }
}