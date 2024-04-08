using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO
{
    public class KinoLogic
    {
        public class Kino {
            public int Year = 0;
            public virtual String GetInfo()
            {
                var str = String.Format("\n:Год выпуска {0}", this.Year);
                return str;
            }
        }

        public class TVshow : Kino
        {
            public int Duration;
            public int Airtime;

            public TVshow(int year, int duration, int airtime)
            {
                this.Year = year;
                this.Duration = duration;
                this.Airtime = airtime;
            }

            public override String GetInfo()
            {
                var str = "Я Телепередача";
                str += base.GetInfo();
                // Добавил
                str += String.Format("\nПродолжительность лет {0}", this.Duration);
                str += String.Format("\nЭфирное время", this.Airtime);
                return str;
            }
        }

  
        public class Movie : Kino
        {
            public int MovieLen;
            public int CountAwards;
            public int MovieType;

            public Movie(int Year, int MovieType, int MovieLen, int CountAwards)
            {
                this.Year = Year;
                this.MovieType = MovieType;
                this.MovieLen = MovieLen;
                this.CountAwards = CountAwards;

            }

            private Dictionary<int, string> MovieTypes = new Dictionary<int, string>()
            {
                [1] = "Drama",
                [2] = "Fantasy",
                [3] = "Historical",
                [4] = "Horror",
                [5] = "Musical",
            };

            public override String GetInfo()
            {
                var str = "Я Фильм";
                str += base.GetInfo();
                // Добавил
                str += String.Format("\nКоличество Наград: {0}", this.CountAwards);
                str += String.Format("\nХранометраж мин: {0}", this.MovieLen);
                str += String.Format("\nЖанр {0}", this.MovieTypes[MovieType]);
                return str;
            }
        }

        public class Show : Kino
        {
            public int Seasons;
            public int Series;
            public Show(int year, int seasons, int series)
            {
                Year = year;
                Seasons = seasons;
                Series = series;
            }

            public override String GetInfo()
            {
                var str = "Я Сериал";
                str += base.GetInfo();
                // Добавил
                str += String.Format("\nКоличество сезонов: {0}", this.Seasons);
                str += String.Format("\nКол-во серий серий: {0}", this.Series);
                return str;
            }
        }
    }
}
