using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Virtualization;

namespace TourismOfficeApplication.Commands
{
    //Command Made for navigation between Pages
    public class MoveCommand<T> : CommandBase
    {
        

        public MoveCommand( )
        {
        }
        public override async void Execute(object? parameter)
        {
            var args = ((object[])parameter);
            VirtualizationCollection<T> collection = (VirtualizationCollection<T>) 
              args?[0]!;
            int pageIndex = (int) args?[1]!;

            await collection.RenderPage(pageIndex);
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        }
    }

}
