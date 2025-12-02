using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using Org.BouncyCastle.Security;
using Pariah_Cybersecurity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Walker.Crypto;
using WISecureData;
using static Pariah_Cybersecurity.DataHandler;

namespace PariahCybersecTest
{
    internal class TestRunner
    {
        public class Operation
        {
            public string OperationName { get; set; }
            public string Description { get; set; }
            public string YorhaSect { get; set; }
            public List<Operator> Operators { get; set; }  // Changed to Operator class for more detailed information
            public Dictionary<string, string>? ATypeOperators { get; set; }
            public Dictionary<string, string>? BTypeOperators { get; set; }
            public Dictionary<string, string>? DTypeOperators { get; set; }
            public Dictionary<string, string>? ETypeOperators { get; set; }
            public Dictionary<string, string>? GTypeOperators { get; set; }
            public Dictionary<string, string>? HTypeOperators { get; set; }
            public Dictionary<string, string>? OTypeOperators { get; set; }
            public Dictionary<string, string>? STypeOperators { get; set; }

            // New types based on the Nier universe
            public List<Enemy> Enemies { get; set; }
            public List<Weapon> Weapons { get; set; }

            // Adding more test values
            public bool IsActive { get; set; }
            public int MaxLevel { get; set; }
            public double Difficulty { get; set; }
            public float AttackSpeed { get; set; }
            public DateTime CreatedAt { get; set; }

            public Operation()
            {
                // Test Data
                OperationName = "Operation 1";
                Description = "This is a test operation.";
                YorhaSect = "Sect A";

                // Nier-based Operators with nicknames
                Operators = new List<Operator>
        {
            new Operator { Name = "2B", Nickname = "The Silent Protector", Role = "Attacker" },
            new Operator { Name = "9S", Nickname = "The Curious Hacker", Role = "Support" },
            new Operator { Name = "A2", Nickname = "The Lone Wolf", Role = "Assault" },
            new Operator { Name = "9S (Scanner)", Nickname = "The Investigator", Role = "Recon" },
            new Operator { Name = "3C", Nickname = "The Stealth Specialist", Role = "Stealth" }
        };

                ATypeOperators = new Dictionary<string, string>
        {
            { "A1", "2B" },
            { "A2", "9S" }
        };
                BTypeOperators = new Dictionary<string, string>
        {
            { "B1", "A2" },
            { "B2", "9S" }
        };
                DTypeOperators = new Dictionary<string, string>
        {
            { "D1", "A2" },
            { "D2", "2B" }
        };
                ETypeOperators = new Dictionary<string, string>
        {
            { "E1", "Yonah" },
            { "E2", "Emil" }
        };
                GTypeOperators = new Dictionary<string, string>
        {
            { "G1", "Kaine" },
            { "G2", "Devola" }
        };
                HTypeOperators = new Dictionary<string, string>
        {
            { "H1", "Adam" },
            { "H2", "Eve" }
        };
                OTypeOperators = new Dictionary<string, string>
        {
            { "O1", "Pascal" },
            { "O2", "Yonah" }
        };
                STypeOperators = new Dictionary<string, string>
        {
            { "S1", "Nier" },
            { "S2", "Nier (Older)" }
        };

                // Initialize the new Nier-based properties
                Enemies = new List<Enemy>
        {
            new Enemy { EnemyName = "Machine A", EnemyType = "Type 1", Health = 100, Attack = 25, IsBoss = false },
            new Enemy { EnemyName = "Machine B", EnemyType = "Type 2", Health = 200, Attack = 50, IsBoss = true },
            new Enemy { EnemyName = "Machine C", EnemyType = "Type 3", Health = 300, Attack = 75, IsBoss = false }
        };

                Weapons = new List<Weapon>
        {
            new Weapon { WeaponName = "Sword", WeaponType = "Close Range", Damage = 150, Weight = 5.5f, IsLegendary = false },
            new Weapon { WeaponName = "Gun", WeaponType = "Long Range", Damage = 100, Weight = 3.2f, IsLegendary = true }
        };

                // Additional testing fields
                IsActive = true;
                MaxLevel = 99;
                Difficulty = 2.5; // A value from 1 to 5
                AttackSpeed = 1.25f;
                CreatedAt = DateTime.Now;
            }
        }

