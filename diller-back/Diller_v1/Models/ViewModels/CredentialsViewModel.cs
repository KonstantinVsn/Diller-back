using Diller.Models.ViewModels.Validator;
using FluentValidation.Attributes;

namespace Diller.Models.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
