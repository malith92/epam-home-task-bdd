using System.Text.Json;
using HomeTaskDesignPatterns.Utilities.POCO;

namespace HomeTaskDesignPatterns.Utilities
{
    public class ConfigurationFileReader
    {
        private static ConfigurationFileReader? _instance;
        private TestData? _testData;
        private ConfigData? _configData;

        private ConfigurationFileReader() 
        {
            // Read Config Data
            string configDatatext = File.ReadAllText(@"./../../../Resources/ConfigData.json");
            _configData = JsonSerializer.Deserialize<ConfigData>(configDatatext);

            // Read Test Data
            string testDatatext = File.ReadAllText(@"./../../../Resources/TestData.json");
            _testData = JsonSerializer.Deserialize<TestData>(testDatatext);
        }

        public TestData? TestData { get => _testData; }
        public ConfigData? ConfigData { get => _configData; }

        public static ConfigurationFileReader GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigurationFileReader();
            }

            return _instance;
        }     
    }
}
