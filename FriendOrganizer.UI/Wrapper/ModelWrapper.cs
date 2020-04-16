using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.UI.Wrapper
{
    public abstract class ModelWrapper<T> : BaseNotifyDataError
    {
        public T Model { get; }
        public ModelWrapper(T model)
        {
            Model = model;
        }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected void SetValue<TValue>(object value, [CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged(propertyName);
            ValidateInternalError(propertyName, value);
        }
        protected virtual IEnumerable<string> GetCustomValidationErrors(string propertyName)
        {
            return null;
        }

        private void ValidateInternalError(string propertyName, object value)
        {
            ClearErrors(propertyName);
            ValidateCustomErrors(propertyName);
            ValidateAnnotationError(propertyName, value);

        }

        private void ValidateCustomErrors(string propertyName)
        {
            ClearErrors(propertyName);
            var errors = GetCustomValidationErrors(propertyName);

            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }

        }

        private void ValidateAnnotationError(string propertyName, object value)
        {
            var context = new ValidationContext(Model) { MemberName = propertyName };
            var validationResult = new List<ValidationResult>();

            Validator.TryValidateProperty(value, context, validationResult);
            foreach (var result in validationResult)
            {
                AddError(propertyName, result.ErrorMessage);
            }
        }






    }
}
