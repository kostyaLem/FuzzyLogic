namespace FuzzyLogic.DAL.Services
{
    public interface IValidator<T>
    {
        void Validate(T value);
    }
}
