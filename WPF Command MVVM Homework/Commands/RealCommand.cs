using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Command_MVVM_Homework.Commands {
    public class RealCommand : ICommand {

        public event EventHandler? CanExecuteChanged;


        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;


        public RealCommand(Action<object?> execute, Predicate<object?>? canExecute = null) {
            ArgumentNullException.ThrowIfNull(execute, nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);
    }
}
