using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniProject1
{
    [Serializable]
    class SeriesEpisode
    {
        private static List<SeriesEpisode> extent = new List<SeriesEpisode>();

        private string name;
        private string description;

        private Series series;

        [Required]
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Empty field specified. Field name is mandatory!");
                else name = value;
            }
        }

        [Required]
        public Series Series
        {
            get { return series; }
            set
            {
                if (series == value) return;

                if (series is not null)
                {
                    if (value is null)
                    {
                        // Remove connection
                        var tmp = series;
                        series = null;
                        tmp.RemoveEpisode(this);
                        extent.Remove(this);
                    }
                    else
                    {
                        throw new ArgumentException("Cannot change series association");
                    }
                }
                else
                {
                    if (value is not null)
                    {
                        // Create connection
                        series = value;
                        value.AddEpisode(this);
                    }
                }

            }
        }

        public string Description { get { return description; } set { description = value; } }

        public static List<SeriesEpisode> Extent { get { return new List<SeriesEpisode>(extent); } }

        //constructor
        public SeriesEpisode(Series series, string name, string description = "")
        {
            Series = series;
            Name = name;
            Description = description;

            extent.Add(this);
        }

        public override string ToString()
        {
            return $"{this.GetType()} [name: {name}; description: {description}; series: {series}]";
        }


    }
}
