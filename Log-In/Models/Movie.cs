using Log_In.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Log_In.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships of ActorMovie

        public List<Actor_Movie> Actor_Movie { get; set; }

        //Relationship of Cinema

        public Cinema Cinema { get; set; }
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }


        //Relationship of Producer

        public Producer Producer { get; set; }
        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }



    }
}

