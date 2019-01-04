﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public LinkItem Link
        {
            get
            {
                return new LinkItem()
                {
                    Rel = "href",
                    Href = LinkItem.BasePath + "api/Students/" + Id
                };
            }
        }

        public Student()
        {
            Id = -1;
            Name = string.Empty;
            Phone = string.Empty;
        }

        public Student(int id)
        {
            Id = id;
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public Student(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
    }
}