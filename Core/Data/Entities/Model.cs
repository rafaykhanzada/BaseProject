using Core.Data.Common;
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
    public class Model : HasIdDate
    {
        public string? ModelCode { get; set; }
        public string? ModelName { get; set; }
        public int? VariantId { get; set; }
        public string? VariantName { get; set; }

        [ForeignKey("VariantId")]
        public Variant? Variant { get; set; }   
    }
}
