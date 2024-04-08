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
                    case 0: // ���� 0, �� ��������
                        this.KinoList.Add(new TVshow(rnd.Next(1950, 2024), rnd.Next(1, 40), rnd.Next(10, 60)));
                        break;
                    case 1: // ���� 1 �� ��������
                        this.KinoList.Add(new Movie(rnd.Next(1920, 2024) ,rnd.Next(1,5),rnd.Next(30, 360), rnd.Next(0, 12) ));
                        break;
                    case 2: // ���� 2 �� �����
                        this.KinoList.Add(new Show (rnd.Next(1960, 2024),rnd.Next(1, 50), rnd.Next(4, 1000)));
                        break;
                        // ��������� ������ ����� ������������
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            // ������� �������� ��� ������ ���
            int TVshowCount = 0;
            int MovieCount = 0;
            int ShowCount = 0;

            // ��������� �� ����� ������
            foreach (var kino in this.KinoList)
            {
                // �������, ��� � ������ � ��� ����� ������,
                // �� ���� ������� ���� Fruit
                // ������� ����� ��������� ����� ������ �����
                // �� � ������ ������ ����������, �� ���������� �������� ����� is
                if (kino is TVshow) // �������� ����� ��� ������ ������, "���� fruit ���� ��������"
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

            // � �� � ������� ��� ��� ���� �� �����
            txtInfo.Text = "��\t�����\t������"; // ����� ������, ����� ������ �� �����
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", TVshowCount, MovieCount, ShowCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // ���� ������ ����, �� ������� ��� ����� � ������ �� �������
            if (this.KinoList.Count == 0)
            {
                txtOut.Text = "����� Q_Q";
                return;
            }

            // ����� ������ �����
            var kino = this.KinoList[0];
            // ��� ��� �� ����������, ������ ��� �� ����� ���� �������� ��������� �� ������� � ������
            // ��� �������� ��������� ������, ��� ��� ���� ������ �������, ����� ��� ���
            this.KinoList.RemoveAt(0);

            // �� � ������ ��������� ���������� ��� �����
            txtOut.Text = kino.GetInfo();


            // ������� ���������� � ���������� ������ �� �����
            ShowInfo();
        }
    }
}
