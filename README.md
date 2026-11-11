# 🎨 AI CSS Generator

![.NET 8](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![Groq AI](https://img.shields.io/badge/Groq_API-F55036?style=for-the-badge&logo=openai&logoColor=white)

> 🇺🇸 **English** | 🇧🇷 [Português](#-gerador-de-css-com-ia-português)

A full-stack web application that generates clean, ready-to-use CSS code in real time from natural language descriptions. Built with a **.NET 8 Minimal API** backend integrated with **Groq Cloud AI** and a responsive **Vanilla JS** frontend.

---

## ✨ Features

- **Real-Time AI Generation:** Describe any UI component or style in plain text and get instant, valid CSS.
- **Ultra-Fast Inference:** Powered by Groq's LPU inference engine for near-instant responses.
- **Secure Credential Management:** Uses .NET `User Secrets` (`IConfiguration`) to keep API keys out of source control.
- **Swagger/OpenAPI Support:** Built-in interactive API documentation for testing endpoints directly.
- **CORS Configured:** Ready for seamless communication between frontend and backend.

---

## 🛠️ Tech Stack

- **Backend:** .NET 8 (Minimal API), C#, RestSharp, System.Text.Json
- **Frontend:** HTML5, CSS3, Vanilla JavaScript (`index.html`)
- **AI Integration:** Groq Cloud API (`openai/gpt-oss-120b` / `llama-3.3-70b-versatile`)
- **Documentation:** Swagger / Swashbuckle

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A [Groq Cloud API Key](https://console.groq.com/)

### 1. Clone the repository

```bash
git clone [https://github.com/LeorMolina/AICssGenerator.git](https://github.com/LeorMolina/AICssGenerator.git)
cd AICssGenerator/AICssGenerator
