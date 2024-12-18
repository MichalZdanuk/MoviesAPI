# MoviesAPI

This repository demonstrates the usage of the **Decorator Pattern** in a simple API implementation. The progression of this implementation is organized into stages, with each stage represented by a specific commit. These stages showcase how step-by-step adoption of the Decorator Pattern enhances code readability and maintainability.

---

## 🚀 Stages of Implementation

### **Stage 1: Initial Implementation Without Decorators**  
A basic API implementation is introduced, without any decorators.  
[View Commit: Initial Implementation](https://github.com/MichalZdanuk/MoviesAPI/commit/51ff876ddc35a62db2e550e521fea77b8f49379c)

### **Stage 2: Adding Caching Mechanism**  
The service implementation is extended to include a caching mechanism, improving performance.  
[View Commit: Adding Caching](https://github.com/MichalZdanuk/MoviesAPI/commit/5199fb31a3da9bbbf315e552f8f1f87ca55d04fd)

### **Stage 3: Extracting Caching Using Decorators**  
The caching logic is refactored into a decorator, isolating it from the core functionality.  
[View Commit: Extracting Caching with Decorator](https://github.com/MichalZdanuk/MoviesAPI/commit/748e34a073eccf2565c73ee68a1593f3ef51cd29)

### **Stage 4: Adding Logging with Decorators**  
A logging mechanism is added, implemented as a decorator for better separation of concerns.  
[View Commit: Adding Logging with Decorator](https://github.com/MichalZdanuk/MoviesAPI/commit/8d7e51a192ecfc3259d7608304d8874fb77ba0fe)

### **Stage 5: Refactoring with Scrutor for Dependency Injection**  
The code is refactored to use the **Scrutor** library, simplifying dependency injection and further improving the modularity of the implementation.  
[View Commit: Refactoring with Scrutor](https://github.com/MichalZdanuk/MoviesAPI/commit/22e09f61416031bc8422ac9559faa0b0ba83906d)

---

## 📑 Presentation

For a detailed explanation of the implementation process and design choices, refer to the PDF presentation:  
[**Decorator Pattern Presentation by Michał Żdanuk**](https://github.com/MichalZdanuk/MoviesAPI/blob/master/dekorator_Micha%C5%82_%C5%BBdanuk.pdf)

---

## 💡 Inspiration

Idea of implemenation and clean way of implementation was inspired by:
[DevMentors Video](https://www.youtube.com/watch?v=7szQgVWyoPc&ab_channel=DevMentors)
