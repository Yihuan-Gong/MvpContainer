using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpContainer
{
    public interface IView
    {
        void Show(string msg);
    }
}
