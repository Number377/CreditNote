using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCreditNote
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
        }
        
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            TodoItem item = new TodoItem();
            item.DateText.Text = DateTime.Now.ToString("MM-dd");
            item.DeleteItem += new EventHandler(DeleteItem);

            TotoItemList.Children.Add(item);

            count();
        }

        // 刪除事件
        private void DeleteItem(object sender, EventArgs e)
        {
            TotoItemList.Children.Remove((TodoItem)sender);
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            // 新增一個串列裝每個項目轉成的文字
            List<string> datas = new List<string>();

            // 轉換每一個項目
            foreach (TodoItem item in TotoItemList.Children)
            {
                string line ="";

                // 加上|符號和項目文字
                line += item.DateText.Text + "|" + item.ItemNameTb.Text + "|" + item.Money.Text;

               // 加入串列中
                datas.Add(line);
            }

        // 存檔
        System.IO.File.WriteAllLines(@"C:\data.txt", datas);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 就算沒有檔案也可以正常開啟
            try
            {
                // 開檔(預設為D:\data.txt)
                string[] lines = System.IO.File.ReadAllLines(@"C:\data.txt");

                // 解析每一行
                foreach (string line in lines)
                {
                    // 用 | 符號分開
                    string[] parts = line.Split('|');

                    // 建立 TodoItem
                    TodoItem item = new TodoItem();

                    //分別讀取不同部份
                    item.DateText.Text = parts[0];
                    item.ItemNameTb.Text = parts[1];
                    item.Money.Text = parts[2];

                    // 放到清單
                    TotoItemList.Children.Add(item);
                }
            }
            catch { }
            count();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            count();
        }
        void count()
        {
            int Total = 0;
            foreach (TodoItem item in TotoItemList.Children)
            {
                try
                {
                    Total += int.Parse(item.Money.Text);
                    Totalmoney.Text = Total.ToString();
                }
                catch
                {
                    MessageBox.Show("麻煩請輸入正確的價格(整數數字)");
                }
            }
        }
    }
}
