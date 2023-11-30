﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? SKU { get; set; }
        public string? Code { get; set; }
    }
}