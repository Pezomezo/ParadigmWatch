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
            Texture leatherTexture = new Texture() { Id = 1, TextureName = "Leather", TextureDesc = "This Leather makes you look rich&stuff", ImagePath = "models/strap.png", TexturePrice = 12.22m };
            Texture chromeTexture = new Texture() { Id = 2, TextureName = "Chrome", TextureDesc = "Feel the Gekko", ImagePath = "models/chrome.png", TexturePrice = 15.22m };
            Texture ApolloTexture = new Texture() { Id = 3, TextureName = "Apollo Dial", TextureDesc = "Wanna be the most badass person? try this then!", ImagePath = "models/watchFrontTexture.png", TexturePrice = 33.4m };
            Texture clockHandleTexture = new Texture() { Id = 4, TextureName = "Solid Handle", TextureDesc = "You are just cruel at this point :D", ImagePath = "", TexturePrice = 120.22m };
            Texture MetalicTexture = new Texture() { Id = 5, TextureName = "Metalic", TextureDesc = "Smooth life", ImagePath = "Image/something", TexturePrice = 50.22m };
            Texture GoldTexture = new Texture() { Id = 6, TextureName = "Gold", TextureDesc = "If you are into that Pimpin' lifestyle", ImagePath = "Image/something", TexturePrice = 250.22m };
            Texture empty = new Texture() { Id = 0, TextureName = "", TextureDesc = "", ImagePath = "", TexturePrice = 0m };

            // Here come the different shaders
            StandardShader LeatherShader = new StandardShader() { Id = 1, Metalness = 0m, NormalMapIntensity = 0.1m, NormalMapPath = "models/strap.png", Roughness = 0.3m };
            StandardShader ChromeShader = new StandardShader() { Id = 2, Metalness = 1m, NormalMapIntensity = 0.1m, NormalMapPath = "models/chrome.png", Roughness = 0.15m };
            StandardShader ApolloShader = new StandardShader() { Id = 3, Metalness = 0m, NormalMapIntensity = 0m, NormalMapPath = "", Roughness = 0.5m };
            StandardShader clockHandleShader = new StandardShader() { Id = 4, Metalness = 1m, NormalMapIntensity = 0m, NormalMapPath = "", Roughness = 0m };
            StandardShader emptyShader = new StandardShader() { Id = 5, Metalness = 0m, NormalMapIntensity = 0m, NormalMapPath = "", Roughness = 0m };

            // Here come the different TextMaps (If any cause I am not sure ask Robi :D)
            TextMap baseText = new TextMap() { Id = 1, ImagePath = "Image/something" };

            // Create the different Watch Components
            /*
             back 
             base
             ring
             glass
             background
             pointers
             sleeves
             thingy
             */

            //WatchPart Pattern = new WatchPart() { Id = 1, Name = "Apollo", TextureMap = ApolloTexture, Shader = ApolloShader, TextMap = baseText, ComponentType = WatchTypes.Pattern };
            //WatchPart BackSide = new WatchPart() { Id = 2, Name = "Chrome Back part", TextureMap = chromeTexture, Shader = ChromeShader, TextMap = baseText, ComponentType = WatchTypes.BackSide };
            //WatchPart BaseComponent = new WatchPart() { Id = 3, Name = "Chrome Base", TextureMap = chromeTexture, Shader = ChromeShader, ComponentType = WatchTypes.BaseComponent };
            //WatchPart Decoration = new WatchPart() { Id = 4, Name = "Chrome Decorations", TextureMap = chromeTexture, Shader = ChromeShader, TextMap = baseText, ComponentType = WatchTypes.Decoration };
            //WatchPart Pointers = new WatchPart() { Id = 5, Name = "Silver Pointer",TextureMap = clockHandleTexture, Shader = clockHandleShader, ComponentType = WatchTypes.Pointers};
            //WatchPart Sleeves = new WatchPart() { Id = 6, Name = "Sleeves", TextureMap = leatherTexture, Shader = LeatherShader, ComponentType = WatchTypes.Sleeves };
            //WatchPart Glass = new WatchPart() { Id = 7, Name = "Glass", TextureMap = empty, Shader = emptyShader, ComponentType = WatchTypes.Glass};
            //WatchPart Ring = new WatchPart() { Id = 8, Name = "Chrome Ring", TextureMap = chromeTexture, Shader = ChromeShader, ComponentType = WatchTypes.Ring };




            // Build up the watches here  ----> Dont forget to populate the Watches list with your newly added watch at the bottom!
            //Watch SimpleWatch = new Watch() { Id = 1, Name = "Apollo", Description = "This is a basic model you can configure it to your liking", WatchImagePath = "Apollo.png", ModelPath="models/Watch.gltf",  Price = 100.50m };
            //SimpleWatch.AddComponent(Pattern);
            //SimpleWatch.AddComponent(BackSide);
            //SimpleWatch.AddComponent(BaseComponent);
            //SimpleWatch.AddComponent(Decoration);
            //SimpleWatch.AddComponent(Pointers);
            //SimpleWatch.AddComponent(Sleeves);
            //SimpleWatch.AddComponent(Glass);
            //SimpleWatch.AddComponent(Ring);

            //// Build up the watches here  ----> Dont forget to populate the Watches list with your newly added watch at the bottom!

            //Watch JunoWatch = new Watch() { Id = 2, Name = "Juno", Description = "Exciting Views, Fresh look, and has a deeper meaning by visualizing the flow of time.", WatchImagePath = "Juno.png", ModelPath = "Models/somethibg", Price = 100.50m };
            //JunoWatch.AddComponent(Pattern);
            //JunoWatch.AddComponent(BackSide);
            //JunoWatch.AddComponent(BaseComponent);
            //JunoWatch.AddComponent(Decoration);
            //JunoWatch.AddComponent(Pointers);
            //JunoWatch.AddComponent(Sleeves);
            //JunoWatch.AddComponent(Glass);
            //JunoWatch.AddComponent(Ring);
            //// Build up the watches here  ----> Dont forget to populate the Watches list with your newly added watch at the bottom!
            //Watch MercuryWatch = new Watch() { Id = 3, Name = "Mercury", Description = "A bald statemnt. That is how I would describe this watch.", WatchImagePath = "Mercury.png", ModelPath = "Models/somethibg", Price = 100.50m };
            //MercuryWatch.AddComponent(Pattern);
            //MercuryWatch.AddComponent(BackSide);
            //MercuryWatch.AddComponent(BaseComponent);
            //MercuryWatch.AddComponent(Decoration);
            //MercuryWatch.AddComponent(Pointers);
            //MercuryWatch.AddComponent(Sleeves);
            //MercuryWatch.AddComponent(Glass);
            //MercuryWatch.AddComponent(Ring);



            //// Create a User
            //AppUser Adamka = new AppUser() { Id = "sdfghjklélkjhgfd", UserName = "Adamka", Email = "pezolino19@gmail.com", City = "Pomáz", Address = "Ond utca 9", ZipCode = 2013, CreditCard = "You wish;)" };

            //// Create an Invoice and add the order item to it ----> Dont forget to populate the Invoices list with your newly added invoice at the bottom!
            //Invoice AdamkaInvoice = new Invoice() { InvoiceId = 1, OrderDate = DateTime.Now, User = Adamka };
            //AdamkaInvoice.AddOrderItem(SimpleWatch, 2);


            //// Place them into the Watches List so we can access them in the code :)
            //Watches.Add(SimpleWatch);
            //Watches.Add(JunoWatch);
            //Watches.Add(MercuryWatch);

            //// Place the invoices into the list so we can access them through the program :)
            //invoices.Add(AdamkaInvoice);
        }
    }
}
