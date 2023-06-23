using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Command_MVVM_Homework.Commands;
using WPF_Command_MVVM_Homework.Models;
using WPF_Command_MVVM_Homework.Views;
using System.Windows.Controls.Primitives;

namespace WPF_Command_MVVM_Homework.ViewModels {

    public class MainViewModel {

        private string path = "C:\\Users\\Public\\Downloads\\";

        public ObservableCollection<Car> Cars { get; set; }
        public Car? selectedCar { get; set; }
        public ICommand? ShowCommand { get; set; }
        public ICommand? SaveCommand { get; set; }
        public ICommand? EditCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }

        public MainViewModel() { 
            Cars = new ObservableCollection<Car> { 
                new Car() { Id = 0, Name = "Tesla X", Maker = "Tesla", Model = "X", Engine = "V12", Year = 2022 },
                new Car() { Id = 1, Name = "Mazda CX-5", Maker = "Mazda", Model = "CX-5", Engine = "V6", Year = 2020 }
            };

            SaveCommand = new RealCommand(Save);
            ShowCommand = new RealCommand(Show);
            EditCommand = new RealCommand(Edit);
            DeleteCommand = new RealCommand(Delete);
        }

        public void Show(object? param) {
            ShowView showView = new();
            showView.DataContext = new ShowViewModel(selectedCar);

            showView.ShowDialog();
        }

        public void Edit(object? param) {
            EditView editView = new();
            editView.DataContext = new EditViewModel(selectedCar);

            editView.ShowDialog();
        }

        public void Delete(object? param) { 
            Cars.Remove(selectedCar!);
        }
        public void Save(object? param) {

            try {
                JsonSerializerOptions op = new JsonSerializerOptions();
                op.WriteIndented = true;
                File.WriteAllText(path + selectedCar!.Name + ".json", JsonSerializer.Serialize(selectedCar, op));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                MessageBox.Show($"Your file saved sucsessfully at {path} location.");
            }
        }
    }
}
