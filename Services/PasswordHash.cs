﻿
using System.Security.Cryptography;


public class PasswordHash
{
    public static string HashPassword(string password, out byte[] salt)
    {
        const int keySize = 32;
        const int iterations = 20000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

        salt = new byte[keySize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
        byte[] hash = pbkdf2.GetBytes(keySize);
        return Convert.ToHexString(hash);
    }
    public static bool Authenticate(string enteredPassword, string storedPasswordHash, string storedSalt)
    {
        const int keySize = 32;
        const int iterations = 100000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

        byte[] salt = Convert.FromHexString(storedSalt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, iterations, hashAlgorithm))
        {
            byte[] enteredPasswordHash = pbkdf2.GetBytes(keySize);
            string enteredPasswordHashString = Convert.ToHexString(enteredPasswordHash);

            return string.Equals(enteredPasswordHashString, storedPasswordHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
