﻿namespace WinUX.UWP.Samples.Samples.Controls.Stepper
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class StepperSamplePage
    {
        public StepperSamplePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Fired when the page has been navigated to.
        /// </summary>
        /// <param name="e">
        /// The navigation parameters.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (AppShell.Instance != null && AppShell.Instance.ViewModel != null)
            {
                AppShell.Instance.ViewModel.Title = "Stepper sample";
            }

            var bindingSource = this.Sample.BindingSource;

            this.Properties.Visibility = bindingSource != null
                                             ? (bindingSource.Properties.Count > 0
                                                    ? Visibility.Visible
                                                    : Visibility.Collapsed)
                                             : Visibility.Collapsed;

            if (bindingSource != null)
            {
                this.Content.DataContext = bindingSource.Bindings;
            }
        }
    }
}
