using KursProjectISP31.Model;
using KursProjectISP31.Utills;
using KursProjectISP31.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProjectISP31.ViewModel
{
    public class AuthorViewModel:ViewModelBase
    {
        public ObservableCollection<Author> Authors { get; set; }
        public AuthorViewModel()
        {
            Load();
        }
        private void Load()
        {
            using (KursovayaContext db=new KursovayaContext())
            {
                Authors = new ObservableCollection<Author>(db.Authors.ToList());
            }
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      AuthorWindow window = new AuthorWindow(new Author());
                      if (window.ShowDialog() == true)
                      {
                          using (KursovayaContext db=new KursovayaContext())
                          {
                              db.Authors.Add(window.Author);
                              db.SaveChangesAsync();
                              Authors.Add(window.Author);
                          }
                      }
                  }));
            }
        }
    }
}
