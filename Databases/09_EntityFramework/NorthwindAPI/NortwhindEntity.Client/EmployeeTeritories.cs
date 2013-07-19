using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using NorthwindEntity.Model;

namespace NortwhindEntity.Client
{
    public class EmployeeTeritories : Employee
    {
        private EntitySet<Territory> teritory;

        public EntitySet<Territory> Teritory
        {
            get {
                var eTeritories = this.Territories;
                this.teritory.AddRange(eTeritories);

                return this.teritory;
            }
        }
        
    }
}
