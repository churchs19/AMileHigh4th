using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FreeEventsDataSource : IDataSource<RssSchema>
    {
        private const string _url =  @"http://www.denver.org/includes/cfcs/syndication/RSS/rssManager.cfc?method=showFeed&feedType=events&e_catID=61";

        private IEnumerable<RssSchema> _data = null;

        public FreeEventsDataSource()
        {
        }

        public async Task<IEnumerable<RssSchema>> LoadData()
        {
            if (_data == null)
            {
                try
                {
                    var rssDataProvider = new RssDataProvider(_url);
                    _data = await rssDataProvider.Load();
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("FreeEventsDataSourceDataSource.LoadData", ex.ToString());
                }
            }
            return _data;
        }

        public async Task<IEnumerable<RssSchema>> Refresh()
        {
            _data = null;
            return await LoadData();
        }
    }
}
