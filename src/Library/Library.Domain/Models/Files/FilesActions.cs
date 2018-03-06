using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Models
{
    public class FilesActions
    {
        public Guid Id { get; set; }
        public File File { get; set; }
        public Employee Employee { get; set; }
        public FileAction Action { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public enum FileAction
    {
        Upload, Download, Delete
    }
}
