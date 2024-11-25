namespace FrogsWinForms
{
    public partial class MainForm : Form
    {
        int countJumps = 0;
        List<PictureBox> leftFrogs = new List<PictureBox>();
        List<PictureBox> rightFrogs = new List<PictureBox>();
        public MainForm()
        {
            InitializeComponent();
            jumpsLabel.Text = countJumps.ToString();
            leftFrogs.Add(LeftPictureBox1);
            leftFrogs.Add(LeftPictureBox2);
            leftFrogs.Add(LeftPictureBox3);
            leftFrogs.Add(LeftPictureBox4);
            rightFrogs.Add(RightPictureBox1);
            rightFrogs.Add(RightPictureBox2);
            rightFrogs.Add(RightPictureBox3);
            rightFrogs.Add(RightPictureBox4);
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var distance = Math.Abs(clickedPictureBox.Location.X - EmptyPictureBox.Location.X) / EmptyPictureBox.Width;
            if (distance > 2)
            {
                SoundHelper.Play(@"noway.wav");
                MessageBox.Show("Слишком далеко!");
            }
            else
            {
                SoundHelper.Play(@"kva.wav");
                var location = clickedPictureBox.Location;
                clickedPictureBox.Location = EmptyPictureBox.Location;
                EmptyPictureBox.Location = location;
                countJumps++;
                jumpsLabel.Text = countJumps.ToString();
                if (End())
                {
                    SoundHelper.Play(@"pobednaya_pesn.wav");
                    var result = MessageBox.Show(ResultMessage(), "Результат игры", MessageBoxButtons.OK);
                    if (result == DialogResult.OK) {Start(); }
                }
            }
        }

        private void начатьСначалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rules = new RulesForm();
            rules.ShowDialog();
        }

        private string ResultMessage()
        {
            if (countJumps <= 24)
            {
                return "Поздравляем, вы выиграли за минимальное количество ходов(24)!";
            }
            else
            {
                return "Поздравляем! вы выиграли, но можно было потратить меньше ходов.";
            }
        }

        private void Start()
        {
            countJumps = 0;
            jumpsLabel.Text = countJumps.ToString();
            LeftPictureBox1.Location = new Point(0, 57);
            LeftPictureBox2.Location = new Point(100, 57);
            LeftPictureBox3.Location = new Point(200, 57);
            LeftPictureBox4.Location = new Point(300, 57);
            EmptyPictureBox.Location = new Point(400, 57);
            RightPictureBox1.Location = new Point(500, 57);
            RightPictureBox2.Location = new Point(600, 57);
            RightPictureBox3.Location = new Point(700, 57);
            RightPictureBox4.Location = new Point(800, 57);
        }
        private bool End()
        {
            var leftGoRight = true;
            var rightGoLeft = true;
            foreach (var frog in leftFrogs)
            {
                if (frog.Location.X <= 400)
                {
                    leftGoRight = false;
                }
            }
            foreach (var frog in rightFrogs)
            {
                if (frog.Location.X >= 400)
                {
                    rightGoLeft = false;
                }
            }
            if (leftGoRight && rightGoLeft)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

