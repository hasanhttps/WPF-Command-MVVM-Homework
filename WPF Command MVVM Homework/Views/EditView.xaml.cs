using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Command_MVVM_Homework.ViewModels;

namespace WPF_Command_MVVM_Homework.Views {
    public partial class EditView : Window {
        public EditView() {

            InitializeComponent();
            DataContext = new EditViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
