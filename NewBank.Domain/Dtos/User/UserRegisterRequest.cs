namespace NewBank.Domain.Dtos.User
{
    public class UserRegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(FirstName))
                throw new Exception("Nome não pode ser nulo");

            if (String.IsNullOrEmpty(LastName))
                throw new Exception("Nome não pode ser nulo");

            if (String.IsNullOrEmpty(Cpf))
                throw new Exception("Nome não pode ser nulo");

            if (String.IsNullOrEmpty(Username))
                throw new Exception("Nome não pode ser nulo");

            if (String.IsNullOrEmpty(Password))
                throw new Exception("Nome não pode ser nulo");

            if (String.IsNullOrEmpty(Email))
                throw new Exception("Nome não pode ser nulo");

            if (String.IsNullOrEmpty(Phone))
                throw new Exception("Nome não pode ser nulo");
        }
    }
}
