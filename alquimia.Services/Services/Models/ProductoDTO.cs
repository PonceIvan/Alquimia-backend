﻿using System.ComponentModel.DataAnnotations;

namespace backendAlquimia.Models
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string TipoProducto { get; set; }
    }
}