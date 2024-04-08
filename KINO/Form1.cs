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
                // помните, что в списки у нас лежат фрукты,
                // то есть объекты типа Fruit
                // поэтому чтобы проверить какой именно фрукт
                // мы в данный момент обозреваем, мы используем ключевое слово is
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

        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.KinoList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                return;
            }

            // взяли первый фрукт
            var kino = this.KinoList[0];
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что если хочешь удалить, делай это сам
            this.KinoList.RemoveAt(0);

            // ну а теперь предложим покупателю его фрукт
            txtOut.Text = kino.GetInfo();


            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
    }
}
