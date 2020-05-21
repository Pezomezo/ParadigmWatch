using ParadigmWatch.Data;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;
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
        public void InitWatch(WatchViewModel watch)
        {
            AddParts(watch);
            AddTypes(watch);
            FillUpShaders(watch);
            FillUpTextures(watch);
            FillUpTextMap(watch);
        }


        private void AddParts(WatchViewModel watchvm)
        {
            List<WatchComponents> watchComponents = DB.RelationTableWatch.Where(item => item.WatchId == watchvm.Watch.Id).ToList();

            List<WatchPart> watchParts = new List<WatchPart>();
            watchComponents.ForEach(item => watchParts.Add(DB.WatchParts.Find(item.WatchPartId)));
            watchParts.ForEach(item => watchvm.Watch.AddComponent(item));
        }

        private void AddTypes(WatchViewModel watchvm)
        {
            List<WatchPartType> Types = DB.WatchPartyTypes.ToList();

            watchvm.Watch.WatchParts.ForEach(part => part.PartType = Types.Find(type => type.Id == part.TypeId));
        }

        private void FillUpTextures(WatchViewModel watchvm)
        {
            List<Texture> Textures = DB.Textures.ToList();

            watchvm.Watch.WatchParts.ForEach(part => part.TextureMap = Textures.Find(texture => texture.Id == part.TextureMapId));
        }
        private void FillUpShaders(WatchViewModel watchvm)
        {
            List<StandardShader> Shaders = DB.StandardShaders.ToList();

            watchvm.Watch.WatchParts.ForEach(part => part.Shader = Shaders.Find(shader => shader.Id == part.ShaderId));
        }
        private void FillUpTextMap(WatchViewModel watchvm)
        {
            List<TextMap> Texts = DB.TextMaps.ToList();

            watchvm.Watch.WatchParts.ForEach(part => part.TextMap = Texts.Find(text => text.Id == part.TextMapId));
        }
    }
}
