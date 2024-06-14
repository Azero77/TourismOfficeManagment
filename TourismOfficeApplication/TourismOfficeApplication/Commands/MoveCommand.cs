using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Virtualization;

namespace TourismOfficeApplication.Commands
{
    //Command Made for navigation between Pages
    public class MoveCommand<T> : CommandBase
    {
        private readonly MoveState _state;
        public MoveCommand(MoveState state, Action<int> action)
        {
            _state = state;
            Moved += action;
        }
        public override async void Execute(object? parameter)
        {
            var args = ((object[])parameter);
            VirtualizationCollection<T> collection = (VirtualizationCollection<T>) 
              args?[0]!;
            int pageIndex = (int) args?[1]!;
            int newPage;
            if (_state is MoveState.MoveNext)
                newPage = (pageIndex + 1);
            else if (_state is MoveState.MovePrevoius)
                newPage = (pageIndex - 1);
            else
                newPage = pageIndex;
            await collection.RenderPage(newPage);
            OnMoved(newPage);
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

        //for CurrentPage Info
        
        public event Action<int> Moved;
        public void OnMoved(int pageIndex)
        {
            Moved?.Invoke(pageIndex);
        }

    }

}
