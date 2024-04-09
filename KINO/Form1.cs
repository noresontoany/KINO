using System.Windows.Forms;
using static KINO.KinoLogic;

namespace KINO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Kino> KinoList = new List<Kino>();

        private void btnRefill_Click(object sender, EventArgs e)
        {

            this.KinoList.Clear();
           
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) 
                {
                    case 0: // если 0, то мандарин
                        this.KinoList.Add(new TVshow(rnd.Next(1950, 2024), rnd.Next(1, 40), rnd.Next(10, 60)));
                        break;
                    case 1: // если 1 то виноград
                        this.KinoList.Add(new Movie(rnd.Next(1920, 2024) ,rnd.Next(1,5),rnd.Next(30, 360), rnd.Next(0, 12) ));
                        break;
                    case 2: // если 2 то арбуз
                        this.KinoList.Add(new Show (rnd.Next(1960, 2024),rnd.Next(1, 50), rnd.Next(4, 1000)));
                        break;
                        // появление других чисел маловероятно
                }
            }
            this.KinoBar.Maximum = KinoList.Count;
            this.KinoBar.Value = KinoList.Count;

            ShowInfo();
        }

        private void ShowInfo()
        {
            // заведем счетчики под каждый тип
            int TVshowCount = 0;
            int MovieCount = 0;
            int ShowCount = 0;

            // пройдемся по всему списку
            foreach (var kino in this.KinoList)
            {
                
                if (kino is TVshow) // читается почти как чистый инглиш, "если fruit есть Мандарин"
                {
                    TVshowCount += 1;
                }
                else if (kino is Movie)
                {
                    MovieCount += 1;
                }
                else if (kino is Show)
                {
                    ShowCount += 1;
                }
            }

            // а ну и вывести все это надо на форму
            txtInfo.Text = "ТВ\tФильм\tСериал"; // буквы экнмлю, чтобы влезло на форму
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", TVshowCount, MovieCount, ShowCount);
        }


        private void getImg (String pathToFile)
        {
            try
            {
                // Retrieve the image.
                Bitmap image = new Bitmap(@"img\tv\2.jpg", true);

                int x, y;

                // Loop through the images pixels to reset color.
                for (x = 0; x < image.Width; x++)
                {
                    for (y = 0; y < image.Height; y++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                        image.SetPixel(x, y, newColor);
                    }
                }

                kinoBox.Image = image;
            }
   
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the image file.");
            }

            


        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.KinoList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";

                getImg(@"img\0.jpg");
                return;
            }

            // взяли первый фрукт
            var kino = this.KinoList[0];

            if (kino is TVshow)
            {
                getImg(@"img\tv\2.jpg");
                //kinoBox.Image = getImg(string.Format("img\\tv\\{0}.jpg", rnd.Next(1, 10)));
            }
            else if (kino is Movie)
            {
                getImg(@"img\tv\2.jpg");
                //kinoBox.Image = getImg(string.Format("img\\movie\\{0}.jpg", rnd.Next(1, 10)));
            }
            else if (kino is Show)
            {
                //kinoBox.Image = getImg(string.Format("img\\serial\\{0}.jpg", rnd.Next(1, 10)));
            }
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что если хочешь удалить, делай это сам
            this.KinoList.RemoveAt(0);
            this.KinoBar.Value = KinoList.Count;
            // ну а теперь предложим покупателю его фрукт
            txtOut.Text = kino.GetInfo();


            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
    }
}
