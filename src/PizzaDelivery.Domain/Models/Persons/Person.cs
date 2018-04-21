using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Domain.Models.Persons
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        /*[StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }*/

        [Required]
        [StringLength(100)]
        //[Display(Prompt ="ФИО")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Description = "Логин")]
        public string Login { get; set; }

        //[Display(Description = "Дата рождения")]
        public DateTime? Birthday { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        //[Display(Description = "Тел. номер")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        //[Display(Description = "Эл. адрес")]
        public string Email { get; set; }

        [StringLength(200)]
        //[Display(Description = "Адрес доставки")]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        //[Display(Description = "Пароль")]
        public string Password { get; set; }
    }
}
