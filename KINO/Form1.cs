using static KINO.KinoLogic;

namespace KINO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Fruit> fruitsList = new List<Fruit>();

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.fruitsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // ��������� ��������� ����� �� 0 �� 2 (�� ������� �� ������� �� 3)
                {
                    case 0: // ���� 0, �� ��������
                        this.fruitsList.Add(new Mandarin
                        {
                            Ripeness = rnd.Next() % 101
                        });
                        break;
                    case 1: // ���� 1 �� ��������
                        this.fruitsList.Add(new Grapes
                        {
                            Ripeness = rnd.Next() % 101
                        });
                        break;
                    case 2: // ���� 2 �� �����
                        this.fruitsList.Add(new Watermelon
                        {
                            Ripeness = rnd.Next() % 101
                        });
                        break;
                        // ��������� ������ ����� ������������
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            // ������� �������� ��� ������ ���
            int mandarinsCount = 0;
            int grapesCount = 0;
            int watermellonsCount = 0;

            // ��������� �� ����� ������
            foreach (var fruit in this.fruitsList)
            {
                // �������, ��� � ������ � ��� ����� ������,
                // �� ���� ������� ���� Fruit
                // ������� ����� ��������� ����� ������ �����
                // �� � ������ ������ ����������, �� ���������� �������� ����� is
                if (fruit is Mandarin) // �������� ����� ��� ������ ������, "���� fruit ���� ��������"
                {
                    mandarinsCount += 1;
                }
                else if (fruit is Grapes)
                {
                    grapesCount += 1;
                }
                else if (fruit is Watermelon)
                {
                    watermellonsCount += 1;
                }
            }

            // � �� � ������� ��� ��� ���� �� �����
            txtInfo.Text = "�����\t�����\t�����"; // ����� ������, ����� ������ �� �����
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", mandarinsCount, grapesCount, watermellonsCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // ���� ������ ����, �� ������� ��� ����� � ������ �� �������
            if (this.fruitsList.Count == 0)
            {
                txtOut.Text = "����� Q_Q";
                return;
            }

            // ����� ������ �����
            var fruit = this.fruitsList[0];
            // ��� ��� �� ����������, ������ ��� �� ����� ���� �������� ��������� �� ������� � ������
            // ��� �������� ��������� ������, ��� ��� ���� ������ �������, ����� ��� ���
            this.fruitsList.RemoveAt(0);

            // �� � ������ ��������� ���������� ��� �����
            txtOut.Text = fruit.GetInfo();


            // ������� ���������� � ���������� ������ �� �����
            ShowInfo();
        }
    }
}
