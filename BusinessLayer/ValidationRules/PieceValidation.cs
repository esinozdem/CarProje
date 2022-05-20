using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PieceValidation:AbstractValidator<Piece>
    {
        public PieceValidation()
        {
            RuleFor(x => x.PieceCode).NotEmpty().WithMessage("Lütfen Parça Kodunu 00- ile Başlatınız.");
            RuleFor(x => x.PieceName).NotEmpty().WithMessage("Lütfen Eklemek istediğiniz Parça Adını Yazınız.");
        }
    }
}
