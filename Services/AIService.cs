using System.Text;
using System.Text.Json;

namespace InsureYouAI.Services
{
    public class AIService
    {
        //anahtar ezilecek
        private readonly string _apiKey = "anahtar ezildi...";
        private readonly string _model = "gemini-2.5-flash";

        public async Task<string> PredictCategoryAsync(string messageText)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent?key={_apiKey}";

            using var http = new HttpClient();

            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = $"Aşağıdaki kullanıcı mesajını sigortacılık alanında kategorize et. Sadece kategori adı döndür.\n\nMesaj: {messageText}\n\nOlası kategoriler:\n- Kasko\n- Trafik Sigortası\n- Sağlık Sigortası\n- Konut Sigortası\n- Hasar Bildirimi\n- Fiyat Teklifi\n- Poliçe Yenileme\n- Genel Soru\n- İletişim Talebi\n" }
                    }
                }
            }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                using var doc = JsonDocument.Parse(result);
                var text = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text").GetString();

                return text.Trim();
            }
            return "Kategori Okunamadı";
        }

        public async Task<string> PredictPriorityAsync(string messageText)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent?key={_apiKey}";

            using var http = new HttpClient();

            var requestBody = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new { text = $@"Aşağıdaki kullanıcı mesajının aciliyet seviyesini belirle. Sadece 3 seçenekten birini döndür: High, Medium, Low. 
Kurallar:
- Kaza, hasar, ödeme sorunları, acil durumlar → High
- Fiyat teklifi, yenileme, teminat soruları → Medium
- Genel sorular, merak edilen bilgiler → Low

Mesaj:
{messageText}
" }
                }
            }
        }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(result);
            var root = doc.RootElement;

            if (!root.TryGetProperty("candidates", out var candidatesArray) ||
                candidatesArray.GetArrayLength() == 0)
            {
                return "Low"; // fallback mantıklı
            }

            var candidate = candidatesArray[0];

            if (!candidate.TryGetProperty("content", out var contentElement) ||
                !contentElement.TryGetProperty("parts", out var partsArray) ||
                partsArray.GetArrayLength() == 0)
            {
                return "Low";
            }

            var text = partsArray[0].GetProperty("text").GetString();

            return text?.Trim() ?? "Low";
            //var text = doc.RootElement
            //    .GetProperty("candidates")[0]
            //    .GetProperty("content")
            //    .GetProperty("parts")[0]
            //    .GetProperty("text").GetString();

            //return text.Trim();
        }
    }
}
