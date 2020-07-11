using Bora.Katalog.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bora.Katalog.DAO
{
    class Producer : IProducer
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public override string ToString()
        {
            return  Name.ToString();
        }
    }
}
