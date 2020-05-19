using ParadigmWatch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class WatchViewModel
    {

        private ParadigmWatchContext DB;
        public Watch Watch { get; set; }

        public WatchViewModel(Watch watch, ParadigmWatchContext db)
        {
            Watch = watch;
            DB = db;
            InitWatch();
            Console.WriteLine(Watch);
        }


        private void InitWatch()
        {
            AddParts();
            AddTypes();
            FillUpShaders();
            FillUpTextures();
            FillUpTextMap();
        }


        private void AddParts()
        {
            List<WatchComponents> watchComponents = DB.RelationTableWatch.Where(item => item.WatchId == this.Watch.Id).ToList();

            List<WatchPart> watchParts = new List<WatchPart>();
            watchComponents.ForEach(item => watchParts.Add(DB.WatchParts.Find(item.WatchPartId)) );
            watchParts.ForEach(item => this.Watch.AddComponent(item));
        }

        private void AddTypes()
        {
            List<WatchPartType> Types = DB.WatchPartyTypes.ToList();

            Watch.WatchParts.ForEach(part => part.PartType = Types.Find(type => type.Id == part.TypeId));
        }

        private void FillUpTextures()
        {
            List<Texture> Textures = DB.Textures.ToList();

            Watch.WatchParts.ForEach(part => part.TextureMap = Textures.Find(texture => texture.Id == part.TextureMapId));
        }
        private void FillUpShaders()
        {
            List<StandardShader> Shaders = DB.StandardShaders.ToList();

            Watch.WatchParts.ForEach(part => part.Shader = Shaders.Find(shader => shader.Id == part.TextureMapId));
        }
        private void FillUpTextMap()
        {
            List<TextMap> Texts = DB.TextMaps.ToList();

            Watch.WatchParts.ForEach(part => part.TextMap = Texts.Find(text => text.Id == part.TextMapId));
        }
    }
}
