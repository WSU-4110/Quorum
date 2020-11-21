using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quorum.Data.UserModels;

namespace Quorum.Data.Validators
{
    public class ForumValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object forumTitle, ValidationContext validationContext)
        {
            ForumView forumView = (ForumView)validationContext.ObjectInstance;
            string parentForumTitle = forumView.ParentForumTitle;

            //If titles are the same return error
            if (forumTitle.ToString().ToLower().Equals(parentForumTitle.ToLower()))
            {
                return new ValidationResult($"Quorum title cannot be the same as parent title '{parentForumTitle}'",
                    new[] { validationContext.MemberName });
            }
            //Else return success
            return ValidationResult.Success;
        }
    }
}
