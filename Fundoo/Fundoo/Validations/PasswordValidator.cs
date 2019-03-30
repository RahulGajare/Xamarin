using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Fundoo.Validations
{
   public class PasswordValidator : Behavior<Entry>
    {
        const string passwordRegex = "^(?=.*\\d).{4,8}$";

        public static readonly BindableProperty isValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(PasswordValidator), false,BindingMode.OneWayToSource);

      

        public bool IsValid
        {
            get { return (bool) GetValue(isValidProperty); }
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
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessagePassword");

            bool isValid = Regex.IsMatch(e.NewTextValue, passwordRegex);
            IsValid = isValid;

            if (isValid)
            {
                ((Entry)sender).TextColor = Color.Default;
                errorLabel.Text = "";
            }
            else
            {
                ((Entry)sender).TextColor = Color.Red;
                errorLabel.Text = "Passowrd length should be between 4-8 and should consist atleast one numeric";
            }
            
        }
    }
}
