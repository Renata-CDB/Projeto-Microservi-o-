﻿namespace BrechoDomain.Entitys
{
    public class Receita : Base
    {
        public int? ProdutoId { get; set; }
        public string NomeCliente { get; set; }
        public string ProdutoComprado { get; set; }
    }
}
