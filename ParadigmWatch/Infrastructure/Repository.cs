using Microsoft.CodeAnalysis.CSharp.Syntax;
using ParadigmWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Infrastructure
{
    public static class Repository
    {
        public static List<Watch> Watches = new List<Watch>();
        public static List<Invoice> invoices = new List<Invoice>();

        static Repository()
        {
            // Here come the different textures
            Texture leatherTexture = new Texture() { Id = 1, TextureName = "Leather", TextureDesc = "This Leather makes you look rich&stuff", ImagePath = "Image/something", TexturePrice = 12.22m };
            Texture GekkoTexture = new Texture() { Id = 2, TextureName = "Gekko", TextureDesc = "Feel the Gekko", ImagePath = "Image/something", TexturePrice = 15.22m };
            Texture CrocodileTexture = new Texture() { Id = 3, TextureName = "Crocodile", TextureDesc = "Wanna be the most badass person? try this then!", ImagePath = "Image/something", TexturePrice = 33.4m };
            Texture ElephantTexture = new Texture() { Id = 4, TextureName = "Elephant", TextureDesc = "You are just cruel at this point :D", ImagePath = "Image/something", TexturePrice = 120.22m };
            Texture MetalicTexture = new Texture() { Id = 5, TextureName = "Metalic", TextureDesc = "Smooth life", ImagePath = "Image/something", TexturePrice = 50.22m };
            Texture GoldTexture = new Texture() { Id = 6, TextureName = "Gold", TextureDesc = "If you are into that Pimpin' lifestyle", ImagePath = "Image/something", TexturePrice = 250.22m };
            Texture SilverTexture = new Texture() { Id = 7, TextureName = "Silver", TextureDesc = "The name is Bond, James Bond...", ImagePath = "Image/something", TexturePrice = 200.22m };

            // Here come the different shaders
            StandardShader baseShader = new StandardShader() { Id = 1, Metalness = 12.2m, NormalMapIntensity = 3.0m, NormalMapPath = "Image/something", Roughness = 5m };

            // Here come the different TextMaps (If any cause I am not sure ask Robi :D)
            TextMap baseText = new TextMap() { Id = 1, ImagePath = "Image/something" };

            // Create the different Watch Components
            WatchPart Sleeves = new WatchPart() { Id = 1, Name = "Sleeves", TextureMap = leatherTexture, Shader = baseShader };
            WatchPart GekkoSleeves = new WatchPart() { Id = 2, Name = "Sleeves", TextureMap = GekkoTexture, Shader = baseShader };
            WatchPart ElephantSleeves = new WatchPart() { Id = 3, Name = "Sleeves", TextureMap = ElephantTexture, Shader = baseShader };
            WatchPart Pointers = new WatchPart() { Id = 4, Name = "Pointers", TextureMap = MetalicTexture, Shader = baseShader };
            WatchPart SilverPointers = new WatchPart() { Id = 5, Name = "Pointers", TextureMap = GoldTexture, Shader = baseShader };
            WatchPart BackSide = new WatchPart() { Id = 6, Name = "BackSide", TextureMap = MetalicTexture, Shader = baseShader, TextMap = baseText };
            WatchPart GoldenBack = new WatchPart() { Id = 7, Name = "BackSide", TextureMap = GoldTexture, Shader = baseShader, TextMap = baseText };
            WatchPart BodyPart = new WatchPart() { Id = 8, Name = "TheRoundThing", TextureMap = SilverTexture, Shader = baseShader };
            WatchPart Hooks = new WatchPart() { Id = 9, Name = "Hooks", TextureMap = MetalicTexture, Shader = baseShader };

            // Build up the watches here  ----> Dont forget to populate the Watches list with your newly added watch at the bottom!
            Watch SimpleWatch = new Watch() { Id = 1, Name = "Apollo", Description = "This is a basic model you can configure it to your liking", WatchImagePath = "Apollo.png", ModelPath = "Models/somethibg", Price = 100.50m };
            SimpleWatch.AddComponent(Sleeves);
            SimpleWatch.AddComponent(SilverPointers);
            SimpleWatch.AddComponent(BackSide);
            SimpleWatch.AddComponent(BodyPart);
            SimpleWatch.AddComponent(Hooks);
            // Build up the watches here  ----> Dont forget to populate the Watches list with your newly added watch at the bottom!
            Watch JunoWatch = new Watch() { Id = 2, Name = "Juno", Description = "Exciting Views, Fresh look, and has a deeper meaning by visualizing the flow of time.", WatchImagePath = "Juno.png", ModelPath = "Models/somethibg", Price = 100.50m };
            JunoWatch.AddComponent(GekkoSleeves);
            JunoWatch.AddComponent(Pointers);
            JunoWatch.AddComponent(GoldenBack);
            JunoWatch.AddComponent(BodyPart);
            JunoWatch.AddComponent(Hooks);
            // Build up the watches here  ----> Dont forget to populate the Watches list with your newly added watch at the bottom!
            Watch MercuryWatch = new Watch() { Id = 3, Name = "Mercury", Description = "A bald statemnt. That is how I would describe this watch.", WatchImagePath = "Mercury.png", ModelPath = "Models/somethibg", Price = 100.50m };
            MercuryWatch.AddComponent(ElephantSleeves);
            MercuryWatch.AddComponent(Pointers);
            MercuryWatch.AddComponent(GoldenBack);
            MercuryWatch.AddComponent(BodyPart);
            MercuryWatch.AddComponent(Hooks);

            // Create a User
            AppUser Adamka = new AppUser() { Id = "sdfghjklélkjhgfd", UserName = "Adamka", Email = "pezolino19@gmail.com", City = "Pomáz", Address = "Ond utca 9", ZipCode = 2013, CreditCard = "You wish;)" };

            // Create an Invoice and add the order item to it ----> Dont forget to populate the Invoices list with your newly added invoice at the bottom!
            Invoice AdamkaInvoice = new Invoice() { InvoiceId = 1, OrderDate = DateTime.Now, User = Adamka };
            AdamkaInvoice.AddOrderItem(SimpleWatch, 2);


            // Place them into the Watches List so we can access them in the code :)
            Watches.Add(SimpleWatch);
            Watches.Add(JunoWatch);
            Watches.Add(MercuryWatch);

            // Place the invoices into the list so we can access them through the program :)
            invoices.Add(AdamkaInvoice);
        }
    }
}