        // New Nier-related classes with additional types
        public class Operator
        {
            public string Name { get; set; }
            public string Nickname { get; set; }
            public string Role { get; set; }
        }

        public class Enemy
        {
            public string EnemyName { get; set; }
            public string EnemyType { get; set; }
            public int Health { get; set; }
            public int Attack { get; set; }
            public bool IsBoss { get; set; } // Indicates if the enemy is a boss
        }

        public class Weapon
        {
            public string WeaponName { get; set; }
            public string WeaponType { get; set; }
            public int Damage { get; set; }
            public float Weight { get; set; } // Weight in kilograms
            public bool IsLegendary { get; set; } // Indicates if the weapon is legendary
        }





        internal class BinaryConverterTest
        {

            public async Task<byte[]> ToByte()
            {
                return await BinaryConverter.NCObjectToByteArrayAsync("This is a test string.");
            }

            public async Task<string> FromByte(byte[] byteArray)
            {
                return await BinaryConverter.NCByteArrayToObjectAsync<string>(byteArray);
            }

            public async void TestObjectToByteArrayAsync()
            {

                Operation operation = new Operation();

                // Convert the operation object to a byte array

                byte[] byteArray = await BinaryConverter.NCObjectToByteArrayAsync(operation);

                Console.WriteLine("Byte array length: " + byteArray.Length);

                // Convert the byte array back to an object

                Operation convertedOperation = await BinaryConverter.NCByteArrayToObjectAsync<Operation>(byteArray);

                Console.WriteLine("Converted Operation Name: " + convertedOperation.OperationName);
                Console.WriteLine("Converted Description: " + convertedOperation.Description);
                Console.WriteLine("Converted Yorha Sect: " + convertedOperation.YorhaSect);
                Console.WriteLine("Converted IsActive: " + convertedOperation.IsActive);
                Console.WriteLine("Converted MaxLevel: " + convertedOperation.MaxLevel);
                Console.WriteLine("Converted Difficulty: " + convertedOperation.Difficulty);
                Console.WriteLine("Converted AttackSpeed: " + convertedOperation.AttackSpeed);
                Console.WriteLine("Converted CreatedAt: " + convertedOperation.CreatedAt);
                Console.WriteLine("Converted Operators Count: " + convertedOperation.Operators.Count);
                Console.WriteLine("Converted Enemies Count: " + convertedOperation.Enemies.Count);
                Console.WriteLine("Converted Weapons Count: " + convertedOperation.Weapons.Count);

                //Newline spacer

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(Environment.NewLine);

            }

        }

        internal class WalkerCryptoTest
        {

