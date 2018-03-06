﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public Guid FileName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
