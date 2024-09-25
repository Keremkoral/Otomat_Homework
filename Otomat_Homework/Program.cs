namespace Otomat_Homework
{
    namespace Otomat_Homework
    {
        class Program
        {
            static Dictionary<string, decimal> products = new Dictionary<string, decimal>
        {
            { "Kola", 5.0m },
            { "Su", 2.0m },
            { "Meyve Suyu", 3.5m },
            { "Enerji İçeceği", 7.0m }
        };

            static void Main()
            {
                string kullaniciadi = "Otomat_Homework";
                int sifre = 12345;

                // Şifre doğrulama işlemi
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Otomat bölümüne hoşgeldiniz! Şifrenizi girmek için 3 hakkınız var, eğer yapamazsanız uygulama kapanır.");
                    Console.WriteLine("Otomat işlem için şifre giriniz (" + (3 - i) + " hakkınız var):");

                    int girilenSifre;
                    bool isNumeric = int.TryParse(Console.ReadLine(), out girilenSifre);

                    if (isNumeric && girilenSifre == sifre)
                    {
                        Console.WriteLine("Giriş Başarılı");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Şifre Yanlış");
                    }

                    if (i == 2)
                    {
                        Console.WriteLine("Tüm giriş haklarınızı kullandınız, program kapanıyor.");
                        return;
                    }
                }

                // Ana Menü
                while (true)
                {
                    Console.WriteLine("1. Müşteri İşlemi");
                    Console.WriteLine("2. Admin İşlemi");
                    Console.WriteLine("3. Çıkış");
                    Console.Write("Seçiminizi yapın: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        CustomerOperation();
                    }
                    else if (choice == "2")
                    {
                        AdminOperation();
                    }
                    else if (choice == "3")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                    }
                }
            }

            static void CustomerOperation()
            {
                Console.WriteLine("Ürün Listesi:");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Key}: {product.Value} TL");
                }

                Console.Write("Bir ürün seçin: ");
                string selectedProduct = Console.ReadLine();

                if (products.ContainsKey(selectedProduct))
                {
                    decimal price = products[selectedProduct];
                    decimal insertedMoney = 0;

                    while (insertedMoney < price)
                    {
                        Console.Write("Para girin: ");
                        decimal money = decimal.Parse(Console.ReadLine());
                        insertedMoney += money;

                        if (insertedMoney < price)
                        {
                            Console.WriteLine($"Yetersiz bakiye! {price - insertedMoney} TL daha ekleyin.");
                        }
                    }

                    Console.WriteLine($"Ürün alındı: {selectedProduct}. Para Üstü: {insertedMoney - price} TL");
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün seçimi.");
                }
            }

            static void AdminOperation()
            {
                Console.WriteLine("1. Ürün Ekle");
                Console.WriteLine("2. Ürün Sil");
                Console.WriteLine("3. Fiyat Güncelle");
                Console.Write("Seçiminizi yapın: ");
                string adminChoice = Console.ReadLine();

                if (adminChoice == "1")
                {
                    AddProduct();
                }
                else if (adminChoice == "2")
                {
                    RemoveProduct();
                }
                else if (adminChoice == "3")
                {
                    UpdatePrice();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
            }

            static void AddProduct()
            {
                Console.Write("Yeni ürün ismi: ");
                string productName = Console.ReadLine();
                Console.Write("Ürün fiyatı: ");
                decimal productPrice = decimal.Parse(Console.ReadLine());
                products[productName] = productPrice;
                Console.WriteLine("Ürün eklendi.");
            }

            static void RemoveProduct()
            {
                Console.Write("Silinecek ürün ismi: ");
                string productName = Console.ReadLine();
                if (products.Remove(productName))
                {
                    Console.WriteLine("Ürün silindi.");
                }
                else
                {
                    Console.WriteLine("Ürün bulunamadı.");
                }
            }

            static void UpdatePrice()
            {
                Console.Write("Fiyat güncellenecek ürün ismi: ");
                string productName = Console.ReadLine();
                if (products.ContainsKey(productName))
                {
                    Console.Write("Yeni fiyat: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());
                    products[productName] = newPrice;
                    Console.WriteLine("Fiyat güncellendi.");
                }
                else
                {
                    Console.WriteLine("Ürün bulunamadı.");
                }
            }
        }
    }

}
