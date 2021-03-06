﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class User
    {
        public User() {}

        public User(string email, string passWord, string name) : base()
        {
            Email = email;
            HashedPassword = passWord;
            Name = name;
            UserRoles = new List<UserRole>();
        }

        public User(int id, string email, string name) : base()
        {
            Id = id;
            Email = email;
            Name = name;
            UserRoles = new List<UserRole>();
        }

        public User(int id, string email, string passWord, string name) : base()
        {
            Id = id;
            Email = email;
            HashedPassword = passWord;
            Name = name;
            UserRoles = new List<UserRole>();
        }

        public User(string email, string passWord, string name, string address, string city, string state, string zipcode, string phoneNumber) : base()
        {

            Email = email;
            HashedPassword = passWord;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
            PhoneNumber = phoneNumber;
            UserRoles = new List<UserRole>();
        }


        public User(int id, string passWord, string email,  string name, string address, string city, string state, string zipcode, string phoneNumber)
        {
            Id = id;
            Email = email;
            HashedPassword = passWord;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
            PhoneNumber = phoneNumber;
            UserRoles = new List<UserRole>();
        }


        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public List<UserRole> UserRoles { get; set; }


    }
}