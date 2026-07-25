# InsureYouAI Sigortacılık (Asp.Net Core 9.0 Mvc)

## Sertifika
![cretificate](https://udemy-certificate.s3.amazonaws.com/image/UC-62ed97af-088b-44a8-90ac-a0457fefab07.jpg?v=1757796730000)

## Projenin Maksadı
Insure You AI, uygulamada yapay zeka teknolojilerini sigorta sektörüne entegre edebilmenin potansiyelini göstermektir. Proje kapsamında, kullanıcıların sigorta taleplerinin otomatik olarak değerlendirilmesi, risk analizlerinin yapılması ve müşteri odaklı çözümler sunulması hedeflenmektedir. Geliştirilen sistem, yapay zekâ destekli veri işleme yöntemleriyle sigorta süreçlerini hızlandırmayı, operasyonel maliyetleri azaltmayı ve müşteri deneyimini iyileştirmeyi amaçlamaktadır. Böylece hem sektörün dijital dönüşümüne katkı sağlanacak hem de yapay zekâ entegrasyonlarının gerçek bir senaryo üzerinde nasıl uygulanabileceği gösterilecektir.

Insure You AI; Asp.Net Core Mvc 9.0, EntityFramework Core, Open AI, Gemini, Anthropic, Microsoft Azure AI, Stabilitiy AI ve Replicate gibi öne çıkan ai servileri kullanılarak geliştirildi.

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
![Gemini](https://img.shields.io/badge/Google-Gemini-red?logo=google)
![OpenAI](https://img.shields.io/badge/OpenAI-API-blue?logo=openai)
![Hugging Face](https://img.shields.io/badge/HuggingFace-Spaces-yellow?logo=huggingface&logoColor=black)
![Anthropic](https://img.shields.io/badge/Anthropic-Claude-A16D21?logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI5NjAiIGhlaWdodD0iOTYwIiB2aWV3Qm94PSIwIDAgNzUgNzUiPgogIDxwYXRoIGZpbGw9IiNGRkZGRkYiIGQ9Ik0zNy41IDBDMTYuNzgzIDAgMCAxNi43ODMgMCAzNy41UzE2Ljc4MyA3NSA1MC4yMTcgNzVsMjAuNjI4LTIwLjYyOUEzNy40NjcgMzcuNDY3IDAgMDA3NSA1MC4yMTdWNUN6Ii8+CiAgPHBhdGggZmlsbD0iI0ExNkQyMSIgZD0iTTAgNDkuMDk3QTM3LjUgMzcuNSAwIDAwMzcuNSA3NXMzNy41LTI2LjcwMyAzNy41LTI2LjcwM1YwTDM3LjUgMTkuNjk1em02MC4wMzQtNDQuNDc3LTYwLjAzNCA2MC4wMzR2MTAuMzQ5QTM3LjUgMzcuNSAwIDAwNDkuMDk3IDc1TDU2LjgyIDY3Ljg4IDU2LjgyIDY2LjczTDYwLjA1NyA2NEM2MC4wNTcgNTUuODg5IDYwLjAzNCAzOC43MyA2MC4wMzQgNC42MnptMTQuNjM2IDQyLjY3NEEzNy41IDM3LjUgMCAwMDY2Ljg4IDY2LjgzN2w2Ljg4NS02Ljg4NSAzLjI0Ny0zLjI0N1YyNS44ODJsLTExLjk5Mi0xMS45OTJWMjQuMjJ6Ii8+Cjwvc3ZnPg==)
![Microsoft.ML](https://img.shields.io/badge/Microsoft-ML.NET-50217D?logo=microsoft)
![SignalR](https://img.shields.io/badge/ASP.NET-SignalR-darkblue?logo=signalr)
![ApexCharts](https://img.shields.io/badge/ApexCharts-Visualizations-00A9FF?logo=apexcharts)
![jQuery](https://img.shields.io/badge/jQuery-JavaScript-0769AD?logo=jquery&logoColor=white)

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
