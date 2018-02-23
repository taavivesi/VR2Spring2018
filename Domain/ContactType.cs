using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Schema;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }

        [MaxLength(32)]
        public string ContactTypeName { get; set; }

        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
