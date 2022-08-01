using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ValueOfConsole
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Age age { get; set; }
        public EmailAddress EmailAddress { get; set; }

        internal bool Validate()
        {
            return !string.IsNullOrWhiteSpace(this.FirstName) && !string.IsNullOrWhiteSpace(this.LastName) && this.age != null && this.EmailAddress != null;

        }
    }

    public class EmailAddress : ValueOf<string, EmailAddress>
    {
        protected override bool TryValidate()
        {
            return Value.IndexOf('@') != -1;
        }
    }

    public class Age: ValueOf<int,Age>
    {
        protected override bool TryValidate()
        {
            return Value > 0 && Value < 120;
        }
    }
}