        public async Task<string> SimpleAESEncryptionTest()
        {
            var password = "ShadowLord".ToSecureData();

            // --- Simple (Synchronous) AES Encryption ---
            var sw1 = Stopwatch.StartNew();
            var encryptasynctest = SimpleAESEncryption.Encrypt("This is a test string.", password);
            sw1.Stop();

            Console.WriteLine($"Encrypted string (SimpleAESEncryptionTest): {encryptasynctest}");
            Console.WriteLine($"IV: {encryptasynctest.IV}");
            Console.WriteLine($"EncryptedText: {encryptasynctest.EncryptedText}");
            Console.WriteLine($"Encryption took {sw1.ElapsedMilliseconds} ms");

            // --- Simple (Synchronous) AES Decryption ---
            var sw2 = Stopwatch.StartNew();
            var decryptasynctest = SimpleAESEncryption.Decrypt(encryptasynctest, password);
            sw2.Stop();

            Console.WriteLine($"Decrypted string (SimpleAESEncryptionTest): {decryptasynctest}");
            Console.WriteLine($"Decryption took {sw2.ElapsedMilliseconds} ms");

            // --- Asynchronous AES Encryption ---
            double progressPercentage = 0.0;
            var sw3 = Stopwatch.StartNew();

            var enctest1 = await AsyncAESEncryption.EncryptAsync("This is a test string.", password, progress =>
            {
                progressPercentage = progress;
            });

            sw3.Stop();
            Console.WriteLine($"Encrypted string (AsyncAESEncryptionTest): {enctest1}");
            Console.WriteLine($"Async encryption took {sw3.ElapsedMilliseconds} ms");

            // --- Asynchronous AES Decryption ---
            double decryptPercentage = 0.0;
            var sw4 = Stopwatch.StartNew();

            var dectest1 = await AsyncAESEncryption.DecryptAsync(enctest1, password, progress =>
            {
                decryptPercentage = progress;
            });

            sw4.Stop();
            Console.WriteLine($"Decrypted string (AsyncAESEncryptionTest): {dectest1}");
            Console.WriteLine($"Async decryption took {sw4.ElapsedMilliseconds} ms");

            Console.WriteLine(Environment.NewLine);
            return "Done";
        }

        public async Task<string> AESFileEcryptorTest()
        {
            var password = "ShadowLord".ToSecureData();

            string inputFilePath = @"TestFiles\finally-all-the-chin-woo-artworks-in-high-quality-v0-tgmaxu5u03oe1.png";
            string encryptedFilePath = @"TestFiles\finally-all-the-chin-woo-artworks-in-high-quality-v0-tgmaxu5u03oe1_encrypted.png";
            string decryptedFilePath = @"TestFiles\finally-all-the-chin-woo-artworks-in-high-quality-v0-tgmaxu5u03oe1_decrypted.png";

            // --- Encrypt File ---
            double encryptionProgress = 0.0;
            Console.WriteLine("Starting file encryption...");
            var swEnc = Stopwatch.StartNew();

            await AESFileEncryptor.EncryptFileAsync(inputFilePath, encryptedFilePath, password, progress =>
            {
                encryptionProgress = progress;
            });

            swEnc.Stop();
            Console.WriteLine($"Encrypted file saved at: {Path.GetFullPath(encryptedFilePath)}");
            Console.WriteLine($"File encryption took {swEnc.ElapsedMilliseconds} ms");

            // --- Decrypt File ---
            double decryptionProgress = 0.0;
            Console.WriteLine("Starting file decryption...");
            var swDec = Stopwatch.StartNew();

            await AESFileEncryptor.DecryptFileAsync(encryptedFilePath, decryptedFilePath, password, progress =>
            {
                decryptionProgress = progress;
            });

            swDec.Stop();
            Console.WriteLine($"Decrypted file saved at: {Path.GetFullPath(decryptedFilePath)}");
            Console.WriteLine($"File decryption took {swDec.ElapsedMilliseconds} ms");

            Console.WriteLine(Environment.NewLine);
            return "Done";
        }

            public async Task WrongAESFilePasswordTest()
            {
                try
                {
                    var password = "ShadowLord".ToSecureData();

                    string inputFilePath = @"TestFiles\finally-all-the-chin-woo-artworks-in-high-quality-v0-tgmaxu5u03oe1.png";
                    string encryptedFilePath = @"TestFiles\finally-all-the-chin-woo-artworks-in-high-quality-v0-tgmaxu5u03oe1_encrypted.png";
                    string decryptedFilePath = @"TestFiles\finally-all-the-chin-woo-artworks-in-high-quality-v0-tgmaxu5u03oe1_decrypted.png";

                    // Encrypt the file and report progress to the console
                    double encryptionProgress = 0.0;

                    await AESFileEncryptor.EncryptFileAsync(inputFilePath, encryptedFilePath, password, progress =>
                    {
                        encryptionProgress = progress;
                        Console.WriteLine("Encryption Progress: " + (progress * 100) + "%");
                    });

                    Console.WriteLine("Encrypted file saved at: " + Path.GetFullPath(encryptedFilePath));

                    // Decrypt the file and report progress to the console
                    double decryptionProgress = 0.0;
                    Console.WriteLine("Starting file decryption...");
                    await AESFileEncryptor.DecryptFileAsync(encryptedFilePath, decryptedFilePath, "WrongPassword".ToSecureData(), progress =>
                    {
                        decryptionProgress = progress;
                        Console.WriteLine("Decryption Progress: " + (progress * 100) + "%");
                    });
                    Console.WriteLine("Decrypted file saved at: " + Path.GetFullPath(decryptedFilePath));

                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(Environment.NewLine);
                }

                catch
                {
                    Console.WriteLine("Bad password");
                }
            }


        }

