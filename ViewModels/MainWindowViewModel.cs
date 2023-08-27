using System.Windows.Input;
using Avalonia.Media.TextFormatting.Unicode;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TransitionIssue.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    [Reactive] public ViewModelBase CurrentPage { get; set; }

    public ICommand ChangePageCommand { get; private set; }


    public MainWindowViewModel()
    {
        ChangePageCommand = ReactiveCommand.Create(ChangePageExecute);
    }

    public void ChangePageExecute()
    {
        switch (CurrentPage)
        {
            case FirstPageViewModel:
                CurrentPage = new SecondPageViewModel();
                break;
            case SecondPageViewModel:
                CurrentPage = new FirstPageViewModel();
                break;
            default:
                CurrentPage = new FirstPageViewModel();
                break;
        }
    }
}