using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ApkgEditor.Structure
{
    /// <summary>
    /// Col: Contains a single row that holds various information about the collection
    /// </summary>
    public partial class Col
    {
        public long Id { get; set; }
        public long Crt { get; set; }
        public long Mod { get; set; }
        public long Scm { get; set; }
        public long Ver { get; set; }
        public long Dty { get; set; }
        public long Usn { get; set; }
        public long Ls { get; set; }
        public string Conf { get; set; }
        
        public List<Deck> Decks { get; set; }
        /// <summary>
        /// Return models in JSON format
        /// </summary>
        public string JModels
        {
            get => JsonHelper.GetJson(Model);
            set
            {
                Model = JsonHelper.GetObjs<Model>(value);
            }
        }

        /// <summary>
        /// Return decks in JSON format
        /// </summary>
        public string JDecks
        {
            get => JsonHelper.GetJson(Decks);
            set
            {
                Decks = JsonHelper.GetObjs<Deck>(value);
            }
        }
        public string Dconf { get; set; }
        public string Tags { get; set; }
        public List<Model> Model { get; set; }
    }
}
