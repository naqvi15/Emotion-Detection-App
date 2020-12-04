using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmotionDetection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tab : TabbedPage
    {
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public Tab()
        {
            InitializeComponent();
        }
    }
}