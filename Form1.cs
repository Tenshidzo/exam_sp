using System.Text.RegularExpressions;

namespace exam
{

    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnSearch.Click += btnSearch_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    cmbDrives.Items.Add(drive.Name);
                }
            }
            if (cmbDrives.Items.Count > 0)
            {
                cmbDrives.SelectedIndex = 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbDrives.SelectedItem != null && !string.IsNullOrWhiteSpace(txtMask.Text))
            {
                lstResults.Items.Clear();
                progressBar.Value = 0;
                string selectedDrive = cmbDrives.SelectedItem.ToString();
                string mask = txtMask.Text;

                Task.Run(() => SearchFilesAndFolders(selectedDrive, mask));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите диск и введите маску.");
            }
        }
        private void SearchFilesAndFolders(string root, string mask)
        {
            Invoke(new Action(() => progressBar.Style = ProgressBarStyle.Marquee));
            HashSet<string> results = new HashSet<string>();
            try
            {
                // Проверка доступа к корневому каталогу
                if (Directory.Exists(root))
                {
                    SearchDirectory(root, mask, results);
                }
                else
                {
                    Invoke(new Action(() => MessageBox.Show("Корневой каталог не существует.")));
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Произошла ошибка: " + ex.Message)));
            }

            Invoke(new Action(() => UpdateResults(results)));
        }
        private void SearchDirectory(string dir, string mask, HashSet<string> results)
        {
            try
            {
                var files = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly)
                                     .Where(f => IsMatch(Path.GetFileName(f), mask));
                foreach (var file in files)
                {
                    results.Add(file);
                }
                var directories = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly)
                                           .Where(d => IsMatch(Path.GetFileName(d), mask));
                foreach (var directory in directories)
                {
                    results.Add(directory);
                }

                foreach (var subdir in Directory.GetDirectories(dir))
                {
                    SearchDirectory(subdir, mask, results);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Игнорируем папки, к которым нет доступа
            }
            catch (DirectoryNotFoundException)
            {
                // Игнорируем папки, которые не найдены
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Произошла ошибка: " + ex.Message)));
            }
        }

        private bool IsMatch(string fileName, string mask)
        {
            string pattern = "^" + Regex.Escape(mask).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
            return Regex.IsMatch(fileName, pattern, RegexOptions.IgnoreCase);
        }

        private void UpdateResults(HashSet<string> results)
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;

            foreach (var result in results)
            {
                lstResults.Items.Add(result);
            }

            MessageBox.Show("Поиск завершён.");
        }
    }
}

