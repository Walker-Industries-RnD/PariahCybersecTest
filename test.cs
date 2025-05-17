using System;
using System.Threading.Tasks;

namespace PariahCybersecTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting all tests...");
            Console.WriteLine("=====================================");

            // BinaryConverter Tests
            Console.WriteLine("\nRunning BinaryConverter Tests...");
            var binaryTests = new TestRunner.BinaryConverterTest();
            binaryTests.TestObjectToByteArrayAsync();

            // WalkerCrypto Tests
            Console.WriteLine("\nRunning WalkerCrypto Tests...");
            var cryptoTests = new TestRunner.WalkerCryptoTest();
            await cryptoTests.SimpleAESEncryptionTest();
            await cryptoTests.AESFileEcryptorTest();
            await cryptoTests.WrongAESFilePasswordTest();

            // EasyPQC Tests
            Console.WriteLine("\nRunning EasyPQC Tests...");
            var pqcTests = new TestRunner.EasyPQCTest();
            await pqcTests.SignatureTest();
            pqcTests.KeysTest();
            pqcTests.KeysMsgTest();
            await pqcTests.RotateTest();

            // PariahCybersec Tests, keep in mind wrap this in a try method since I made these wiht the intention of changing internal stuff while testing the functions
            Console.WriteLine("\nRunning PariahCybersec Tests...");
            var pariahTests = new TestRunner.PariahCybersecTest();
            await pariahTests.AccountsTest();
            await TestRunner.PariahCybersecTest.AccountsWithSessionsTest();
            await TestRunner.PariahCybersecTest.DataRequestTest();

            Console.WriteLine("\nAll tests completed!");
            Console.WriteLine("=====================================");
        }
    }
}