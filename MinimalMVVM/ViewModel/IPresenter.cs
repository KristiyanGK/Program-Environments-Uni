using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MinimalMVVM.ViewModel
{
    public interface IPresenter
    {
        string SomeText { get; set; }
        IEnumerable<string> History { get; }

        ICommand ConvertTextCommand { get; }
    }
}
