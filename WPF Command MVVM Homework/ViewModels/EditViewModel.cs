using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Command_MVVM_Homework.Models;

namespace WPF_Command_MVVM_Homework.ViewModels {
    public class EditViewModel {

        public Car? selectedCar { get; set; }
        
        public EditViewModel() {

        }

        public EditViewModel(Car? car) {
            selectedCar = car;
        }
    }
}
