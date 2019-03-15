﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatos.Database
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int TotalInShelf { get; set; }
        public int TotalInVault { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}