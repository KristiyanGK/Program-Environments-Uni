using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class Presenter : ObservableObject, IPresenter
    {
        private readonly TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        private string _someText;
        private readonly ObservableCollection<string> _history;

        public Presenter()
        {
            this._history = new ObservableCollection<string>();
        }

        public Presenter(IEnumerable<string> history)
        {
            this._history = new ObservableCollection<string>(history);
        }

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        private void ConvertText()
        {
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = String.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
