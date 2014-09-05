namespace TelerikAcademyForum
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    internal class Question
    {
        [JsonProperty("question")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\n\tCategory:{1}\n\tDescription: {2}", this.Title, this.Category, this.Description);
        }
    }
}