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

            // Helpers to run tests and continue on error
            async Task RunAsyncTest(string name, Func<Task> test)
            {
                try
                {
                    Console.WriteLine($"\nRunning {name}...");
                    await test();
                    Console.WriteLine($"{name} succeeded.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{name} didn't work: {ex.Message}");
                    // optional: uncomment to see stack trace:
                    // Console.WriteLine(ex);
                }
            }

            void RunSyncTest(string name, Action test)
            {
                try
                {
                    Console.WriteLine($"\nRunning {name}...");
                    test();
                    Console.WriteLine($"{name} succeeded.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{name} didn't work: {ex.Message}");
                    // optional: uncomment to see stack trace:
                    // Console.WriteLine(ex);
                }
            }

            // BinaryConverter Tests
            var binaryTests = new TestRunner.BinaryConverterTest();
            // NOTE: TestObjectToByteArrayAsync must return Task (not void). See change B below.
            await RunAsyncTest("BinaryConverter.TestObjectToByteArrayAsync", async () =>
            {
                 binaryTests.TestObjectToByteArrayAsync();
            });

            // WalkerCrypto Tests
            var cryptoTests = new TestRunner.WalkerCryptoTest();
            await RunAsyncTest("WalkerCrypto.SimpleAESEncryptionTest", async () => { await cryptoTests.SimpleAESEncryptionTest(); });
            await RunAsyncTest("WalkerCrypto.AESFileEcryptorTest", async () => { await cryptoTests.AESFileEcryptorTest(); });
            await RunAsyncTest("WalkerCrypto.WrongAESFilePasswordTest", async () => { await cryptoTests.WrongAESFilePasswordTest(); });

            // EasyPQC Tests
            var pqcTests = new TestRunner.EasyPQCTest();
            await RunAsyncTest("EasyPQC.SignatureTest", async () => { await pqcTests.SignatureTest(); });
            RunSyncTest("EasyPQC.KeysTest", () => pqcTests.KeysTest());
            RunSyncTest("EasyPQC.KeysMsgTest", () => pqcTests.KeysMsgTest());
            RunSyncTest("EasyPQC.FileTest", () => pqcTests.FileTest());
            await RunAsyncTest("EasyPQC.RotateTest", async () => { await pqcTests.RotateTest(); });

            // PariahCybersec Tests
            var pariahTests = new TestRunner.PariahCybersecTest();
            await RunAsyncTest("PariahCybersec.AccountsTest", async () => { await pariahTests.AccountsTest(); });
            await RunAsyncTest("PariahCybersec.AccountsWithSessionsTest", async () => { await TestRunner.PariahCybersecTest.AccountsWithSessionsTest(); });
            await RunAsyncTest("PariahCybersec.DataRequestTest", async () => { await TestRunner.PariahCybersecTest.DataRequestTest(); });

            Console.WriteLine("\nAll tests finished (some may have been skipped due to errors).");
            Console.WriteLine("=====================================");
        }
    }
}
