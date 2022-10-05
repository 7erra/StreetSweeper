using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StreetSweeper.Core;

namespace StreetSweeper.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public static readonly Color ValidPathItemColor = Color.FromRgb(20, 20, 20);
        public static readonly Color DeletedPathItemColor = Color.FromRgb(200, 0, 0);
        public static readonly Color DuplicatePathItemColor = Color.FromRgb(0, 0, 115);

        public Array Environments { get; } = Enum.GetValues(typeof(EnvironmentVariableTarget));

        EnvironmentVariableTarget _currentEnvironment = EnvironmentVariableTarget.User;
        public EnvironmentVariableTarget CurrentEnvironment
        {
            get => _currentEnvironment;
            set
            {
                SetProperty(ref _currentEnvironment, value);
                Paths = new(value);
            }
        }

        [ObservableProperty]
        PathList _paths = new(EnvironmentVariableTarget.Process);

        [ObservableProperty]
        bool _doRemoveDuplicates, _doRemoveDeleted;

        [RelayCommand]
        void ToggleAttribute(string attribute)
        {
            var property = GetType().GetProperty(attribute, typeof(bool));
            var currentState = (bool)property.GetValue(this);
            property.SetValue(this, !currentState, null);
        }

        [RelayCommand]
        void Execute()
        {
            if (DoRemoveDuplicates) Cleaner.RemoveDuplicates(CurrentEnvironment);
            if (DoRemoveDeleted) Cleaner.RemoveDeleted(CurrentEnvironment);
            Paths = new(CurrentEnvironment);
        }
    }
}
