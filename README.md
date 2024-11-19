# Poc.GraphQL

Bu çalışma, GraphQL'in .NET Core ile kullanımını gösteren bir "Proof of Concept" (PoC) çalışmasıdır. GraphQL, client'ın yalnızca ihtiyaç duydukları verileri almasını sağlayan bir sorgu dili ve API geliştirme aracıdır. Bu Poc, GraphQL'in nasıl çalıştığını anlamak ve .NET projelerinde nasıl kullanılacağını göstermek amacıyla hazırlanmıştır.


- GraphQL API oluşturma ve kullanımı
- .NET Core ile entegrasyon
- Docker desteği

## Kurulum

- Klonlama

   ```bash
   git clone https://github.com/BekirK-C/Poc.GraphQL.git
   ```
- Proje dizini

```bash
cd Poc.GraphQL
```

- Local ortamda çalıştırma
```bash
dotnet run --project GraphQL.API
```
Tarayıcıda ```http://localhost:5000/graphql``` adresine giderek GraphQL API'ye erişebilirsiniz.
