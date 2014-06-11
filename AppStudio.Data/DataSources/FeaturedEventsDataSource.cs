using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FeaturedEventsDataSource : IDataSource<FeaturedEventsSchema>
    {
        private readonly IEnumerable<FeaturedEventsSchema> _data = new FeaturedEventsSchema[]
		{
		};

        public async Task<IEnumerable<FeaturedEventsSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<FeaturedEventsSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
