using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EasyMVVM
{
    public class Model
    {
        public Model()
        {
            _data = new ObservableCollection<string>(new[]
            {
                "First Entry", "Second Entry", "Third Entry"
            });
        }

        private ObservableCollection<string> _data;

        public ObservableCollection<string> GetData() => _data;
    }
}
