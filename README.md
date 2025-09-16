# InsureYouAI Sigortacılık (Asp.Net Core 9.0 Mvc)

## Sertifika
![cretificate](https://udemy-certificate.s3.amazonaws.com/image/UC-62ed97af-088b-44a8-90ac-a0457fefab07.jpg?v=1757796730000)

## Projenin Maksadı
Insure You AI, uygulamada yapay zeka teknolojilerini sigorta sektörüne entegre edebilmenin potansiyelini göstermektir. Proje kapsamında, kullanıcıların sigorta taleplerinin otomatik olarak değerlendirilmesi, risk analizlerinin yapılması ve müşteri odaklı çözümler sunulması hedeflenmektedir. Geliştirilen sistem, yapay zekâ destekli veri işleme yöntemleriyle sigorta süreçlerini hızlandırmayı, operasyonel maliyetleri azaltmayı ve müşteri deneyimini iyileştirmeyi amaçlamaktadır. Böylece hem sektörün dijital dönüşümüne katkı sağlanacak hem de yapay zekâ entegrasyonlarının gerçek bir senaryo üzerinde nasıl uygulanabileceği gösterilecektir.

Insure You AI; Asp.Net Core Mvc 9.0, EntityFramework Core, Open AI, Gemini, Anthropic, Microsoft Azure AI, Stabilitiy AI ve Replicate gibi öne çıkan ai servileri kullanılarak geliştirildi.

⚠️ Not: Bu proje geliştirilmekte olup halen devam etmektedir. Kurs tamamlandıkça repo güncellenecektir.

## 🔧 Teknik Yapı ve Mimarisi
💎 .Net Core 9.0 Mvc <br />
💎 EntityFramework Core <br />
💎 Google Gemini: gemini-1.5-pro (Hakkımızda Alanı) <br />
💎 Open AI: /v1/chat/completions - gpt-4o-mini (Kullanıcı Alanı) <br />
💎 Open AI: /v1/chat/completions - gpt-3.5-turbo (Makale Alanı) <br />
💎 Open AI: v1/images/generations (Görsel Oluşturma) <br />
💎 Open AI: /v1/chat/completions - gpt-4o-mini (ChatBot Asistan) <br />
💎 Hugging Face: Helsinki-NLP/opus-mt-tr-en (Türkçe → İngilizce çeviri) <br />
💎 Hugging Face: unitary/toxic-bert (Toxic kontrolü) <br />
💎 Anthropic Claude: v1/messages - claude-4-opus-20250514 (E-Posta Yanıt Asistanı) <br />
💎 Anthropic Claude: v1/messages - claude-3-5-sonnet-20241022 (Servis Alanı) <br />
💎 Anthropic Claude: v1/messages - claude-3-5-sonnet-20241022 (Referans Alanı) <br />
💎 Microsoft.ML - Microsoft.ML.Time Series (Veri Analitiği) <br />
💎 SignalR - Streaming <br />
💎 X.PagedList (Sayfalama) <br />
💎 Bootstrap <br />
💎 JavaScript (JQuery, ApexCharts) <br />
💎 Html - Css <br />

![.NET](https://img.shields.io/badge/.NET%209.0-purple?logo=dotnet)
![Entity Framework](https://img.shields.io/badge/EntityFrameworkCore-green)
![OpenAI](https://img.shields.io/badge/OpenAI-API-blue?logo=openai)
![Azure](https://img.shields.io/badge/Azure-AI-blue?logo=microsoftazure)

## Projeye İlişkin Bazı Görseller

![1](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20201439.png)
![2](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20201834.png)
![3](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20201854.png)
![4](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203015.png)
![5](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203039.png)
![6](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203056.png)
![7](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203119.png)
![8](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203138.png)
![9](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203159.png)
![10](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20203337.png)
![11](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20204435.png)
![12](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20204504.png)
![13](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20204526.png)
![14](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20204801.png)
![15](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20205145.png)
![16](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-14%20205203.png)
![17](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-15%20132802.png)
![18](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-15%20132907.png)
![19](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101437.png)
![20](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101710.png)
![21](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101739.png)
![22](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101759.png)
![23](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101815.png)
![24](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101832.png)
![25](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-09-16%20101856.png)
![26](https://github.com/hasan-bozkus/InsureYouAI/blob/master/wwwroot/images/2025-09-11_10-06-35.png)
