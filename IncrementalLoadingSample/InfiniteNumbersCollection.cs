using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace IncrementalLoadingSample
{
    public class InfiniteNumbersCollection :
        ObservableCollection<string>,
        ISupportIncrementalLoading
    {
        public bool HasMoreItems
        {
            get { return true; }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            SynchronizationContext context = SynchronizationContext.Current;

            return Task.Run(() =>
                {
                    long from = this.Count + 1;
                    long to = this.Count + 1 + count;

                    for (long i = from; i < to; ++i)
                    {
                        Task.Delay(50).Wait();

                        long j = i;
                        DateTime now = DateTime.Now;

                        context.Post(o => this.Add(string.Format("{0} [{1:hh:mm:ss.fff}]", j, now)), null);
                    }

                    return new LoadMoreItemsResult { Count = count };
                }).AsAsyncOperation();
        }
    }
}
