Assalomu aleykum mening bu loyiham imtihon uchun microservicelar bilan ishlash va o'rgangan yangiliklarimizni projectda qo'llash edi.
Mega imtihon uchun qilish kerak bo'lgan projectlar 4 ta edi: 1.University, 2.School, 3.Cadastre, 4.Jamoat Transporti

![Screenshot 2023-12-09 021549](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/fb7889d6-85c8-4e3f-ab1a-839ff071ae85)

Hozir ketma-ketligida bu projectlarni tanishtirishni boshlayman. 
1. University
Bu projectda N-Tier Architectureda Foydalanganmiz
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/2c65b3e3-5bbe-4b35-bebe-dc2767828477)

University.Domain qismida bizning CustomAttributelarimiz,Dtolarimiz,entitylar,Enumalar va Custom Exceptionlar mavjud 
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/8a082de0-eb0a-42eb-9540-4104709c4533)
Bu projectda ishlatilgan Entitylarni tepadagi rasmda ko'rib olishingiz mumkin shu bilan Domain qismi tugaydi. Endi esa University.DataAccess qismiga o'tamiz Bu yerda bizning DataBasega Connect qilish qismi va Migrationlarimiz,EntityTypeConfiguratsiyalar turadi va shunga o'xshash databasega oid narsalar shu yerda joylashagan bo'ladi 
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/cbafac72-e978-4bc0-90ea-030091b6280f) ApplicationDbContext clasi ichiga kirib ko'rsak siz DbContext va IApplicationDbContext interfacesida inheritance qilinganini ko'rishingiz mumkin  
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/4edf0ff8-b336-4555-87d2-7582b499ec2a)
shu kabi nega bunday deb aytadigan bo'lsak bizning University.Service Layerida ApplicationDbContextdan emas balki IApplicationDbContext interfacesi yordamida databazaga querylar jo'natishimizni ko'rishingiz mumkin va shu bilan DataAccess qismi ham o'z nihoyasiga yetdi,
Endi sizlar University.Serviec Layerini tanishtirib o'taman bu Layerda bizning nimalarimiz joylashadi shularni aytib o'taman ->  
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/6aaf192a-6417-4e4e-ad16-f82383fa29a9)

Abstractions -> ichida bizning interfacelarimiz va shunga o'xshash mavhum narsalar saqlanadi IApplicationDbContext ham shu yerda joylashgan
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/78dba1ca-3583-48e6-a312-d90598bb75f4)
shu ko'rinishda bo'ladi.
Securtity -> papkasi ichida bizning PasswordHashlash uchun algoritmimiz joylashga. Password Hashlash uchun Hash512 Algoritmi bo'yicha Passwordlarimiz Hashlangan
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/b09d0203-1b05-402c-8a82-c77e0e5075bf)
Va bu yerda BackGround Service dan ham foydalanilgan Vazifasini aytib o'tadigan bo'lsam -> har 10 sekundda bizning studentlar joylashgan keshni yangilab turish uchun yozilgan 
UseCases qismida bizning asosiy logikalar joylashgan  yani bu yerda barcha Crud lar bazaga yozish o'chirish o'qish yangilash kabi vazifalarni bajaradi bu amallarni bajarish uchun men MediatR design Patternida foydalanilganman, Har bitta Modelni Commandi,Queryi va Handleri bo'ladi Commands qimida -> bazaga yozish,o'chirish,yangilash kabi amallarning Commandi yoziladi yanada tushunarli qilib aytadigan bo'lsam Dto vazifasini o'taydi bizga shu command kirib keladi userdan va bu Comman IRequest<> interfacedan inheritance olgan bo'lishi kerak bo'ladi 
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/89da5233-8818-40a9-a260-d1e17ff85931)
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/b322364f-4c50-400b-8cba-a8a8515bb76d)
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/7df999a2-9b96-4c43-9dec-f241fd269e7d)

Shu kabi bo'ladi IRequest bu generic interface bo'lib genericiga biz type berib yuboramiz va o'sha tipda ma'lumot qaytarish kerak bo'ladi

Queries qismiga keladigan bo'lsak bu yerda bizning faqatgina Get operatsiyamiz bajariladi faatgina get -> 
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/f7492f8b-f6cd-48c3-a214-75d8c3a24381)
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/7b03ce6a-7a22-410b-8faf-227b7e70cc52)
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/4b2fa9dd-28b7-46db-81b5-701b8784e867)

shu kabi bo'ladi bu ham huddi commanga o'hashydi

Endi esa eng asosiy qismi Handler qismi -> bu qismida bizning bu command va querylarning realizatsiya bo'ladi haqiqiy bazaga murojatlar shu yerda bo'ladi 
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/b29b605e-5ff6-4b4f-b7ae-fddbd06ce4fc)

Bu GetAdminByIdQueryHandler clasimiz IRequestHandler<> generic classdan inheritance olgan bo'lishi kerak bo'ladi va birinchi paramertiga command yoki query beriladi yani qaysi command yoki queryning realzatisya bo'layotganligi aytib o'tiladi ikkinchi parametriga esa qaytuvchi tipi beriladi bu interfaceni birgina Handle methodi mavjud shu qismda logikani bosaveramiz.

