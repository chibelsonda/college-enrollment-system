using Microsoft.AspNetCore.Identity;

namespace CollegeEnrollmentSystem.Helpers
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string hash, string password);
    }

    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<string> _hasher = new();

        public string Hash(string password)
            => _hasher.HashPassword(null!, password);

        public bool Verify(string hash, string password)
            => _hasher.VerifyHashedPassword(null!, hash, password)
               == PasswordVerificationResult.Success;
    }
}
