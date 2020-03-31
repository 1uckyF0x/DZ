using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.IO;

namespace Lesson.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {

            this.Names = new ObservableCollection<string>();


        }

        public string Name
        {
            get;
            set;
        }
        public ObservableCollection<string> Names { get; set; }

        private RelayCommand _commandAdd;
        public ICommand AddElementCommand
        {
            get
            {
                if (_commandAdd == null)
                {
                    _commandAdd = new RelayCommand(() => AddElement());
                }
                return _commandAdd;
            }
        }
        private void AddElement()
        {
            this.Names.Add(this.Name);
        }

        string writePath = @"C:\new.txt";


        

        private RelayCommand _commandSave;
        public ICommand SaveElementCommand 
        {
           
            get
            {
                if (_commandSave == null)
                {
                    _commandSave = new RelayCommand(() => SaveElement());
                }
                return _commandSave;
            }

        }
        
        private void SaveElement()
        {
           
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        for (var i = 0; i < this.Names.Count; i++)
                            sw.WriteLine(Names[i]);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
           
        }

    }

           




    
}
