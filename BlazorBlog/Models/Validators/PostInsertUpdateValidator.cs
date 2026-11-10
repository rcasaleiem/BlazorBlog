using BlazorBlog.Models.Dtos;
using BlazorBlog.Models.Tables;
using FluentValidation;


namespace BlazorBlog.Models.Validators
{
    public class PostInsertUpdateValidator : AbstractValidator<PostInsertUpdateDto>
    {
        private readonly BlogDBContext _context;

        public PostInsertUpdateValidator(BlogDBContext context)
        {
            _context = context; 

            RuleFor(x => x.content)
                .NotEmpty()
                .WithMessage("Content path is mandatory")
                .Matches(@"^[^\\/]+\\[^\\/]+$")
                .WithMessage("Content path must be in the format 'folder\\file' (e.g. Texts\\myFile)");
        }

    }
}
