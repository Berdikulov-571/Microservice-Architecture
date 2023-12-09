Assalomu aleykum mening bu loyiham imtihon uchun microservicelar bilan ishlash va o'rgangan yangiliklarimizni projectda qo'llash edi.
Mega imtihon uchun qilish kerak bo'lgan projectlar 4 ta edi: 1.University, 2.School, 3.Cadastre, 4.Jamoat Transporti

![Screenshot 2023-12-09 021549](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/fb7889d6-85c8-4e3f-ab1a-839ff071ae85)

Hozir ketma-ketligida bu projectlarni tanishtirishni boshlayman. 
1. University
Bu projectda N-Tier Architectureda Foydalanganmiz
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/2c65b3e3-5bbe-4b35-bebe-dc2767828477)

University.Domain qismida bizning CustomAttributelarimiz,Dtolarimiz,entitylar,Enumalar va Custom Exceptionlar mavjud ![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/8a082de0-eb0a-42eb-9540-4104709c4533)
Bu projectda ishlatilgan Entitylarni tepadagi rasmda ko'rib olishingiz mumkin shu bilan Domain qismi tugaydi. Endi esa University.DataAccess qismiga o'tamiz Bu yerda bizning DataBasega Connect qilish qismi va Migrationlarimiz,EntityTypeConfiguratsiyalar turadi va shunga o'xshash databasega oid narsalar shu yerda joylashagan bo'ladi ![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/cbafac72-e978-4bc0-90ea-030091b6280f) ApplicationDbContext clasi ichiga kirib ko'rsak siz DbContext va IApplicationDbContext interfacesida inheritance qilinganini ko'rishingiz mumkin  ![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/4edf0ff8-b336-4555-87d2-7582b499ec2a)
shu kabi nega bunday deb aytadigan bo'lsak bizning University.Service Layerida ApplicationDbContextdan emas balki IApplicationDbContext interfacesi yordamida databazaga querylar jo'natishimizni ko'rishingiz mumkin va shu bilan DataAccess qismi ham o'z nihoyasiga yetdi,
Endi sizlar University.Serviec Layerini tanishtirib o'taman bu Layerda bizning nimalarimiz joylashadi shularni aytib o'taman ->  ![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/6aaf192a-6417-4e4e-ad16-f82383fa29a9)

Abstractions -> ichida bizning interfacelarimiz va shunga o'xshash mavhum narsalar saqlanadi IApplicationDbContext ham shu yerda joylashgan ![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/78dba1ca-3583-48e6-a312-d90598bb75f4)
shu ko'rinishda bo'ladi.
Securtity -> papkasi ichida bizning PasswordHashlash uchun algoritmimiz joylashga. Password Hashlash uchun Hash512 Algoritmi bo'yicha Passwordlarimiz Hashlangan ![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/b09d0203-1b05-402c-8a82-c77e0e5075bf)
