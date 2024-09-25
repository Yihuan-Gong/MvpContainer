using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpContainer
{
    internal class Presenter : IPresenter
    {
        private readonly IView _view;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Show()
        {
            _view.Show("Hello world");
        }
    }
}
