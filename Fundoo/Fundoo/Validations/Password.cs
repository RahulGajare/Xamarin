using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Fundoo.Validations
{
   public class Password : Behavior<Entry>
    {
        const string passwordRegex = "^(?=.*\\d).{4,8}$";

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
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessage");

            bool isValid = Regex.IsMatch(e.NewTextValue, passwordRegex);

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
