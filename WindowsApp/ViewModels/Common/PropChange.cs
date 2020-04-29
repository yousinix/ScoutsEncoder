using System.Linq;

namespace WindowsApp.ViewModels.Common
{
    public class PropChange
    {
        private readonly ViewModelBase _viewModel;

        public PropChange(ViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }

        public PropChange WithDependents(params string[] names)
        {
            if (_viewModel != null)
                names.ToList().ForEach(p => _viewModel.OnPropertyChanged(p));
            return this;
        }
    }
}