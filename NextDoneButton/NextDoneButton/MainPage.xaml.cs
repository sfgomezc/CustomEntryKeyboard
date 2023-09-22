using NextDoneButton.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NextDoneButton
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private void Handle_Completed(object sender, System.EventArgs e)
        {
            var tabs = Layout.GetTabIndexesOnParentPage(out int count);
            var visual = sender as Xamarin.Forms.VisualElement;
            var currentIndex = visual.TabIndex;
            var nextFocus = Layout.FindNextElement(true, tabs, ref currentIndex);

            (nextFocus as Xamarin.Forms.VisualElement)?.Focus();
        }
    }
}
