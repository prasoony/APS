namespace AuthApi.Models.Dto
{
	public class LoginRequestDto
	{

        public UserDto user { get; set; }
		public string token { get; set; }
		
    }
}
