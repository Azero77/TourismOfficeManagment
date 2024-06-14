using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Virtualization;

namespace TourismOfficeApplication.Commands
{
    //Command Made for navigation between Pages
    public class MoveCommand<T> : CommandBase
    {
        private readonly MoveState _state;
        public MoveCommand(MoveState state)
        {
            _state = state;
        }
        public override async void Execute(object? parameter)
        {
            var args = ((object[])parameter);
            VirtualizationCollection<T> collection = (VirtualizationCollection<T>) 
              args?[0]!;
            int pageIndex = (int) args?[1]!;

            if (_state is MoveState.MoveNext)
                await collection.RenderPage(pageIndex + 1);
            else
                await collection.RenderPage(pageIndex - 1);
        }
        public override bool CanExecute(object? parameter)
        {
            var args = (object[])parameter!;
            int pageIndex = (int)args?[1]!;
            int MaxPageIndex = (int)args?[2]!;
            if (_state is MoveState.MoveNext && pageIndex != MaxPageIndex - 1)
                return true;
            if (_state is MoveState.MovePrevoius && pageIndex != 0)
                return true;
            return false;
        }
    }

}
