// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirstNameValidator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Rahul Gajare"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundoo.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Xamarin.Forms;

    /// <summary>
    /// FirstNameValidator Class
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Behavior{Xamarin.Forms.Entry}" />
    public class FirstNameValidator : Behavior<Entry>
    {
        /// <summary>
        /// The user name regex
        /// </summary>
        public const string UserNameRegex = "^[A-z a - z 0 - 9]{3,15}$";

        /// <summary>
        /// The is valid property
        /// </summary>
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(FirstNameValidator), false, BindingMode.OneWayToSource);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FirstNameValidator"/> is IsValid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { this.SetValue(IsValidProperty, value); }
        }

        /// <summary>
        /// Handles the text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        public void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessageFirstName");

            bool isValid = Regex.IsMatch(e.NewTextValue, UserNameRegex);
            this.IsValid = isValid;

            if (isValid)
            {
                ((Entry)sender).TextColor = Color.Green;
                errorLabel.Text = string.Empty;
            }
            else
            {
                ((Entry)sender).TextColor = Color.Red;
                errorLabel.Text = "Length should be atleast 3-15 and should not contain characters";
            }
        }

        /// <summary>
        /// Attaches to the superclass and then calls the <see cref="M:Xamarin.Forms.Behavior`1.OnAttachedTo(`0)" /> method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += this.HandleTextChanged;
        }

        /// <summary>
        /// Calls the <see cref="M:Xamarin.Forms.Behavior`1.OnDetachingFrom(`0)" /> method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= this.HandleTextChanged;
        }
    }
}