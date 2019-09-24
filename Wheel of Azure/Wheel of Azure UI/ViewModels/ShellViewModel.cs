using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel_of_Azure_UI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(new StartViewModel());
        }
    }
}
