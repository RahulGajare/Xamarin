using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fundoo.Validations
{
   



    public class ConfirmPasswordValidator : Behavior<Entry>
    {
        public static readonly BindableProperty isValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(PasswordValidator), false, BindingMode.OneWayToSource);


       
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

      

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessage");

            
        }
    }
}
