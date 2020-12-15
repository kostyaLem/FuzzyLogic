using DevExpress.Mvvm;
using System;

namespace FuzzyLogic.UI.ViewModels
{
    public sealed class AuthViewModel : NamedViewModel
    {
        public override string Title => "Авторизация";
    }

    public abstract class NamedViewModel : ViewModelBase
    {
        public abstract string Title { get; }

        public virtual string Description { get; protected set; }
    }
}
