using System.IO;
using System.Windows.Forms;
using static KINO.KinoLogic;

namespace KINO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            getImges();

        }

        private List<Kino> KinoList = new List<Kino>();

        private List<Image> ImageListEnd = new List<Image>();

        private List<Image> ImageListTV = new List<Image>();

        private List<Image> ImageListMovie = new List<Image>();

        private List<Image> ImageListSerial = new List<Image>();


        private void btnRefill_Click(object sender, EventArgs e)
        {
            
            this.KinoList.Clear();
            kinoBox.Image = null;
           
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) 
                {
                    case 0: 
                        this.KinoList.Add(new TVshow(rnd.Next(1950, 2024), rnd.Next(1, 40), rnd.Next(10, 60)));
                        break;
                    case 1: 
                        this.KinoList.Add(new Movie(rnd.Next(1920, 2024) ,rnd.Next(1,5),rnd.Next(30, 360), rnd.Next(0, 12) ));
                        break;
                    case 2: 
                        this.KinoList.Add(new Show (rnd.Next(1960, 2024),rnd.Next(1, 50), rnd.Next(4, 1000)));
                        break;
                       
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
                
                if (kino is TVshow) 
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


        private void getImges()
        {

            foreach (var fileName in Directory.GetFiles(@"..\..\..\..\img\end", "*.*"))
            {
                try
                {
                    Bitmap image = new Bitmap(fileName, true);

                    ImageListEnd.Add(image);
         

                }
                catch (ArgumentException)
                {
                    MessageBox.Show("wrong file format or filename by end");
                }
            }

            foreach (var fileName in Directory.GetFiles(@"..\..\..\..\img\tv", "*.*"))
            {
                try
                {
                    Bitmap image = new Bitmap(fileName, true);
         
                    ImageListTV.Add(image);
                 
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("wrong file format or filename by tv");
                }
            }

            foreach (var fileName in Directory.GetFiles(@"..\..\..\..\img\movie", "*.*"))
            {
                try
                {
                    Bitmap image = new Bitmap(fileName, true);
              
                    ImageListMovie.Add(image);

                }
                catch (ArgumentException)
                {
                    MessageBox.Show("wrong file format or filename by movie");
                }
            }

            foreach (var fileName in Directory.GetFiles(@"..\..\..\..\img\serial", "*.*"))
            {
                try
                {
                    Bitmap image = new Bitmap(fileName, true);
   
                    ImageListSerial.Add(image);

                }
                catch (ArgumentException)
                {
                    MessageBox.Show("wrong file format or filename by serial");
                }
            }


        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            
            var rnd = new Random();
          
            if (this.KinoList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                kinoBox.Image = ImageListEnd[rnd.Next(0, ImageListEnd.Count)];
                return;
            }

      
            var kino = this.KinoList[0];

            if (kino is TVshow)
            {
                kinoBox.Image = ImageListTV[rnd.Next(0, ImageListTV.Count)];
                
            }
            else if (kino is Movie)
            {
                kinoBox.Image = ImageListMovie[rnd.Next(0, ImageListMovie.Count)];
                
            }
            else if (kino is Show)
            {
                kinoBox.Image = ImageListSerial[rnd.Next(0, ImageListSerial.Count)];
            }
            


            this.KinoList.RemoveAt(0);

            this.KinoBar.Value = KinoList.Count;

            txtOut.Text = kino.GetInfo();
         
            ShowInfo();
        }
    }
}
