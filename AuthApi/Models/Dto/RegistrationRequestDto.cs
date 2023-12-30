namespace AuthApi.Models.Dto
{
	public class RegistrationRequestDto
	{

        public int ID { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; } 
		public string Phonenumber { get; set; }
		
    }
}
