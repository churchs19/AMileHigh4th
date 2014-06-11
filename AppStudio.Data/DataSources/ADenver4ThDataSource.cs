using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ADenver4ThDataSource : IDataSource<HtmlSchema>
    {
        private IEnumerable<HtmlSchema> _data = new HtmlSchema[]
        {
            new HtmlSchema
            {
                Id = "{ea6c0185-a35a-435c-af3c-401946283e46}",
                Content = @"<b>There’s no better place to be over the 4th of July than in Denver! You’ll be treated to festivals, concerts, pro sports – and of course all the brilliant fireworks displays you could ever wish for.</b>
<br>
<br>
<br>
<img src=""http://svcdn.simpleviewinc.com/v3/cache/www_denver_org/836F57E96FBA0AAD2BECCEE1F33A242E.jpg"" alt=""Denver 4th of July"" style=""max-width:100%""/>
"
            }
        };

        public async Task<IEnumerable<HtmlSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<HtmlSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
