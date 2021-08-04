using AdapterPattern.Adapter;
using AdapterPattern.Command;
using AdapterPattern.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdapterPattern.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<User> Users { get; set; }

        private User _user;

        public User User { get { return _user; } set { _user = value; OnpropertyChanged(); } }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ViewCommand { get; set; }

        public MainWindow MainWindow { get; set; }

        public MainViewModel()
        {
            XML XML_File = new XML();
            JSON JSON_File = new JSON();


            if (XML_File.User_List == null)
            {
                XML_File.User_List = new ObservableCollection<User>();
            }

            if (JSON_File.User_List == null)
            {
                JSON_File.User_List = new ObservableCollection<User>();
            }

            User = new User
            {
                Name = "Name",
                Surename = "Surename",
                Email = "Email",
            };

            SaveCommand = new RelayCommand((e) =>
            {
                IAdapter adapter;

                if (Helper.MainWindow.xmlCheckbox.IsChecked == true)
                {
                    try
                    {
                        if (XML_File.User_List == null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = Helper.MainWindow.nameTxtb.Text,
                                Surename = Helper.MainWindow.surenameTxtb.Text,
                                Email = Helper.MainWindow.mailTxtb.Text,
                            });

                            XML_File.User_List.RemoveAt(0);

                            adapter = new XMLAdapter(XML_File);

                            App1 application = new App1(adapter);

                            application.Start();
                        }

                        if (XML_File.User_List != null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = Helper.MainWindow.nameTxtb.Text,
                                Surename = Helper.MainWindow.surenameTxtb.Text,
                                Email = Helper.MainWindow.mailTxtb.Text,
                            });

                            adapter = new XMLAdapter(XML_File);

                            App1 application = new App1(adapter);

                            application.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                if (Helper.MainWindow.jsonCheckbox.IsChecked == true)
                {
                    try
                    {
                        if (JSON_File.User_List == null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = Helper.MainWindow.nameTxtb.Text,
                                Surename = Helper.MainWindow.surenameTxtb.Text,
                                Email = Helper.MainWindow.mailTxtb.Text,
                            });

                            JSON_File.User_List.RemoveAt(0);

                            adapter = new JSONAdapter(JSON_File);

                            App1 application = new App1(adapter);

                            application.Start();
                        }

                        if (JSON_File.User_List != null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = Helper.MainWindow.nameTxtb.Text,
                                Surename = Helper.MainWindow.surenameTxtb.Text,
                                Email = Helper.MainWindow.mailTxtb.Text,
                            });

                            adapter = new JSONAdapter(JSON_File);

                            App1 application = new App1(adapter);

                            application.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            });
        }
    }
}
