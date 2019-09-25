using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel_of_Azure_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        System.Media.SoundPlayer player;
        public ShellViewModel()
        {
            player =
                new System.Media.SoundPlayer(@"C:\Users\v-deree\Projects\azureRefactor\Wheel of Azure\Wheel of Azure UI\Sounds\theme.wav");
            player.Play();
        }

        public void StartButton()
        {
            player.Stop();
            ActivateItem(new GameViewModel());
        }  
    }
}
