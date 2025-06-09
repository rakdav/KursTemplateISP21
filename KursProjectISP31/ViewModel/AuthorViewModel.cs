using KursProjectISP31.Model;
using KursProjectISP31.Utills;
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
    }
}