Menimcha sizga oz bo'lsada mediatrR ning ishlash jarayonini tushuntira oldim deb o'ylayman ha aytgancha agarda siz mediatR ni dasturingizda implement qilmoqchi bo'lsangiz quyidagi packeglarni o'rnatishingiz kerak bo'ladi
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/b47167b8-712f-439d-80bc-494b387524b1)
shu ikkisni va Program.cs da buning registrationdan o'tkazib qo'yish kerak bo'ladi 
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/45643928-4d42-4f12-a658-0485e3e1ddae)

Shu bilan bizning Service Layerimiz o'z nihoyasiga yetdi keyingi qism University.Api qismi bo'ladi bu Layerda Faqat Controller mavjud endi bu yerda bizning yozgan servicelarimizni yani ishlatib ko'ramiz yani MediatRni ishlatib ko'ramiz birinchi navbatda Controllerning Constructida register qilib olamiz
![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/2b558d9b-47d9-42f2-a7cd-de96f80f9be5)

Birinchi bo'lib GetById ni ishlatishni ko'rib o'tamiz 

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/78757fa7-6645-48cc-9ae6-9bded6bd1237)

Get All 

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/40a0a202-17f2-4567-9005-feaecc01800a)

Post Async

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/d80e678d-9bce-42ed-ad09-bfa80be47fc3)


shu kabi mediatR ishlaydi _mediatorga.Send() qilaveramiz bu esa bergan command yoki query bo'yicha uzi topib boradi

Yana bir ajoyib jihatlardan biri biz barcha biz FileServicedan foydalanilganmiz bunda user o'zining imagelarini yuklab uni swaggerda ko'rishi mumkin, bu service qanday ishlaydi? user uzining imagesini post qilganda unga Guid qilib uniue name yaratib beradi -> bu nom image nomi uchun va bazada shu userNing imagePath i saqlanadi rasming haqiqiy shakli esa localda joylashgan bo'ladi hozir buni ham ishlatib ko'rmiz 
Apilarimiz orasida GetImageNomli api ham mavjud

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/9b9c28b8-3557-420a-88b8-b0501617f436)

Bu Api ni hozir ishlatib ko'ramiz 

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/8fc0af9f-1c2f-42df-a3d1-242a0fa22224)

Man ko'rib turganingizdek 3 idlink Studentning rasmini chiqarib berdi 

endi siz bilan buning logikasini ko'rib chiqamiz

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/05975bba-600b-4e24-80fd-c841404db1fa)

bu imagening upload qilish jarayoni 

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/9261c293-feac-4547-91be-ed33e3b096be)

bu esa imageni Get qilib olish jarayoni 

controllerga imageni byte[] qilib berib yuboradi Controller esa 

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/420fbd00-e584-4bcc-a163-8848e4a8590c)

shu kabi swaggerga chiqarib beradi.

Shu bilan University.Api ham o'z nihoyasiga yetdi va Projectham o'z nihoyasiga yetdi

Yana bir qo'shgan o'zgarishlardan biri School.Projectdiga hohlagan bir Modelgan siz malumot Add,Update va Delete bo'lsa Telegram.Bot ga ma'lumot yuboib turuvchi qilingan u botga ma'lumot qanday boradi 

![image](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/3e1f90cb-1cd1-40aa-b532-20be09a7f212)

Cadastre Database

![Screenshot 2023-12-09 020434](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/37381d69-83d2-4877-ab7c-440b99462a0d)

School Database

![Screenshot 2023-12-09 020845](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/49b3f895-75d2-46a0-a2d4-790a577ee724)

Transport Database

![Screenshot 2023-12-09 023520](https://github.com/Berdikulov-571/Exam-Microservice/assets/125897994/02da1b82-103d-42a8-9789-39df26cf953e)

Va ApiGetaway ham yozilgan  
shu ko'rinishda va Globalniy Avtorization qo'shilgan va University Platform uchun sql Serverda Triggerlar qo'llanilgan. shu bilan Documentation o'z nihoyasiga yetdi e'tiboringiz uchun raxmat.

Agar dasturni run qilmoqchi bo'lsangiz.
1. Redisni ishga tushurish
2. Barcha Platformdagi appsettings.jsondagi connectionStringlarni o'zgartirish kerak bo'ladi
3. Barcha Platformdagi migrationlarni o'chirish va qaytatdan Migration qilish kerak bo'ladi -> update-database
4. Telegram bot da o'zingizni TelegramBot Tokeningiz va o'zingizning ChatId yingizni yozishingiz kerak bo'ladi
5. Imagelarni ishlatish uchun C:\\Users\\...\\AppData\\Roaming\\ ga kirib media papkasini ochamiz va media papkasi ichida 3 ta papka avatars,files,images papkasini ochish talab etiladi agar sizda Users\ ning ichida appData papkasi yashirin bo'lib qolgan bo'lishi mumkin u holda uni skritniydan ochib qo'yishingiz kerak bo'ladi yoki Windows Terminal orqali kirib papkalarni ochishingiz mumkin.
6. Dasturni run qilishdan oldin multipleProject qilib run qilish kerak bo'ladi barcha Apilarni run qilib olish kerak bo'ladi 
