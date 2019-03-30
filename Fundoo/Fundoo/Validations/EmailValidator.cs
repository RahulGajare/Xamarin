using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Fundoo.Validations
{
    class EmailValidator : Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly BindableProperty isValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EmailValidator), false, BindingMode.OneWayToSource);



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
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessageEmail");

            bool isValid = Regex.IsMatch(e.NewTextValue, emailRegex);
            IsValid = isValid;

            if (isValid)
            {
                ((Entry)sender).TextColor = Color.Green;
                errorLabel.Text = "";
            }
            else
            {
                ((Entry)sender).TextColor = Color.Red;
                errorLabel.Text = "Invalid email format";
            }

        }
    }
}
