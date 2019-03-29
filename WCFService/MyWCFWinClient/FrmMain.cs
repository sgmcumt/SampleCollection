using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWCFWinClient
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //创建WCF客户端对象
            MyWCFService.StudentServiceClient client = new MyWCFService.StudentServiceClient();
            //执行查询
            MyWCFService.Student[] stuList = client.GetStudentByClass("");
            this.dgvStudentList.DataSource = stuList;
        }
    }
}