        internal class EasyPQCTest
        {
            //Signature testing

            public async Task SignatureTest()
            {
                // Generate key pair
                var (publicKeyDict, privateKeyDict) = await EasyPQC.Signatures.CreateKeys();
                var message = "This is a test message.";

                // Encode and display key data
                Console.WriteLine("Public Key (Base64):");
                foreach (var kv in publicKeyDict)
                    Console.WriteLine($"{kv.Key}: {Convert.ToBase64String(kv.Value)}");

                Console.WriteLine("\nPrivate Key (Base64):");
                foreach (var kv in privateKeyDict)
                    Console.WriteLine($"{kv.Key}: {Convert.ToBase64String(kv.Value)}");

                Console.WriteLine();

                // Create signature
                var signature = await EasyPQC.Signatures.CreateSignature(privateKeyDict, message);
                Console.WriteLine("Signature (Base64): " + Convert.ToBase64String(signature));
                Console.WriteLine();

                // Verify signature
                var isValid = await EasyPQC.Signatures.VerifySignature(publicKeyDict, signature, message);
                Console.WriteLine("Signature valid Test Result: " + isValid);
                Console.WriteLine();

                // Verify with an invalid message
                var invalidMessage = "InvalidSignature";
                var invalidTest = await EasyPQC.Signatures.VerifySignature(publicKeyDict, signature, Encoding.UTF8.GetBytes(invalidMessage));
                Console.WriteLine("Invalid Signature Test Result: " + invalidTest);
                Console.WriteLine("\n\n");



                int i = 0;

                while (12 <= i)
                {
                    Console.WriteLine(Environment.NewLine);
                    i++;

                }

                Console.WriteLine("Summary:");
                Console.WriteLine("Signature valid Test Result: " + isValid);
                Console.WriteLine("Invalid Signature Test Result: " + invalidTest);

            }


            public void KeysTest()
            {
                var keyPass = "This is a test password!";

                var keys = EasyPQC.Keys.Initiate();


                var secretOne = EasyPQC.Keys.CreateSecret(keys.Item1);

                var sOnea = secretOne.text;
                var sOneb = secretOne.key;

                Console.WriteLine(Environment.NewLine);

                Console.Write("Secret One: " + Convert.ToBase64String(sOnea));
                Console.WriteLine(Environment.NewLine);
                Console.Write("Key One: " + Convert.ToBase64String(sOneb));

                var SecretTwo = EasyPQC.Keys.CreateSecretTwo(keys.Item2, sOnea);

                Console.WriteLine(Environment.NewLine);


                Console.WriteLine("Secret Validation " + Convert.ToBase64String(SecretTwo));


            }

