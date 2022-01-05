using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class Presenter
    {
        private Person? person = null;
        private readonly MainWindow? mainWindow = null;
        
        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            person = SaveLoad.LoadPerson();

            mainWindow.ownerChange += new EventHandler<EventArgs>(OwnerChange);
        }

        #region OwnerChange
        private void OwnerChange(object? sender, EventArgs e)
        {
            PersonInfo? personInfo = sender as PersonInfo;
            personInfo.save += new EventHandler<EventArgs>(SaveOwner);

            personInfo.GetSetName.Text = person.Name;
            personInfo.GetSetSurename.Text = person.Surname;
            personInfo.GetSetPhoneNumber.Text = person.Phone;
        }

        private void SaveOwner(object? sender, EventArgs e)
        {
            PersonInfo? personInfo = sender as PersonInfo;

            person = new Person(personInfo.GetSetName.Text,
                personInfo.GetSetSurename.Text,
                personInfo.GetSetPhoneNumber.Text);

            UpadateOwner();
        }

        private void UpadateOwner()
        {
            mainWindow.GetSetName.Text = person.Name;
            mainWindow.GetSetSurename.Text = person.Surname;
            mainWindow.GetSetPhoneNumber.Text = person.Phone;
        }
        #endregion
    }
}
