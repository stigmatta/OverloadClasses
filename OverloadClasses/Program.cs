// See https://aka.ms/new-console-template for more information


using JournalClass;
using ShopClass;

Journal myJournal = new Journal("My Travel Journal", "A record of my travels around the world.", 2024, "380984338124", "example@email.com");
myJournal.Print();


Shop myShop = new Shop("My Shop", "A nice shop for electronics", "123 Main St", "380984338124", "info@myshop.com");
myShop.Print();
