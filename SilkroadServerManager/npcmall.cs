using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SilkroadServerManager
{
	public class npcmall : Form
	{
		private SqlConnection sqlconnect = new SqlConnection(fonksiyonlar.connect_string("Cert\\ini\\srShard.ini"));

		private string itemcodename = "";

		private string npctabname = "";

		private string slotindex = "";

		private IContainer components = null;

		private TreeView treeView1;

		private Label itemname;

		private Label label1;

		private Label label2;

		private Label label3;

		private TextBox honor;

		private TextBox coppercoin;

		private Button kaydet;

		private Button iptal;

		private Button sil;

		private GroupBox groupBox2;

		private Button ara;

		private TextBox itemara;

		private ListBox itemlist;

		private Label tabname;

		private Label label6;

		private TextBox ironcoin;

		private TextBox gold;

		private TabControl tabControl1;

		private Label label4;

		private Label label5;

		private Label label7;

		private TextBox silvercoin;

		private TextBox goldcoin;

		private TextBox arenacoin;

		private Button tamsil;

		private PictureBox pictureBox1;

		private Label slot;
        private TextBox silk;
        private Label label8;
        private Button kapat;

		public npcmall()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			TreeNode treeNode = new TreeNode("Jangan");
			TreeNode treeNode2 = new TreeNode("Donwhang");
			TreeNode treeNode3 = new TreeNode("Hotan");
			TreeNode treeNode4 = new TreeNode("Samarkand");
			TreeNode treeNode5 = new TreeNode("Constantinople");
			TreeNode treeNode6 = new TreeNode("Alexandria");
			TreeNode treeNode7 = new TreeNode("Baghdad");
			TreeNode treeNode8 = new TreeNode("Other");
			SqlCommand sqlCommand = new SqlCommand("SELECT CodeName128 FROM _RefShopTab where CodeName128 like'STORE_%' and [Service] = 1", sqlconnect);
			sqlconnect.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				string text = sqlDataReader["CodeName128"].ToString();
				string text2 = text.Replace("STORE_", "");
				if (text.Contains("STORE_CH_"))
				{
					treeNode.Nodes.Add(text, text2);
				}
				else if (text.Contains("STORE_WC_"))
				{
					treeNode2.Nodes.Add(text, text2);
				}
				else if (text.Contains("STORE_KT_"))
				{
					treeNode3.Nodes.Add(text, text2);
				}
				else if (text.Contains("STORE_CA_"))
				{
					treeNode4.Nodes.Add(text, text2);
				}
				else if (text.Contains("STORE_EU_"))
				{
					treeNode5.Nodes.Add(text, text2);
				}
				else if (text.Contains("STORE_SD_"))
				{
					treeNode6.Nodes.Add(text, text2);
				}
				else if (text.Contains("STORE_AR_"))
				{
					treeNode7.Nodes.Add(text, text2);
				}
				else
				{
					treeNode8.Nodes.Add(text, text2);
				}
			}
			sqlconnect.Close();
			treeView1.Nodes.Add(treeNode);
			treeView1.Nodes.Add(treeNode2);
			treeView1.Nodes.Add(treeNode3);
			treeView1.Nodes.Add(treeNode4);
			treeView1.Nodes.Add(treeNode5);
			treeView1.Nodes.Add(treeNode6);
			treeView1.Nodes.Add(treeNode7);
			treeView1.Nodes.Add(treeNode8);
			if (Language.Default.language == "English")
			{
				this.Text = "NPC Editing";
				itemname.Text = "item name";
				tabname.Text = "Tab name";
				sil.Text = "Delete";
				tamsil.Text = "Delete full";
				iptal.Text = "Cancel";
				kaydet.Text = "Save";
				kapat.Text = "Close";
				groupBox2.Text = "Add New Item";
				ara.Text = "Search";

			}
		}

		private void temizle()
		{
			if (Language.Default.language == "English")
			{
				gold.Clear();
				silk.Clear();
				honor.Clear();
				coppercoin.Clear();
				ironcoin.Clear();
				silvercoin.Clear();
				goldcoin.Clear();
				arenacoin.Clear();
				itemcodename = "";
				itemname.Text = "Item Name";
				kaydet.Name = "kaydet";
				kaydet.Text = "Save";
				sil.Enabled = false;
				pictureBox1.Image = null;
				gold.Enabled = true;
				silk.Enabled = true;
				honor.Enabled = true;
				coppercoin.Enabled = true;
				ironcoin.Enabled = true;
				silvercoin.Enabled = true;
				goldcoin.Enabled = true;
				arenacoin.Enabled = true;
			}
			else
			{
				gold.Clear();
				silk.Clear();
				honor.Clear();
				coppercoin.Clear();
				ironcoin.Clear();
				silvercoin.Clear();
				goldcoin.Clear();
				arenacoin.Clear();
				itemcodename = "";
				itemname.Text = "Item Adı";
				kaydet.Name = "kaydet";
				kaydet.Text = "Kaydet";
				sil.Enabled = false;
				pictureBox1.Image = null;
				gold.Enabled = true;
				silk.Enabled = true;
				honor.Enabled = true;
				coppercoin.Enabled = true;
				ironcoin.Enabled = true;
				silvercoin.Enabled = true;
				goldcoin.Enabled = true;
				arenacoin.Enabled = true;
			}

		}

		private string sqlislem(string sqlkomut, string vericek)
		{
			try
			{
				sqlconnect.Open();
				SqlCommand sqlCommand = new SqlCommand(sqlkomut, sqlconnect);
				if (vericek != "")
				{
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (Language.Default.language == "English")
					{
						vericek = ((!sqlDataReader.Read()) ? "NONE" : sqlDataReader[vericek].ToString());
					}
					else
					{
						vericek = ((!sqlDataReader.Read()) ? "YOK" : sqlDataReader[vericek].ToString());
					}

				}
				else
				{
					sqlCommand.ExecuteNonQuery();
					if (Language.Default.language == "English")
					{
						vericek = "Successful !";
					}
					else
					{
						vericek = "Başarılı !";
					}

				}
				sqlconnect.Close();
			}
			catch (Exception ex)
			{
				if (Language.Default.language == "English")
				{
					vericek = "ERROR";
				}
				else
				{
					vericek = "HATA";
				}

				MessageBox.Show(ex.ToString());
				sqlconnect.Close();
			}
			return vericek;
		}

		private void flowpaneldoldur()
		{
			temizle();
			tabControl1.Controls.Clear();
			tabname.Text = treeView1.SelectedNode.Text;
			slotindex = "";
			slot.Text = "Slot:";
			string text = sqlislem("select max(SlotIndex) as sayi from _RefShopGoods where RefTabCodeName='" + npctabname + "'", "sayi");
			text = ((!(text == "")) ? (Convert.ToInt16(text) + 3).ToString() : "0");
			int num = Convert.ToInt16(text) / 30 + 1;
			int num2 = 0;
			for (int i = 1; i <= num; i++)
			{
				TabPage tabPage = new TabPage();
				tabPage.Text = i.ToString();
				FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
				flowLayoutPanel.Size = new Size(278, 230);
				flowLayoutPanel.BackColor = Color.Gray;
				tabControl1.Controls.Add(tabPage);
				tabPage.Controls.Add(flowLayoutPanel);
				for (int j = num2; j < i * 30; j++)
				{
					string text2 = sqlislem("select RefPackageItemCodeName from _RefShopGoods where RefTabCodeName='" + npctabname + "' and SlotIndex=" + j, "RefPackageItemCodeName");
					Button button = new Button();
					button.Size = new Size(40, 40);
					if (Language.Default.language == "English")
					{
						if (text2 != "NONE")
						{
							string str = sqlislem("select replace(AssocFileIcon,'.ddj','.png') as AssocFileIcon from _RefPackageItem where CodeName128='" + text2 + "'", "AssocFileIcon");
							button.Name = "mevcut";
							button.Tag = text2;
							if (File.Exists("icon\\" + str))
							{
								button.Image = Image.FromFile("icon\\" + str);
							}
							else
							{
								button.Image = Image.FromFile("icon\\icon_default.png");
							}
						}
						else
						{
							button.Name = "new";
							button.Tag = j.ToString();
							button.Text = j.ToString();
						}
					}
					else
					{
						if (text2 != "YOK")
						{
							string str = sqlislem("select replace(AssocFileIcon,'.ddj','.png') as AssocFileIcon from _RefPackageItem where CodeName128='" + text2 + "'", "AssocFileIcon");
							button.Name = "mevcut";
							button.Tag = text2;
							if (File.Exists("icon\\" + str))
							{
								button.Image = Image.FromFile("icon\\" + str);
							}
							else
							{
								button.Image = Image.FromFile("icon\\icon_default.png");
							}
						}
						else
						{
							button.Name = "yeni";
							button.Tag = j.ToString();
							button.Text = j.ToString();
						}
					}
					button.Click += btn_Click;
					flowLayoutPanel.Controls.Add(button);
				}
				num2 = i * 30;
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			npctabname = treeView1.SelectedNode.Name;
			if (npctabname != "")
			{
				flowpaneldoldur();
			}
		}

		private void btn_Click(object sender, EventArgs e)
		{
			if (Language.Default.language == "English")
			{
				if (((Button)sender).Name == "new")
				{
					slotindex = ((Button)sender).Tag.ToString();
					slot.Text = "Slot:" + slotindex;
					temizle();
					return;
				}
			}
			else
			{
				if (((Button)sender).Name == "yeni")
				{
					slotindex = ((Button)sender).Tag.ToString();
					slot.Text = "Slot:" + slotindex;
					temizle();
					return;
				}
			}

			slotindex = "";
			slot.Text = "Slot:" + slotindex;
			pictureBox1.Image = ((Button)sender).Image;
			itemcodename = ((Button)sender).Tag.ToString();
			itemname.Text = itemcodename;
			SqlCommand sqlCommand = new SqlCommand("SELECT Cost,PaymentDevice FROM _RefPricePolicyOfItem WHERE [Service]=1 and RefPackageItemCodeName='" + itemcodename + "'", sqlconnect);
			sqlconnect.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				object obj = sqlDataReader["PaymentDevice"];
				object obj2 = obj;
				object obj3;
				if (obj2 != null && (obj3 = obj2) is int)
				{
					switch ((int)obj3)
					{
					case 1:
						gold.Text = sqlDataReader["Cost"].ToString();
						break;
					case 2:
						silk.Text = sqlDataReader["Cost"].ToString();
						break;
					case 32:
						honor.Text = sqlDataReader["Cost"].ToString();
						break;
					case 64:
						coppercoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 128:
						ironcoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 256:
						silvercoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 512:
						goldcoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 1024:
						arenacoin.Text = sqlDataReader["Cost"].ToString();
						break;
					}
				}
			}
			sqlconnect.Close();
			if (Language.Default.language == "English")
			{
				kaydet.Name = "kaydet";
				kaydet.Text = "Save";
			}
			else
			{
				kaydet.Name = "kaydet";
				kaydet.Text = "Kaydet";
			}
			sil.Enabled = true;
		}

		private void tamsil_Click(object sender, EventArgs e)
		{
			if (itemcodename != "")
			{
				sqlislem("DELETE FROM _RefShopGoods WHERE RefPackageItemCodeName like'%" + itemcodename + "'", "");
				sqlislem("DELETE FROM _RefPricePolicyOfItem WHERE RefPackageItemCodeName like'%" + itemcodename + "'", "");
				sqlislem("DELETE FROM _RefScrapOfPackageItem WHERE RefPackageItemCodeName like'%" + itemcodename + "'", "");
				sqlislem("DELETE FROM _RefPackageItem WHERE CodeName128 like'%" + itemcodename + "'", "");
				if (Language.Default.language == "English")
				{
					itemname.Text = "Successful !";
				}
				else
				{
					itemname.Text = "Başarılı !";
				}

				flowpaneldoldur();
			}
			else
			{
				if (Language.Default.language == "English")
				{
					itemname.Text = "Please select item !";
				}
				else
				{
					itemname.Text = "Lütfen item seçiniz !";
				}
			}
		}

		private void sil_Click(object sender, EventArgs e)
		{
			if (itemcodename != "")
			{
				sqlislem("DELETE FROM _RefShopGoods WHERE RefTabCodeName='" + npctabname + "' and RefPackageItemCodeName='" + itemcodename + "'", "");
				if (Language.Default.language == "English")
				{
					itemname.Text = "Successful !";
				}
				else
				{
					itemname.Text = "Başarılı !";
				}
				flowpaneldoldur();
			}
			else
			{
				if (Language.Default.language == "English")
				{
					itemname.Text = "Please select item !";
				}
				else
				{
					itemname.Text = "Lütfen item seçiniz !";
				}
			}
		}

		private void iptal_Click(object sender, EventArgs e)
		{
			if (npctabname != "")
			{
				flowpaneldoldur();
			}
			if (Language.Default.language == "English")
			{
				itemname.Text = "item name";
			}
			else
			{
				itemname.Text = "item adı";
			}
		}

		private void kaydet_Click(object sender, EventArgs e)
		{
			if (itemcodename == "")
			{
				if (Language.Default.language == "English")
				{
					itemname.Text = "Please select item !";
				}
				else
				{
					itemname.Text = "Lütfen item seçiniz !";
				}
				return;
			}
			if (npctabname == "")
			{
				if (Language.Default.language == "English")
				{
					tabname.Text = "Select Tab from Tab List";
				}
				else
				{
					tabname.Text = "Tab List 'den Tab Seçiniz";
				}
				return;
			}
			if (gold.Text == "" && silk.Text == "" && honor.Text == "" && coppercoin.Text == "" && ironcoin.Text == "" && silvercoin.Text == "" && goldcoin.Text == "" && arenacoin.Text == "")
			{
				if (Language.Default.language == "English")
				{
					itemname.Text = "Please Enter Any Fee";
				}
				else
				{
					itemname.Text = "Lütfen Herhangi Bir Ücret Girişi Yapınız";
				}
				gold.Focus();
				return;
			}
			if (Language.Default.language == "English")
			{
				if (((Button)sender).Name == "save")
				{
					if (gold.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + gold.Text + " WHERE PaymentDevice = 1 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (silk.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + silk.Text + " WHERE PaymentDevice = 2 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (honor.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + honor.Text + " WHERE PaymentDevice = 32 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (coppercoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + coppercoin.Text + " WHERE PaymentDevice = 64 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (ironcoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + ironcoin.Text + " WHERE PaymentDevice = 128 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (silvercoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + silvercoin.Text + " WHERE PaymentDevice = 256 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (goldcoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + goldcoin.Text + " WHERE PaymentDevice = 512 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (arenacoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + arenacoin.Text + " WHERE PaymentDevice = 1024 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					itemname.Text = "Successful !";
				}
				else
				{
					string text = sqlislem("select ID from _RefShopObject", "ID");
					string text2 = sqlislem("select Dur_L from _RefObjItem where ID in (select Link From _RefObjCommon where CodeName128 = '" + itemcodename + "')", "Dur_L");
					if (slotindex == "")
					{
						itemname.Text = "Please Select One Of The Available Slots";
						return;
					}
					if (sqlislem("select CodeName128 from _RefPackageItem where CodeName128 ='PACKAGE_" + itemcodename + "'", "CodeName128") == "NONE")
					{
						sqlislem("insert into _RefPackageItem SELECT 1, " + text + ", 'PACKAGE_' + CodeName128, 0, 'EXPAND_TERM_ALL', NameStrID128, DescStrID128, AssocFileIcon128, -1, 'xxx', -1, 'xxx', -1, 'xxx', -1, 'xxx' FROM [dbo].[_RefObjCommon] where CodeName128 = '" + itemcodename + "'", "");
						if (gold.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',1,0," + gold.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (silk.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',2,0," + silk.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (honor.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',32,0," + honor.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (coppercoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',64,0," + coppercoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (ironcoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',128,0," + ironcoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (silvercoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',256,0," + silvercoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (goldcoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',512,0," + goldcoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (arenacoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',1024,0," + arenacoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						sqlislem("insert into _RefScrapOfPackageItem values(1," + text + ",'PACKAGE_" + itemcodename + "','" + itemcodename + "',0,0," + text2 + ",0,0,0,0,0,0,0,0,0,0,0,0,0,-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						sqlislem("insert into _RefShopGoods values (1," + text + ",'" + npctabname + "','PACKAGE_" + itemcodename + "'," + slotindex + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						itemname.Text = "Item Added";
					}
					else
					{
						sqlislem("insert into _RefShopGoods values (1," + text + ",'" + npctabname + "','PACKAGE_" + itemcodename + "'," + slotindex + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						itemname.Text = "Item Added";
					}
				}

			}
			else
			{
				if (((Button)sender).Name == "kaydet")
				{
					if (gold.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + gold.Text + " WHERE PaymentDevice = 1 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (silk.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + silk.Text + " WHERE PaymentDevice = 2 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (honor.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + honor.Text + " WHERE PaymentDevice = 32 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (coppercoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + coppercoin.Text + " WHERE PaymentDevice = 64 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (ironcoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + ironcoin.Text + " WHERE PaymentDevice = 128 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (silvercoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + silvercoin.Text + " WHERE PaymentDevice = 256 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (goldcoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + goldcoin.Text + " WHERE PaymentDevice = 512 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					if (arenacoin.Text != "")
					{
						sqlislem("UPDATE _RefPricePolicyOfItem SET Cost = " + arenacoin.Text + " WHERE PaymentDevice = 1024 and RefPackageItemCodeName='" + itemcodename + "'", "");
					}
					itemname.Text = "Successful !";
				}
				else
				{
					string text = sqlislem("select ID from _RefShopObject", "ID");
					string text2 = sqlislem("select Dur_L from _RefObjItem where ID in (select Link From _RefObjCommon where CodeName128 = '" + itemcodename + "')", "Dur_L");
					if (slotindex == "")
					{
						itemname.Text = "Lütfen Boş Slotlardan Birini Seçiniz";
						return;
					}
					if (sqlislem("select CodeName128 from _RefPackageItem where CodeName128 ='PACKAGE_" + itemcodename + "'", "CodeName128") == "YOK")
					{
						sqlislem("insert into _RefPackageItem SELECT 1, " + text + ", 'PACKAGE_' + CodeName128, 0, 'EXPAND_TERM_ALL', NameStrID128, DescStrID128, AssocFileIcon128, -1, 'xxx', -1, 'xxx', -1, 'xxx', -1, 'xxx' FROM [dbo].[_RefObjCommon] where CodeName128 = '" + itemcodename + "'", "");
						if (gold.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',1,0," + gold.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (silk.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',2,0," + silk.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (honor.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',32,0," + honor.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (coppercoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',64,0," + coppercoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (ironcoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',128,0," + ironcoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (silvercoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',256,0," + silvercoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (goldcoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',512,0," + goldcoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						if (arenacoin.Text != "")
						{
							sqlislem("insert into _RefPricePolicyOfItem values(1," + text + ",'PACKAGE_" + itemcodename + "',1024,0," + arenacoin.Text + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						}
						sqlislem("insert into _RefScrapOfPackageItem values(1," + text + ",'PACKAGE_" + itemcodename + "','" + itemcodename + "',0,0," + text2 + ",0,0,0,0,0,0,0,0,0,0,0,0,0,-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						sqlislem("insert into _RefShopGoods values (1," + text + ",'" + npctabname + "','PACKAGE_" + itemcodename + "'," + slotindex + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						itemname.Text = "Item Eklendi ";
					}
					else
					{
						sqlislem("insert into _RefShopGoods values (1," + text + ",'" + npctabname + "','PACKAGE_" + itemcodename + "'," + slotindex + ",-1,'xxx',-1,'xxx',-1,'xxx',-1,'xxx')", "");
						itemname.Text = "Item Eklendi ";
					}
				}

			}
			flowpaneldoldur();
		}

		private void ara_Click(object sender, EventArgs e)
		{
			itemlist.Items.Clear();
			itemcodename = "";
			SqlCommand sqlCommand = new SqlCommand("SELECT CodeName128 FROM [dbo].[_RefObjCommon] where [Service] = 1 and TypeID1=3 and CodeName128 like '%" + itemara.Text + "%'", sqlconnect);
			sqlconnect.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				itemlist.Items.Add(sqlDataReader["CodeName128"]);
			}
			sqlconnect.Close();
		}

		private void itemlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			temizle();
			gold.Focus();
			itemcodename = itemlist.SelectedItem.ToString();
			string text = "icon\\" + sqlislem("SELECT REPLACE(AssocFileIcon128,'.ddj','.png') as AssocFileIcon128 FROM [dbo].[_RefObjCommon] where CodeName128='" + itemcodename + "'", "AssocFileIcon128");
			if (File.Exists(text))
			{
				pictureBox1.Image = Image.FromFile(text);
			}
			else
			{
				pictureBox1.Image = Image.FromFile("icon\\icon_default.png");
			}
			itemname.Text = itemcodename;
			if (Language.Default.language == "English")
			{
				kaydet.Name = "add";
				kaydet.Text = "Add";
			}
			else
			{
				kaydet.Name = "ekle";
				kaydet.Text = "Ekle";
			}
			sil.Enabled = false;
			SqlCommand sqlCommand = new SqlCommand("SELECT Cost,PaymentDevice FROM _RefPricePolicyOfItem WHERE RefPackageItemCodeName='PACKAGE_" + itemcodename + "'", sqlconnect);
			sqlconnect.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				gold.Enabled = false;
				silk.Enabled = false;
				honor.Enabled = false;
				coppercoin.Enabled = false;
				ironcoin.Enabled = false;
				silvercoin.Enabled = false;
				goldcoin.Enabled = false;
				arenacoin.Enabled = false;
				object obj = sqlDataReader["PaymentDevice"];
				object obj2 = obj;
				object obj3;
				if (obj2 != null && (obj3 = obj2) is int)
				{
					switch ((int)obj3)
					{
					case 1:
						gold.Text = sqlDataReader["Cost"].ToString();
						break;
					case 2:
						silk.Text = sqlDataReader["Cost"].ToString();
						break;
					case 32:
						honor.Text = sqlDataReader["Cost"].ToString();
						break;
					case 64:
						coppercoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 128:
						ironcoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 256:
						silvercoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 512:
						goldcoin.Text = sqlDataReader["Cost"].ToString();
						break;
					case 1024:
						arenacoin.Text = sqlDataReader["Cost"].ToString();
						break;
					}
				}
			}
			sqlconnect.Close();
		}

		private void kapat_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(npcmall));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.itemname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.honor = new System.Windows.Forms.TextBox();
            this.coppercoin = new System.Windows.Forms.TextBox();
            this.gold = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabname = new System.Windows.Forms.Label();
            this.ironcoin = new System.Windows.Forms.TextBox();
            this.kaydet = new System.Windows.Forms.Button();
            this.iptal = new System.Windows.Forms.Button();
            this.sil = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.itemlist = new System.Windows.Forms.ListBox();
            this.ara = new System.Windows.Forms.Button();
            this.itemara = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.silvercoin = new System.Windows.Forms.TextBox();
            this.goldcoin = new System.Windows.Forms.TextBox();
            this.arenacoin = new System.Windows.Forms.TextBox();
            this.tamsil = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.slot = new System.Windows.Forms.Label();
            this.kapat = new System.Windows.Forms.Button();
            this.silk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = "";
            this.treeView1.Size = new System.Drawing.Size(226, 538);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // itemname
            // 
            this.itemname.AutoSize = true;
            this.itemname.BackColor = System.Drawing.SystemColors.Control;
            this.itemname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemname.Location = new System.Drawing.Point(372, 9);
            this.itemname.MinimumSize = new System.Drawing.Size(400, 20);
            this.itemname.Name = "itemname";
            this.itemname.Size = new System.Drawing.Size(400, 20);
            this.itemname.TabIndex = 12;
            this.itemname.Text = "item ismi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(573, 68);
            this.label1.MinimumSize = new System.Drawing.Size(65, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gold :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(539, 118);
            this.label2.MinimumSize = new System.Drawing.Size(65, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Honor Point :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(539, 143);
            this.label3.MinimumSize = new System.Drawing.Size(65, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Copper Coin :";
            // 
            // honor
            // 
            this.honor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.honor.Location = new System.Drawing.Point(610, 113);
            this.honor.Name = "honor";
            this.honor.Size = new System.Drawing.Size(80, 22);
            this.honor.TabIndex = 2;
            // 
            // coppercoin
            // 
            this.coppercoin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.coppercoin.Location = new System.Drawing.Point(610, 139);
            this.coppercoin.Name = "coppercoin";
            this.coppercoin.Size = new System.Drawing.Size(80, 22);
            this.coppercoin.TabIndex = 3;
            // 
            // gold
            // 
            this.gold.Location = new System.Drawing.Point(610, 65);
            this.gold.Name = "gold";
            this.gold.Size = new System.Drawing.Size(80, 20);
            this.gold.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(555, 168);
            this.label6.MinimumSize = new System.Drawing.Size(65, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Iron Coin :";
            // 
            // tabname
            // 
            this.tabname.AutoSize = true;
            this.tabname.BackColor = System.Drawing.SystemColors.Control;
            this.tabname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabname.Location = new System.Drawing.Point(537, 39);
            this.tabname.MinimumSize = new System.Drawing.Size(235, 18);
            this.tabname.Name = "tabname";
            this.tabname.Size = new System.Drawing.Size(235, 18);
            this.tabname.TabIndex = 13;
            this.tabname.Text = "Tab ismi";
            // 
            // ironcoin
            // 
            this.ironcoin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ironcoin.Location = new System.Drawing.Point(610, 165);
            this.ironcoin.Name = "ironcoin";
            this.ironcoin.Size = new System.Drawing.Size(80, 22);
            this.ironcoin.TabIndex = 4;
            // 
            // kaydet
            // 
            this.kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydet.Location = new System.Drawing.Point(548, 265);
            this.kaydet.Name = "kaydet";
            this.kaydet.Size = new System.Drawing.Size(114, 35);
            this.kaydet.TabIndex = 8;
            this.kaydet.Text = "Kaydet";
            this.kaydet.UseVisualStyleBackColor = true;
            this.kaydet.Click += new System.EventHandler(this.kaydet_Click);
            // 
            // iptal
            // 
            this.iptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptal.Location = new System.Drawing.Point(696, 215);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(76, 45);
            this.iptal.TabIndex = 11;
            this.iptal.Text = "İptal";
            this.iptal.UseVisualStyleBackColor = true;
            this.iptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // sil
            // 
            this.sil.Enabled = false;
            this.sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sil.Location = new System.Drawing.Point(696, 139);
            this.sil.Name = "sil";
            this.sil.Size = new System.Drawing.Size(76, 35);
            this.sil.TabIndex = 9;
            this.sil.Text = "Sil";
            this.sil.UseVisualStyleBackColor = true;
            this.sil.Click += new System.EventHandler(this.sil_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.itemlist);
            this.groupBox2.Controls.Add(this.ara);
            this.groupBox2.Controls.Add(this.itemara);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(244, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 253);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yeni Item Ekle";
            // 
            // itemlist
            // 
            this.itemlist.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemlist.FormattingEnabled = true;
            this.itemlist.ItemHeight = 16;
            this.itemlist.Location = new System.Drawing.Point(9, 49);
            this.itemlist.Name = "itemlist";
            this.itemlist.Size = new System.Drawing.Size(513, 196);
            this.itemlist.TabIndex = 16;
            this.itemlist.SelectedIndexChanged += new System.EventHandler(this.itemlist_SelectedIndexChanged);
            // 
            // ara
            // 
            this.ara.Location = new System.Drawing.Point(434, 17);
            this.ara.Name = "ara";
            this.ara.Size = new System.Drawing.Size(88, 26);
            this.ara.TabIndex = 15;
            this.ara.Text = "Ara";
            this.ara.UseVisualStyleBackColor = true;
            this.ara.Click += new System.EventHandler(this.ara_Click);
            // 
            // itemara
            // 
            this.itemara.Location = new System.Drawing.Point(9, 21);
            this.itemara.Name = "itemara";
            this.itemara.Size = new System.Drawing.Size(419, 22);
            this.itemara.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.ItemSize = new System.Drawing.Size(20, 18);
            this.tabControl1.Location = new System.Drawing.Point(244, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 260);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(547, 193);
            this.label4.MinimumSize = new System.Drawing.Size(65, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Silver Coin :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(550, 218);
            this.label5.MinimumSize = new System.Drawing.Size(65, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Gold Coin :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(545, 243);
            this.label7.MinimumSize = new System.Drawing.Size(65, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Arena Coin :";
            // 
            // silvercoin
            // 
            this.silvercoin.Location = new System.Drawing.Point(610, 191);
            this.silvercoin.Name = "silvercoin";
            this.silvercoin.Size = new System.Drawing.Size(80, 20);
            this.silvercoin.TabIndex = 5;
            // 
            // goldcoin
            // 
            this.goldcoin.Location = new System.Drawing.Point(610, 215);
            this.goldcoin.Name = "goldcoin";
            this.goldcoin.Size = new System.Drawing.Size(80, 20);
            this.goldcoin.TabIndex = 6;
            // 
            // arenacoin
            // 
            this.arenacoin.Location = new System.Drawing.Point(610, 239);
            this.arenacoin.Name = "arenacoin";
            this.arenacoin.Size = new System.Drawing.Size(80, 20);
            this.arenacoin.TabIndex = 7;
            // 
            // tamsil
            // 
            this.tamsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tamsil.Location = new System.Drawing.Point(696, 176);
            this.tamsil.Name = "tamsil";
            this.tamsil.Size = new System.Drawing.Size(76, 35);
            this.tamsil.TabIndex = 10;
            this.tamsil.Text = "Tam Sil";
            this.tamsil.UseVisualStyleBackColor = true;
            this.tamsil.Click += new System.EventHandler(this.tamsil_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(708, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // slot
            // 
            this.slot.AutoSize = true;
            this.slot.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.slot.ForeColor = System.Drawing.Color.Red;
            this.slot.Location = new System.Drawing.Point(249, 9);
            this.slot.Name = "slot";
            this.slot.Size = new System.Drawing.Size(45, 23);
            this.slot.TabIndex = 23;
            this.slot.Text = "Slot";
            // 
            // kapat
            // 
            this.kapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kapat.Location = new System.Drawing.Point(668, 266);
            this.kapat.Name = "kapat";
            this.kapat.Size = new System.Drawing.Size(104, 34);
            this.kapat.TabIndex = 24;
            this.kapat.Text = "Kapat";
            this.kapat.UseVisualStyleBackColor = true;
            this.kapat.Click += new System.EventHandler(this.kapat_Click);
            // 
            // silk
            // 
            this.silk.Location = new System.Drawing.Point(610, 89);
            this.silk.Name = "silk";
            this.silk.Size = new System.Drawing.Size(80, 20);
            this.silk.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(578, 92);
            this.label8.MinimumSize = new System.Drawing.Size(65, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Silk :";
            // 
            // npcmall
            // 
            this.AcceptButton = this.kaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.CancelButton = this.kapat;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.kapat);
            this.Controls.Add(this.slot);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tamsil);
            this.Controls.Add(this.arenacoin);
            this.Controls.Add(this.goldcoin);
            this.Controls.Add(this.silvercoin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.silk);
            this.Controls.Add(this.gold);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.honor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ironcoin);
            this.Controls.Add(this.kaydet);
            this.Controls.Add(this.itemname);
            this.Controls.Add(this.coppercoin);
            this.Controls.Add(this.tabname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.iptal);
            this.Controls.Add(this.sil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "npcmall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPC Düzenleme";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
