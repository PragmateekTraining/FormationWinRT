using LocalFolderSample.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace LocalFolderSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DataFileViewModel> dataFiles;
        public ObservableCollection<DataFileViewModel> DataFiles
        {
            get { return dataFiles; }
            set
            {
                if (value != dataFiles)
                {
                    dataFiles = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DataFiles"));
                }
            }
        }

        private DataFileViewModel selectedDataFile;
        public DataFileViewModel SelectedDataFile
        {
            get { return selectedDataFile; }
            set
            {
                if (value != selectedDataFile)
                {
                    selectedDataFile = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedDataFile"));
                }
            }
        }

        public ICommand NewDataFileCommand { get; set; }

        public MainPageViewModel()
        {
            NewDataFileCommand = new RelayCommand(NewFile);

            DataFiles = new ObservableCollection<DataFileViewModel>(ApplicationData.Current.LocalFolder.GetFilesAsync().AsTask().Result
                                                                                    .Select(sf => new DataFileViewModel { Name = sf.Name }));
        }

        private void NewFile()
        {
            string fileName = "New_" + Guid.NewGuid();

            ApplicationData.Current.LocalFolder.CreateFileAsync(fileName).AsTask().Wait();

            DataFiles.Add(new DataFileViewModel { Name = fileName });
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
