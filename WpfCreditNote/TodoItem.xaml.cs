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
    /// TodoItem.xaml 的互動邏輯
    /// </summary>
    public partial class TodoItem : UserControl
    {
        public TodoItem()
        {
            InitializeComponent();
        }

        // 封裝屬性 : 事件名稱
        public string ItemName
        {
            get
            {
                return ItemNameTb.Text;
            }
            set
            {
                ItemNameTb.Text = value;
            }
        }
        // 自訂刪除事件
        public event EventHandler DeleteItem;

        // 項目名稱鍵盤按下事件
        private void ItemNameTb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 任務空白，而且按下 Backspace 鍵時，引發 DeleteItem 事件
            if(ItemNameTb.Text == "" && e.Key == Key.Back)
            {
                DeleteItem(this, null);
            }
        }
    }
}
