using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO
{
    public class KinoLogic
    {
        public class Fruit {
            public int Ripeness = 0;
            public virtual String GetInfo()
            {
                var str = String.Format("\nСпелость: {0}", this.Ripeness);
                return str;
            }
        }

        public class Mandarin : Fruit
        {
            public int SliceCount = 0;
            public bool WithLeaf = false;

            public override String GetInfo()
            {
                var str = "Я мандарин";
                str += base.GetInfo();
                // Добавил
                str += String.Format("\nКоличество долек: {0}", this.SliceCount);
                str += String.Format("\nНаличие листика: {0}", this.WithLeaf);
                return str;
            }
        }

        public enum GrapesType { black, green };
        public class Grapes : Fruit
        {
            public int BerriesNumber = 0;
            public GrapesType type = GrapesType.black;

            public override String GetInfo()
            {
                var str = "Я Виноград";
                str += base.GetInfo();
                // Добавил
                str += String.Format("\nКоличество ягод: {0}", this.BerriesNumber);
                str += String.Format("\nТип: {0}", this.type);
                return str;
            }
        }

        public class Watermelon : Fruit
        {
            public int BonesNumber = 0;
            public bool HasStripes = false;

            public override String GetInfo()
            {
                var str = "Я Арбуз";
                str += base.GetInfo();
                // Добавил
                str += String.Format("\nКоличество косточек: {0}", this.BonesNumber);
                str += String.Format("\nНаличие полосок: {0}", this.HasStripes);
                return str;
            }
        }
    }
}
