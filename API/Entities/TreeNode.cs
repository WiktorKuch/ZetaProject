using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class TreeNode
    {
         public TreeNode(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        
        public string Name { get; set; } // Pole obowiązkowe
        public int? ParentId { get; set; } // ID rodzica (null, jeśli to korzeń)
        public List<TreeNode>? Children { get; set; } = new List<TreeNode>(); // Lista dzieci (opcjonalna)

    }
    
    

    
}