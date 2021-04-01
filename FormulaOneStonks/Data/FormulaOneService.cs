using FormulaOneStonks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace FormulaOneStonks.Data
{
    public class FormulaOneService
    {
        private static HttpClient client = new HttpClient();

        public async Task<Player[]> GetDriversAsync()
        {
            DriverCollection result = null;
            var url = string.Format("{0}/{1}", Common.Constants.BaseApiUrl, Common.Constants.PlayersApiUrl);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<DriverCollection>();
            }

            return result?.players;
        }
    }
}