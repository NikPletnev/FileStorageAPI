﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Entity
{
    public  class StoragedFile
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Size { get; set; } 
        public User User { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StoragedFile file &&
                   Id == file.Id &&
                   EqualityComparer<byte[]>.Default.Equals(Data, file.Data) &&
                   Name == file.Name &&
                   Size == file.Size &&
                   EqualityComparer<User>.Default.Equals(User, file.User) &&
                   IsDeleted == file.IsDeleted;
        }
    }
}
