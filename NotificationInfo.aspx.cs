using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace web_1
{
    public partial class NotificationInfo : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["ShowPanel"] != null && (bool)Session["ShowPanel"] == true)
            {
                Panel1.Visible = true;
                // 清除會話狀態，以便下次進入該頁面時不再顯示Panel1
                //Session["ShowPanel"] = false;
            }
            else
            {
                Panel1.Visible = false;
            }
            BindGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Session["ShowPanel"] = false;
            if (Session["LoginType"] == "System")
            {
                string hId = null;
                if (RadioButtonList1.SelectedValue == "是")
                {
                    hId = Noti_hId.Text;
                }
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO Fall (eId,pId,fTime,fWhy,hId) VALUES (@eId,@pId,@fTime,@fWhy,@hId)";
                connection = new MySqlConnection(connectionString);
                MySqlCommand  command = new MySqlCommand(query, connection);
                connection.Open();

                command.Parameters.AddWithValue("@eId", Noti_eId.Text);
                command.Parameters.AddWithValue("@pId", Noti_pId.Text);
                command.Parameters.AddWithValue("@fTime", DateTime.Now);
                command.Parameters.AddWithValue("@fWhy", Noti_fwhy.Text);
                //command.Parameters.AddWithValue("@hId", Noti_hId.Text);
                if (string.IsNullOrEmpty(hId))
                {
                    command.Parameters.AddWithValue("@hId", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@hId", hId);
                }
                command.ExecuteNonQuery();
                connection.Close();


                BindGridView();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('新增成功');", true);
            }
            else if (Session["LoginType"] == "Home")
            {
                
            }
        }

        protected void BindGridView()
        {
            if (Session["LoginType"] == "System")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT Fall.fId as 跌倒編號,Fall.eId as 長者編號,Elder.eName as 長者姓名 ,Fall.pId as 跌倒地點,Fall.fTime as 跌倒時間, Fall.fWhy as 跌倒原因 ,Fall.hId as 送醫 FROM Fall " +
                           "INNER JOIN Elder ON Fall.eId = Elder.eId ORDER BY Fall.fId";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;

                GridView1.DataBind();
                GridView1.Visible = true;
                connection.Close();
            }
            else if (Session["LoginType"] == "Home")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT HomeElderFall.hfId as 跌倒編號,HomeElderFall.heId as 長者編號,HomeElder.heName as 長者姓名 ,HomeElderFall.pId as 跌倒地點,HomeElderFall.hfTime as 跌倒時間, HomeElderFall.hfWhy as 跌倒原因 ,HomeElderFall.hId as 送醫 FROM HomeElderFall " +
                           "INNER JOIN HomeElder ON HomeElderFall.heId = HomeElder.heId";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;

                GridView1.DataBind();
                GridView1.Visible = true;
                connection.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "是")
            {
                Panel3.Visible = true;
            }
            else
            {
                Panel3.Visible = false;
            }
        }
    }
}