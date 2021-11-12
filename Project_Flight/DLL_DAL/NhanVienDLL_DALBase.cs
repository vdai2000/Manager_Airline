namespace DLL_DAL
{
    public class NhanVienDLL_DALBase
    {

        public async Task<List<UserModel>> GetUserModels()
        {
            _response = await _client.GetAsync($"/USER");

            var json = await _response.Content.ReadAsStringAsync();
            var listUser = JsonConvert.DeserializeObject<List<UserModel>>(json);
            return listUser;
        }
    }
}