using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmSendMail : Form
    {
        private string idHD, idMain;
        public frmSendMail()
        {
            InitializeComponent();
        }
        public frmSendMail(string idHD,string idMain)
        {
            InitializeComponent();
            this.idHD = idHD;
            this.idMain = idMain;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.UseDefaultCredentials = false; 
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);

                MailMessage message = new MailMessage(textBox1.Text, "hocvd15@gmail.com");
                message.Subject = "Đăng ký key";
                message.Body = "ID HD : "+idHD+" và ID Main : "+idMain;
                mailclient.Send(message);
                MessageBox.Show("Mail đã được gửi đi,bạn vui lòng đợi phản hồi mail từ hocvd.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra! chưa gửi được mail. Bạn vui lòng kiểm tra lại.  Gợi ý : Truy cập vào tài khoản mail của bạn từ trình duyệt => Vào cài đặt và bạn tùy chọn \"Cho phép ứng dụng kém an toàn: BẬT\"", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
