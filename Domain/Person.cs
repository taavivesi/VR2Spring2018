using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// https://www.upload.ee/files/8007143/ContactSolution.zip.html

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }

        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();

        public string FirstLastName => $"{FirstName} {LastName}";
        public string LastFirstName => $"{LastName} {FirstName}";
    }
}
