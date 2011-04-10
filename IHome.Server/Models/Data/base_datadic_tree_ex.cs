
using System.Collections.Generic;
using System;
namespace IHome.Models.Data
{
    public partial class base_datadic_tree_ex : base_datadic_tree
    {
       public List<base_datadic_tree_ex> children_ex { get; set; }
    }
}
