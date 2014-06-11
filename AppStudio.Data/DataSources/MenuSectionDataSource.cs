using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class MenuSectionDataSource : IDataSource<MenuSchema>
    {
        private readonly IEnumerable<MenuSchema> _data = new MenuSchema[]
		{
            new MenuSchema
            {
                Type = "Url",
                Title = "Official web",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "http://www.denvergov.org",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "Visit Denver",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "http://www.denver.org",
            },
            new MenuSchema
            {
                Type = "Url",
                Title = "Offers",
                Icon = "/Assets/DataImages/menuitem-icon.png",
                Target = "http://www.denver.org/about-denver/deals-discounts/",
            },
		};

        public async Task<IEnumerable<MenuSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<MenuSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
