using FriendOrganizer.Model;
using System;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }

        public int Id => Model.Id;

        public string FirstName
        {
            get => GetValue<string>();
            set => SetValue<string>(value);
        }
        public string LastName
        {
            get => GetValue<string>();
            set => SetValue<string>(value);
        }
        public string Email
        {
            get => GetValue<string>();
            set => SetValue<string>(value);
        }

        protected override IEnumerable<string> GetCustomValidationErrors(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                        yield return "Robots are not allowd";
                    break;
                default:
                    break;
            }
        }
    }
}
