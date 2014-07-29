using LocalFolderSample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace LocalFolderSample
{
    public class DataFileViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private string content;
        public string Content
        {
            get
            {
                if (content == null)
                {
                    IsLoadingContent = true;

                    LoadContent();
                }

                return content;
            }
        }

        private bool isLoadingContent;
        public bool IsLoadingContent
        {
            get { return isLoadingContent; }
            set
            {
                if (value != isLoadingContent)
                {
                    isLoadingContent = value;

                    PropertyChanged(this, new PropertyChangedEventArgs("IsLoadingContent"));
                }
            }
        }

        public ICommand SaveCommand { get; set; }

        public DataFileViewModel()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private async Task<StorageFile> GetFile()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(Name, CreationCollisionOption.OpenIfExists);

            return file;
        }

        private async void LoadContent()
        {
            StorageFile file = await GetFile();

            content = await FileIO.ReadTextAsync(file);

            await Task.Delay(4000);

            IsLoadingContent = false;

            PropertyChanged(this, new PropertyChangedEventArgs("Content"));
        }

        private async void Save()
        {
            StorageFile file = await GetFile();

            await FileIO.WriteTextAsync(file, Content);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