            public void KeysMsgTest()
            {
                var members = new[] { "Kirito", "Asuna", "Klein", "Lisbeth", "Silica" };
                var publicKeys = new Dictionary<string, Dictionary<string, byte[]>>();
                var privateKeys = new Dictionary<string, Dictionary<string, byte[]>>();

                // Step 1: Everyone generates a keypair
                foreach (var member in members)
                {
                    var keys = EasyPQC.Keys.Initiate();
                    publicKeys[member] = keys.Item1;
                    privateKeys[member] = keys.Item2;
                }

                Console.WriteLine("Everyone has generated their keys!\n");

                // Step 2: Everyone (except Kirito) establishes a shared key with Kirito
                foreach (var member in members)
                {
                    if (member == "Kirito") continue;

                    var shared = EasyPQC.Keys.CreateSecret(publicKeys["Kirito"]);
                    var sharedSecret = shared.key;

                    Console.WriteLine($"🔐 {member} → Kirito:");
                    Console.WriteLine($"  Shared Secret: {Convert.ToBase64String(sharedSecret)}");

                    // Simulating message send using the shared key
                    Console.WriteLine($"  Message from {member}: \"Hey Kirito, let's meet up at the mall!\"\n");
                }

                Console.WriteLine("SAO Mall Chat setup complete! 🎉");
            }

            public void FileTest()
            {
                var filePath = @"C:\[REDACTED]\finally-all-the-chin-woo-artworks-in-high-quality-v0-f5bnem4v03oe1.png";
                var fileOutput = @"TestFiles\";

                // Generate a valid key pair  
                var (publicKey, privateKey) = EasyPQC.Signatures.CreateKeys().Result;

                // Pack the file  
                var pack = EasyPQC.FileOperations.PackFiles(
                    filePath,
                    fileOutput,
                    privateKey,
                    "Password".ToSecureData(),
                    null,
                    EasyPQC.FileOperations.CompressionLevel.Fast,
                    true
                ).Result;

                Console.WriteLine("Packed file: " + pack);

                // Unpack the file  
                var unpack = EasyPQC.FileOperations.UnpackFile(
                    pack,
                    fileOutput,
                    publicKey,
                    null,
                    EasyPQC.FileOperations.CompressionLevel.Fast,
                    "Password".ToSecureData()
                ).Result;

                Console.WriteLine("Unpacked file: " + unpack);

                // Test with a wrong password  
                var falseUnpack = EasyPQC.FileOperations.UnpackFile(
                    pack,
                    fileOutput,
                    publicKey,
                    null,
                    EasyPQC.FileOperations.CompressionLevel.Fast,
                    "WrongPassword".ToSecureData()
                ).Result;

                Console.WriteLine("Unpacked file with wrong password: " + falseUnpack);
            }

            public async Task RotateTest()
            {

                var rotation = new EasyPQC.Rotation();
                Console.WriteLine("Initial Key");
                var initkey = await rotation.CreateInitialKey("I need more power.");
                Console.WriteLine("Initial Salt: " + initkey.Item1);
                Console.WriteLine("Initial Key: " + initkey.Item2);

                var rot = new EasyPQC.Rotation();

                //Multirotation test

                int rotationCount = 20;

                int round = 0;

                string currentKey = initkey.Item2;

                while (rotationCount >= round)
                {
                    var rotatedKey = await rot.RotateKey(currentKey.ToSecureData(), round, initkey.Item2);
                    Console.WriteLine($"Rotated Key for round {round}: " + rotatedKey);
                    round++;
                }




            }


        }

        internal class PariahCybersecTest
        {
            private readonly DataHandler.Accounts accounts = new DataHandler.Accounts();

            public async Task AccountsTest()
            {
                var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PariahCybersecTest", "TestFiles");

                if (Directory.Exists(directory))
                {
                    foreach (var file in Directory.GetFiles(directory))
                    {
                        File.Delete(file);
                    }
                }

                Directory.CreateDirectory(directory);

                await accounts.SetupFiles(directory);

                var newUser = await accounts.CreateUser("RedEyedXaXa", "GGO_NoRespawn$SinonTargeted@Midnight".ToSecureData(), directory);

                Console.WriteLine("New User Created, password recovery key: " + newUser.ConvertToString());

                var loginUser = await accounts.LoginUser("RedEyedXaXa", directory, "GGO_NoRespawn$SinonTargeted@Midnight".ToSecureData());

                Console.WriteLine("Login User File Encryption Key: " + loginUser.ConvertToString());

                var resetTest = await accounts.ResetPassword("RedEyedXaXa", directory, "XeXeed_Offline$KillCode_2077*VR".ToSecureData(), newUser);

                Console.WriteLine("Password Reset Key: " + resetTest.ConvertToString());
            }

