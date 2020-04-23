using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MinimalMVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private IPresenter currPresenter;
        private string converterType;

        public MainWindowViewModel()
        {
            this.currPresenter = new Presenter();
            this.ConverterType = nameof(Presenter);
        }

        public string ConverterType
        {
            get => converterType;
            set
            {
                this.converterType = "Presenter type: " + value;
                RaisePropertyChangedEvent("ConverterType");
            }
        }

        public IPresenter Presenter
        {
            get => currPresenter;
            set
            {
                this.currPresenter = value;
                RaisePropertyChangedEvent("Presenter");
            }
        }

        public ICommand ChangeConverterCommand
        {
            get { return new DelegateCommand(ChangeConverter); }
        }

        private void ChangeConverter()
        {
            if (currPresenter is CustomPresenter)
            {
                Presenter = new Presenter(Presenter.History);
                this.ConverterType = nameof(Presenter);
            }
            else
            {
                Presenter = new CustomPresenter(Presenter.History);
                this.ConverterType = nameof(CustomPresenter);
            }
        }
    }
}
