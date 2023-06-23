using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Command_MVVM_Homework.Commands;
using WPF_Command_MVVM_Homework.Models;
using WPF_Command_MVVM_Homework.Views;

namespace WPF_Command_MVVM_Homework.ViewModels {

    public class MainViewModel {

        public Car? selectedCar;
        public ICommand? ShowCommand { get; set; }
        public ICommand? SaveCommand { get; set; }
        public ICommand? EditCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }

        public MainViewModel() { 
        
            ShowCommand = new RealCommand(Show);
        }
        
        public void Show(object? param) {
            ShowView showView = new();
            showView.DataContext = new ShowViewModel(selectedCar);

            showView.ShowDialog();  
        }

    }
}