            public static async Task AccountsWithSessionsTest()
            {
                var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PariahCybersecTest", "TestFilesAsync");

                if (Directory.Exists(directory))
                {
                    Directory.Delete(directory, true); 
                    Console.WriteLine("Directory and its contents reset.");
                }

                Directory.CreateDirectory(directory);

                Console.WriteLine(directory);
                string username = "testUser";
                var password = "testPassword123".ToSecureData(); // Convert to SecureString
                string recoveryPassword = "recoveryPassword123"; // Recovery password

                // Initialize the object that has the methods
                var userManagement = new DataHandler.AccountsWithSessions();

                // Setup files (Initialize JSON structure)
                await userManagement.SetupFiles(directory);

                // Create a user
                var recoveryKey = await userManagement.CreateUser(username, password, directory);
                Console.WriteLine($"User created. Recovery key: {recoveryKey.ConvertToString()}");

                // Login the user
                var loginResult = await userManagement.LoginUser(username, directory, password, true);
                Console.WriteLine($"User logged in. Session ID: {loginResult.Item2.SessionID}");

                // Validate the session
                bool isSessionValid = await userManagement.ValidateSession(loginResult.Item2, loginResult.Item1);
                Console.WriteLine($"Is session valid: {isSessionValid}");

                var usernames = await userManagement.GetAllUsernames(loginResult.Item2, loginResult.Item1);
                Console.WriteLine(usernames);
                Console.WriteLine("Usernames above");

                // Reset password
                var newPassword = "newPassword123".ToSecureData();
                await userManagement.ResetPassword(loginResult.Item2, loginResult.Item1, newPassword, recoveryKey);
                Console.WriteLine("Password reset successfully.");

                // Logout user (Remove if testing remove account, you need to be logged in to remove your acc)
                await userManagement.LogoutUser(loginResult.Item2, loginResult.Item1);
                Console.WriteLine("User logged out.");

                // Remove account
                await userManagement.RemoveAccount(loginResult.Item2, loginResult.Item1);
                Console.WriteLine("Account removed successfully.");
            }
            

            public static async Task DataRequestTest()
            {

                var author = "Zakstar";
                var software = "TournamentOfBullets";
                var serviceParent = "GunGaleOnline";
                var programName = "GunGaleOnlineLauncher";
                var password = "TestPassword123!".ToSecureData();
                var identifier = "Gun Gale Online".ToSecureData();
                var username = "Launcher";
                var tierCount = 1;

                // Simulated PublicKey (normally this would be a PQC public key)
                var publicKey = "SimulatedPublicKeyShouldBe32CharsLong".ToSecureData();

                var manager = new Pariah_Cybersecurity.DataHandler.DataRequest();

                // Test: GetPaths
                var directoryData = await manager.GetPaths(identifier, software, author, programName, serviceParent);
                Console.WriteLine("GetPaths test completed.");


                var createdSystem = await manager.CreateNewSystem(
                    username,
                    identifier,
                    password,
                    software,
                    author,
                    "DummyExePath",
                    serviceParent,
                    tierCount,
                    publicKey,
                    SecureData.FromString("TestUserID") // Add this argument for userID
                );
                Console.WriteLine($"CreateNewSystem returned: {createdSystem.ConvertToString()}");

                // Test: CreateNewApp
                var createdApp = await manager.CreateNewApp("Tower Of Bullets", password, directoryData.MainServicePath, directoryData, "0", publicKey);
                Console.WriteLine($"CreateNewApp returned: {createdApp.ConvertToString()}");



                // Test: CheckMainPathValidity
                var validityCheck = await manager.CheckMainPathValidity(directoryData, publicKey);
                Console.WriteLine($"CheckMainPathValidity: {validityCheck}");





            }




        }

    }
}