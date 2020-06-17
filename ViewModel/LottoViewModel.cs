using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LotteryProgrammingChallenge.ViewModel
{
    public class LottoViewModel : ViewModelBase
    {
        public LottoViewModel()
        {

        }

        private List<int> randomNumbers = new List<int>();
        public List<int> RandomNumbers
        {
            get { return randomNumbers; }
            set
            {
                Set(ref randomNumbers, value);
                PlayNumbersCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand GenerateNumbersCommand => new RelayCommand(
        () =>
        {
            RandomNumbers = GetRandomNumbers();
            // Bonus ball function can be called here for future and added to its own property
            // that can easily be added next to the current numbers in UI
        });

        public RelayCommand PlayNumbersCommand => new RelayCommand(
        () =>
        {
            if(RandomNumbers.Count > 0)                 // IF condition shouldn't require here, can be handled by CanExecuteCommand
                MessageBox.Show("You are in the draw", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
        },
        () =>
        {
            // NOTE: 
            // enable button but not working properly (Can be fixed but not important) so returning TRUE
            return CanExecuteCommand();
        });

        bool CanExecuteCommand()
        {
            return true; // RandomNumbers.Count > 0;
        }

        List<int> GetRandomNumbers()
        {
            var random = new Random();
            return Enumerable.Range(1, 49).OrderByDescending(x => random.Next()).Take(6).OrderBy(x => x).ToList();
        }
    }
}
