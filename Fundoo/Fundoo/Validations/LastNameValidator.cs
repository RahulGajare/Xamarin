using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Fundoo.Validations
{
   public  class LastNameValidator : Behavior<Entry>
    {
        const string userNameRegex = "^[A-z a - z 0 - 9]{3,15}$";

        public static readonly BindableProperty isValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(LastNameValidator), false, BindingMode.OneWayToSource);



        public bool IsValid
        {
            get { return (bool)GetValue(isValidProperty); }
            set { this.SetValue(isValidProperty, value); }

        }
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += HandleTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessageLastName");

            bool isValid = Regex.IsMatch(e.NewTextValue, userNameRegex);
            IsValid = isValid;

            if (isValid)
            {
                ((Entry)sender).TextColor = Color.Green;
                errorLabel.Text = "";
            }
            else
            {
                ((Entry)sender).TextColor = Color.Red;
                errorLabel.Text = "Length should be atleast 3-15 and should not contain characters";
            }

        }
    }
}
