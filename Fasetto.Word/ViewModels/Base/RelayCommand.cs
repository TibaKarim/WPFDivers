using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class RelayCommand : ICommand
    {
        #region private members
        private readonly Action mAction;
        #endregion
        #region public event
        public event EventHandler CanExecuteChanged=(sender,e)=> { };
        #endregion
        public bool CanExecute(object parameter)
        {
            return true;
        }
        #region Constructeur
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion
        #region Command Methode
        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
