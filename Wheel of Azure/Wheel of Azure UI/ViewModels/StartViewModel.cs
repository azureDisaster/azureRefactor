using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel_of_Azure_UI.ViewModels
{
    public class StartViewModel: Screen
    {
        public StartViewModel()
        {
            System.Media.SoundPlayer player = 
                new System.Media.SoundPlayer(@"C:\Users\v-deree\Projects\azureRefactor\Wheel of Azure\Wheel of Azure UI\Sounds\theme.wav");
            player.Play();
        }
    }
}
