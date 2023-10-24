using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    internal class Model
    {
        public Model()
        {
            Operations = new();
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public List<OperationModel> Operations { get; set; }
    }
}
