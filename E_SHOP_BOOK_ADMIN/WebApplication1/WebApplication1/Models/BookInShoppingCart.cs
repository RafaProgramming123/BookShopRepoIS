﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BookInShoppingCart
    {
        public Guid BookId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Book? Book { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
