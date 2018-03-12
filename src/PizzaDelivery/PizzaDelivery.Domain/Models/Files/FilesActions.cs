using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDelivery.Domain.Models
{
    public class FilesActions
    {
        public Guid Id { get; set; }
        public File File { get; set; }
        public Person Person { get; set; }
        public FileAction Action { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public enum FileAction
    {
        Upload, Download, Delete
    }
}
