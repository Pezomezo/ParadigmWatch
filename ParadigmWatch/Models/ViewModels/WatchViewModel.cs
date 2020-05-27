using ParadigmWatch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class WatchViewModel
    {
        public List<WatchInitModel> WatchInitModel = new List<WatchInitModel>();
        public Watch Watch { get; set; }
        public List<WatchPart> AllParts { get; set; } = new List<WatchPart>();



        public WatchViewModel(Watch watch)
        {
            Watch = watch;

        }

        public void AddPart(WatchPart part)
        {
            this.AllParts.Add(part);
        }


        public void fillWatch()
        {
            AllParts.ForEach(item => WatchInitModel.Add(new WatchInitModel
            {
                Price = item.TextureMap.TexturePrice,
                Name = item.Name,
                Type = item.PartType.Name,
                WatchPartId = item.Id,
                EnvMapInt = item.Shader.EnvMapIntensity,
                Metalness = item.Shader.Metalness,
                ModelPath = item.ModelPath,
                NormalMapIntensity = item.Shader.NormalMapIntensity,
                NormalMapPath = item.Shader.NormalMapPath,
                Roughness = item.Shader.Roughness,
                TextureImagePath = item.TextureMap.ImagePath,
                TypeId = item.TypeId,
                isSelected = Watch.WatchParts.Contains(item)

            }));
            


            
            
        }

    }
}
