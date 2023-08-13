using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Cloud.Translation.V2;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AbpLanguageTranslatorTools
{


    public partial class FrmMain : Form
    {
        public class ChatGPTClient
        {
            private readonly string _apiKey;
            private readonly RestClient _client;

            // Constructor that takes the API key as a parameter
            public ChatGPTClient(string apiKey)
            {
                _apiKey = apiKey;
                // Initialize the RestClient with the ChatGPT API endpoint
                _client = new RestClient("https://api.openai.com/v1/completions");
            }

            // We'll add methods here to interact with the API.

            public string SendMessage(string message)
            {
                // Create a new POST request
                var request = new RestRequest("", Method.Post);
                // Set the Content-Type header
                request.AddHeader("Content-Type", "application/json");
                // Set the Authorization header with the API key
                request.AddHeader("Authorization", $"Bearer {_apiKey}");

                // Create the request body with the message and other parameters
                var requestBody = new
                {
                    model = "text-davinci-003",
                    prompt = message,
                    max_tokens = 300,
                    //n = 1,
                    //stop = (string)null,
                    temperature = 0.4,
                };

                // Add the JSON body to the request
                request.AddJsonBody(JsonConvert.SerializeObject(requestBody));

                // Execute the request and receive the response
                var response = _client.Execute(request);

                // Deserialize the response JSON content
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content ?? string.Empty);

                // Extract and return the chatbot's response text
                return jsonResponse?.choices[0]?.text?.ToString()?.Trim() ?? string.Empty;
            }
        }

        private readonly string _ApiKeyChatGPT = "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";
        private readonly string _ApiKeyGoogle = "AIzaSyDvlaZMrdTusIS-BukysrGAmZv409mGeEg";
        private readonly RestClient _client;

        Dictionary<string, string> texts;
        string json; // 讀取原始 JSON 檔案

        public FrmMain()
        {
            InitializeComponent();

            texts = new Dictionary<string, string>();
        }



        private void btnUpload_Click(object sender, EventArgs e)
        {
            //var chatGPTClient = new ChatGPTClient(_ApiKeyChatGPT);

            //while (true)
            //{
            //    // Prompt the user for input
            //    Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
            //    Console.Write("You: ");
            //    Console.ResetColor(); // Reset text color to default
            //    string input = Console.ReadLine() ?? string.Empty;

            //    // Exit the loop if the user types "exit"
            //    if (input.ToLower() == "exit")
            //        break;

            //    // Send the user's input to the ChatGPT API and receive a response
            //    string response = chatGPTClient.SendMessage(input);

            //    // Display the chatbot's response
            //    Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
            //    Console.Write("Chatbot: ");
            //    Console.ResetColor(); // Reset text color to default
            //    Console.WriteLine(response);
            //}



            // 定義正則表達式模式
            string pattern = @"""(.*?)"": ""(.*?)"",";

            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "請選擇一個文件...";
                dialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
                dialog.ShowDialog();
                if (dialog.FileName.Trim() != string.Empty)
                {
                    using (StreamReader sr = new StreamReader(dialog.FileName))
                    {
                         json = sr.ReadToEnd();

                        // 進行匹配
                        MatchCollection matches = Regex.Matches(json, pattern);

                        // 創建字典來存儲解析結果
                        string culture = "";
                                 var service = new TranslateService(new BaseClientService.Initializer { ApiKey = _ApiKeyGoogle });
                        var client = new TranslationClientImpl(service, TranslationModel.ServiceDefault);
                        foreach (Match match in matches)
                        {
                            if (match.Groups.Count == 3)
                            {
                                string key = match.Groups[1].Value;
                                string value = match.Groups[2].Value;

                                if (key == "Culture")
                                {
                                    culture = value;
                                }
                                else
                                {
                                    texts[key] = client.TranslateText(value, LanguageCodes.ChineseTraditional, LanguageCodes.English).TranslatedText;
                                }
                            }
                        }


                        var aa = texts;

                        MsgBoxHelper.Warning("翻譯完成，請直接按匯出");

                    }
                }
            }
        }

        public static string UpdateJsonTexts(string originalJson, Dictionary<string, string> newTexts)
        {
            // 將 texts 字典的內容轉換為 JSON 格式的文字
            string newTextsJson = "{" + string.Join(",", newTexts.Select(kv => $"\"{kv.Key}\": \"{kv.Value}\"")) + "}";

            // 找到 "Texts" 區塊
            int startIndex = originalJson.IndexOf("\"Texts\": {");
            int endIndex = originalJson.IndexOf('}', startIndex);

            if (startIndex != -1 && endIndex != -1)
            {
                // 替換 "Texts" 區塊為新的 JSON 格式的 texts
                string updatedJson = originalJson.Substring(0, startIndex) + "\"Texts\": " + newTextsJson + originalJson.Substring(endIndex + 1);
                return updatedJson;
            }
            else
            {
                throw new InvalidOperationException("Failed to update JSON.");
            }
        }

        private void writeDataToFile(string fileName)
        {
            try
            {
                using (FileStream fs = File.Open(fileName + ".json", FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    // serializer.Serialize(jw, Your_Data_Goes_Here);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while writing file. Please contact IT department for immediate assist!");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    string updatedJson = UpdateJsonTexts(json, texts);
                    File.WriteAllText(fileName, updatedJson, Encoding.UTF8); // 將更新後的 JSON 寫回新檔案
                }
            }
            catch
            {

            }
        }
    }
}