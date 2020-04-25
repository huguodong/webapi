using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hgd.webapi.Models
{

    [Validator(typeof(PersonValidator))]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

        public string Say()
        {
            return "I'm Person Class";
        }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(m => m.Id).NotEmpty().NotNull().WithMessage("Id不能为空");
            RuleFor(m => m.Name).NotEmpty().NotNull().WithMessage("Name不能为空");
        }
    }


}