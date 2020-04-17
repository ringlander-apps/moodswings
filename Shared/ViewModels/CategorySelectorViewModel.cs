using System.ComponentModel;
using System.Collections.Generic;
using MoodSwings.Shared.Models;

namespace MoodSwings.Shared.ViewModels
{
    public class SelectCategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> _categories = new List<string> { "Artist", "Playlist" };

        public List<string> AvailableCategories
        {
            get => _categories;
            set { _categories = value; }
        }
        private string _selectedCategory = "Artist";
        public string SelectedCategory
        {
            get => _selectedCategory;
            set { _selectedCategory = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCategory))); }
        }

        public void SetCategory(string category)
        {
            if (_selectedCategory != category)
            {
                SelectedCategory = category;

            }
        }

    }

}