using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PhotosDataSource : IDataSource<PhotosSchema>
    {
        private const string _appId = "52af1879-54ae-4c2b-b21a-1ffde7285b02";
        private const string _dataSourceName = "a23834a1-0e83-4ba8-9d5a-fdbfcd8ef6c4";

        private IEnumerable<PhotosSchema> _data = null;

        public PhotosDataSource()
        {
        }

        public async Task<IEnumerable<PhotosSchema>> LoadData()
        {
            if (_data == null)
            {
                try
                {
                    var serviceDataProvider = new ServiceDataProvider(_appId, _dataSourceName);
                    _data = await serviceDataProvider.Load<PhotosSchema>();
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("PhotosDataSource.LoadData", ex.ToString());
                }
            }
            return _data;
        }

        public async Task<IEnumerable<PhotosSchema>> Refresh()
        {
            _data = null;
            return await LoadData();
        }
    }
}
