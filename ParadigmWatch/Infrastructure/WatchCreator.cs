using ParadigmWatch.Data;
using ParadigmWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Infrastructure
{
    public class WatchCreator
    {
        ParadigmWatchContext DB;
        public WatchCreator(ParadigmWatchContext db)
        {
            DB = db;
        }
        public void InitWatch(Watch watch)
        {
            if (watch.WatchParts.Count == 0)
            {
                AddParts(watch);
                AddTypes(watch);
                FillUpShaders(watch);
                FillUpTextures(watch);
                FillUpTextMap(watch);
            }

        }


        private void AddParts(Watch watch)
        {
            List<WatchComponents> watchComponents = DB.RelationTableWatch.Where(item => item.WatchId == watch.Id).ToList();

            List<WatchPart> watchParts = new List<WatchPart>();
            watchComponents.ForEach(item => watchParts.Add(DB.WatchParts.Find(item.WatchPartId)));
            watchParts.ForEach(item => watch.AddComponent(item));
        }

        private void AddTypes(Watch watchvm)
        {
            List<WatchPartType> Types = DB.WatchPartyTypes.ToList();

            watchvm.WatchParts.ForEach(part => part.PartType = Types.Find(type => type.Id == part.TypeId));
        }

        private void FillUpTextures(Watch watchvm)
        {
            List<Texture> Textures = DB.Textures.ToList();

            watchvm.WatchParts.ForEach(part => part.TextureMap = Textures.Find(texture => texture.Id == part.TextureMapId));
        }
        private void FillUpShaders(Watch watchvm)
        {
            List<StandardShader> Shaders = DB.StandardShaders.ToList();

            watchvm.WatchParts.ForEach(part => part.Shader = Shaders.Find(shader => shader.Id == part.ShaderId));
        }
        private void FillUpTextMap(Watch watchvm)
        {
            List<TextMap> Texts = DB.TextMaps.ToList();

            watchvm.WatchParts.ForEach(part => part.TextMap = Texts.Find(text => text.Id == part.TextMapId));
        }
    }
}
