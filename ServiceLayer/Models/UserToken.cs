using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    class UserToken
    {
        [Id]
        public int ID { get; set; }
        public int MyProperty { get; set; }
    }
}
