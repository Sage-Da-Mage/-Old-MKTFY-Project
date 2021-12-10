using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// The Category class holds both the number representing the category type
    /// and the corresponding name.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The Category Id number, listed below:
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the Category type:
        /// CategoryId: 1=Cars/Vehicles, 2=Furniture, 3=Electronics, 4=Real Estate
        /// Potentially add more after talking with team
        /// </summary>
        public string Name { get; set; }
    }
}
