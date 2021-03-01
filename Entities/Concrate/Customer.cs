using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrate
{
    public class Customer:IEntity
    {
        [Key]
        
        public int UserID { get; set; }

        public string CompanyName { get; set; }

    }
}
